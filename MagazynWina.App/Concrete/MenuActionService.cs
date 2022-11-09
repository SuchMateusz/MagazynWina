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
            foreach (var menuAction in Wines)
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
            AddWine(new MenuAction(1, "Add new wine", "Main"));
            AddWine(new MenuAction(2, "Remove wine", "Main"));
            AddWine(new MenuAction(3, "List of wine", "Main"));
            AddWine(new MenuAction(4, "Show details wine", "Main"));
            AddWine(new MenuAction(5, "Uppdate choosen wine", "Main"));
            AddWine(new MenuAction(6, "How much sugar add for starting producing wine", "Main"));
            AddWine(new MenuAction(7, "Reading from file", "Main"));
            AddWine(new MenuAction(8, "Saving to file", "Main"));
            AddWine(new MenuAction(9, "Exit Program", "Main"));

            AddWine(new MenuAction(1, "Sweet", "AddNewWineMenu"));
            AddWine(new MenuAction(2, "Half sweet", "AddNewWineMenu"));
            AddWine(new MenuAction(3, "Dry", "AddNewWineMenu"));
        }


    }

} 
