using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TutorialCode.ViewModel.Partials;
using TutorialCode.ViewModel.Umbraco;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedModels;

namespace TutorialCode.Controllers.Umbraco
{
    public class MenuPageExampleController : RenderMvcController
    {
        public override ActionResult Index(ContentModel model)
        {
            var menuPageExample = new MenuPageExample(model.Content);
            return CurrentTemplate(new ComposedViewModel<MenuPageExample, MenuPageViewModel>
            {
                Page = menuPageExample,
                ViewModel = new MenuPageViewModel
                {
                    MegaMenu = GetPrimaryNavigation(),
                }
            });
        }

        public List<NavigationItemViewModel> GetPrimaryNavigation()
        {
            var menuList = new List<NavigationItemViewModel>();
            var menu = GetPrimaryMenuFromPageTree();

            if (menu == null)
                return menuList;

            var menuItems = menu.Children;
            foreach (var item in menuItems.OrderBy(y => y.SortOrder))
            {
                var menuItem = new MenuItem(item);
                var url = menuItem.Link.Url;

                var navigationItem = new NavigationItemViewModel
                {
                    Name = menuItem.Name,
                    Link = url,
                };
                //foreach (var subItem in menuItem.Children)
                //{
                //}

                menuList.Add(navigationItem);
            }

            return menuList;
        }

        public Menu GetPrimaryMenuFromPageTree()
        {
            var menus = GetMenusInPageTree();
            return menus.FirstOrDefault(x => x.Name == "Primary Menu");
        }

        public IEnumerable<Menu> GetMenusInPageTree()
        {
            var menu = UmbracoContext.Content.GetByXPath("//" + Menu.ModelTypeAlias);
            return menu.Select(x => new Menu(x));
        }
    }
}