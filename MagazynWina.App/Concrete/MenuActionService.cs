using MagazynWina.App.Common;
using MagazynWina.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazynWina.App
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }

        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (var menuAction in Objects)
            {
                if (menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }

        private void Initialize()
        {
            AddNewObject(new MenuAction(1, "Add new object", "Main"));
            AddNewObject(new MenuAction(2, "Remove object", "Main"));
            AddNewObject(new MenuAction(3, "List of object", "Main"));
            AddNewObject(new MenuAction(4, "Show details object", "Main"));
            AddNewObject(new MenuAction(5, "Uppdate choosen object", "Main"));
            AddNewObject(new MenuAction(6, "How much sugar add for starting producing wine object", "Main"));
            AddNewObject(new MenuAction(7, "Operating on file", "Main"));
            AddNewObject(new MenuAction(8, "Exit Program", "Main"));

            AddNewObject(new MenuAction(1, "Wine", "AddNewObjectMenu"));
            AddNewObject(new MenuAction(2, "Beer", "AddNewObjectMenu"));

            AddNewObject(new MenuAction(1, "Sweet", "AddNewWineMenu"));
            AddNewObject(new MenuAction(2, "Half sweet", "AddNewWineMenu"));
            AddNewObject(new MenuAction(3, "Dry", "AddNewWineMenu"));

            AddNewObject(new MenuAction(1, "Save data to file", "AddFileMenu"));
            AddNewObject(new MenuAction(2, "Read data from file", "AddFileMenu"));
            AddNewObject(new MenuAction(3, "Save raport to file", "AddFileMenu"));
            AddNewObject(new MenuAction(4, "Read raport to file", "AddFileMenu"));
            AddNewObject(new MenuAction(5, "Save testFile to file", "AddFileMenu"));
        }
    }
} 
