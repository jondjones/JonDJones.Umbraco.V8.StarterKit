using System.Web.Mvc;
using TutorialCode.ViewModel.Umbraco;
using Umbraco.Web.Mvc;

namespace TutorialCode.Controllers.SurfacaeController
{
    public class ContactFormController : SurfaceController
    {
        public ActionResult RenderForm()
        {
            var viewModel = new ContactFormViewModel();
            return PartialView("ContactForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ContactFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData.Add("CustomMessage", "Sent");
                return RedirectToCurrentUmbracoPage();
            }
            TempData.Add("CustomMessage", "Failure");
            return CurrentUmbracoPage();
        }

        public ActionResult RenderFormOne()
        {
            var viewModel = new ContactFormViewModel();
            return PartialView("ContactFormOne", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitFormOne(ContactFormViewModel model)
        {
            if (ModelState.IsValid)
            { 
                // Do something
                return PartialView("ContactFormOneSent");
            }

            return PartialView("ContactFormOneError");
        }


    }
}
