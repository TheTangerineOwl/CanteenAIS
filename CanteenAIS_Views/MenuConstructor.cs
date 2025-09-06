using CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System;

namespace CanteenAIS_Views
{
    public class MenuConstructor
    {
        protected Menu mainMenu;
        public Menu MainMenu => mainMenu;

        protected IList<MenuElement> menuData;
        protected IList<UserPerm> perms;

        private readonly MainVM mainVM;

        public MenuConstructor(MainVM context)
        {
            mainVM = context;
            mainMenu = new Menu();
            menuData = new List<MenuElement>();
            perms = DBContext.GetInstance().GetCurrentUserPerms<UserPerm>();
        }

        private MenuItem CreateMenuItem(MenuElementEntity element)
        {
            MenuItem menuItem = new MenuItem
            {
                Header = element.Name,
                Tag = element
            };

            UserPermEntity perm = perms.FirstOrDefault(el => el.ElementId == element.Id);
            menuItem.Visibility = element.IsAllowedByDefault || (perm != null && perm.CanRead) ? Visibility.Visible : Visibility.Collapsed;

            if (!string.IsNullOrEmpty(element.FuncName))
            {
                Binding command = new Binding("Click" + element.FuncName)
                {
                    Source = mainVM
                };
                menuItem.SetBinding(MenuItem.CommandProperty, command);
            }
            return menuItem;
        }

        private void AddMenuItems(MenuItem parentMenuItem, uint parentId)
        {
            List<MenuElement> menuElems = menuData.ToList().FindAll(item => item.ParentId == parentId);

            menuElems.Sort((item1, item2) => item1.Order.CompareTo(item2.Order));

            foreach (MenuElementEntity menuElem in menuElems)
            {
                MenuItem menuItem = CreateMenuItem(menuElem);
                parentMenuItem.Items.Add(menuItem);
                AddMenuItems(menuItem, menuElem.Id);
            }
        }

        public Menu Construct()
        {
            //mainMenu = new Menu();
            mainMenu.Items.Clear();
            menuData = DBContext.GetInstance().MenuElements.Read<MenuElement>();

            List<MenuElement> topLevelMenuElems = menuData.ToList().FindAll(item => item.ParentId == null);
            topLevelMenuElems.Sort((item1, item2) => item1.Order.CompareTo(item2.Order));

            foreach (MenuElement topLevelMenuElem in topLevelMenuElems)
            {
                MenuItem menuItem = CreateMenuItem(topLevelMenuElem);
                mainMenu.Items.Add(menuItem);
                AddMenuItems(menuItem, topLevelMenuElem.Id);
            }

            return mainMenu;
        }
    }
}
