using CanteenAIS_Models;
using CanteenAIS_Models.Statics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Input;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.OrderProduct
{
    public class OrderProductVM : PropChanged
    {
        protected uint _orderId = 0;
        public virtual uint OrderId
        {
            get => _orderId;
            set
            {
                Set(ref _orderId, value);
            }
        }

        public readonly DoubleModel<Entities.OrderProductEntity> Model;

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
            set => Set(ref table, value);
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

        public OrderProductVM(uint orderId = 0)
        {
            OrderId = orderId;
            Model = MainServices.GetInstance().OrderProducts;
            hasSelectedRow = false;
            table = DataTableConverter.ToDataTable(new List<Entities.OrderProductEntity>());
            _oldTable = table.Clone();
            Model.Table = table;

            LoadForOrder(orderId);
        }

        public DataTable LoadForOrder(uint orderId)
        {
            if (orderId != 0)
            {
                Table = Model.FetchAndFilter<Entities.OrderProduct>(item => item.OrderId == orderId);
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

        public Entities.OrderProduct Convert(DataRow row)
        {
            return DBContext.GetInstance().OrderProducts.ParseEntity<Entities.OrderProduct>(row);
        }

        public void AddTableToDB(uint orderId)
        {
            IEnumerable<Entities.OrderProduct> entities = DataTableConverter.FromDataTable(Table, Convert).ToList();
            foreach (var entity in entities)
            {
                entity.OrderId = orderId;
                Model.Add<Entities.OrderProduct>(entity);
            }
        }

        public void EditTableInDB(uint orderId)
        {
            if (OldTable != null)
                foreach (DataRow entity in OldTable.Rows)
                    Model.DeleteRow(entity.Field<uint>("FirstId"), entity.Field<uint>("SecondId"));
            AddTableToDB(orderId);
        }
    }
}
