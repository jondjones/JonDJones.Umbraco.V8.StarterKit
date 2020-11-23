using Umbraco.Web.PublishedModels;

namespace TutorialCode.Controllers.Umbraco
{
    public class HomeVM : BaseVM<Home>
    {
        public bool HasImage { get; set; }

        public string ImageUrl { get; set; }
    }

}
