using CanteenAIS_Models;
using CanteenAIS_Models.Statics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Input;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Ingredient
{
    public class IngredientVM : PropChanged
    {
        protected uint _dishId = 0;
        public virtual uint DishId
        {
            get => _dishId;
            set
            {
                Set(ref _dishId, value);
            }
        }

        public Action OnTableUpdate;

        public readonly DoubleModel<Entities.IngredientEntity> Model;

        protected DataTable _oldTable;
        public virtual DataTable OldTable
        {
            get => _oldTable;
            set => Set(ref _oldTable, value);
        }

        protected DataTable table;
        public virtual DataTable Table
        {
            get => table;
            set
            {
                Set(ref table, value);
                OnTableUpdate?.Invoke();
            }
        }

        public virtual string Title
        {
            get => Model.TableName;
        }

        protected int selectedIndex;
        public virtual int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                HasSelectedRow = value != -1;
                Set(ref selectedIndex, value);
            }
        }

        protected bool isChangeable;
        public virtual bool IsChangeable
        {
            get => isChangeable;
            set => Set(ref isChangeable, value);
        }

        protected bool hasSelectedRow;
        public virtual bool HasSelectedRow
        {
            get => hasSelectedRow;
            set => Set(ref hasSelectedRow, value);
        }

        public Action OnChangeSelection;
        public Action OnAdd;
        public Action<DataRow> OnEdit;
        public Action<DataRow> OnDelete;

        public virtual ICommand ChangeSelection
        {
            get => new Command((obj) =>
            {
                OnChangeSelection?.Invoke();
            });
        }

        public virtual ICommand ClickAdd
        {
            get => new Command((obj) =>
            {
                OnAdd?.Invoke();
                Table = Model.Table;
            });
        }

        public virtual ICommand ClickEdit
        {
            get => new Command((obj) =>
            {
                if (SelectedIndex >= 0 && SelectedIndex < Table.Rows.Count)
                    OnEdit?.Invoke(Table.Rows[SelectedIndex]);
                Table = Model.Table;
            });
        }

        public virtual ICommand ClickDelete
        {
            get => new Command((obj) =>
            {
                if (SelectedIndex >= 0 && SelectedIndex < Table.Rows.Count)
                    OnDelete?.Invoke(Table.Rows[SelectedIndex]);
            });
        }

        public virtual void DeleteRow(DataRow row)
        {
            Table.Rows.Remove(row);
        }

        public Action<string> OnExport;
        public virtual ICommand ClickExport
        {
            get => new Command((obj) =>
            {
                if (obj is string format)
                    OnExport?.Invoke(format);
            });
        }

        public virtual void ExportCsv(string filename, string format)
        {
            ExportFormat export = ExportTable.StringToFormat(format);
            switch (export)
            {
                case ExportFormat.Word:
                    ExportTable.ExportWord(Table, filename); break;
                case ExportFormat.Excel:
                    ExportTable.ExportExcel(Table, filename); break;
                default:
                    ExportTable.ExportCsv(Table, filename); break;
            }
        }

        public IngredientVM(uint dishId = 0)
        {
            DishId = dishId;
            Model = MainServices.GetInstance().Ingredients;
            hasSelectedRow = false;
            table = DataTableConverter.ToDataTable(new List<Entities.IngredientEntity>());
            _oldTable = table.Clone();
            Model.Table = table;

            LoadForDish(dishId);
        }

        public DataTable LoadForDish(uint dishId)
        {
            if (dishId != 0)
            {
                Table = Model.FetchAndFilter<Entities.Ingredient>(item => item.DishId == dishId);
            }
            OldTable = Table.Clone();
            foreach (DataRow row in Table.Rows)
            {
                DataRow newRow = OldTable.NewRow();
                newRow.ItemArray = row.ItemArray;
                OldTable.Rows.Add(newRow);
            }
            return table;
        }

        public Entities.Ingredient Convert(DataRow row)
        {
            return DBContext.GetInstance().Ingredients.ParseEntity<Entities.Ingredient>(row);
        }

        public void AddTableToDB(uint dishId)
        {
            IEnumerable<Entities.Ingredient> entities = DataTableConverter.FromDataTable(Table, Convert).ToList();
            foreach (var entity in entities)
            {
                entity.DishId = dishId;
                Model.Add<Entities.Ingredient>(entity);
            }
        }

        public void EditTableInDB(uint dishId)
        {
            if (OldTable != null)
                foreach (DataRow entity in OldTable.Rows)
                    Model.DeleteRow(entity.Field<uint>("FirstId"), entity.Field<uint>("SecondId"));
            AddTableToDB(dishId);
        }
    }
}
