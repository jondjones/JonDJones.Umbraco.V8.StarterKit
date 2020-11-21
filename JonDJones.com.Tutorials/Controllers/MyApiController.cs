using Umbraco.Web.WebApi;
using System.Web.Http;
using System;

namespace umbraco.local.Controllers
{
    public class MyApiController : UmbracoApiController
    {
        // URL umbraco/api/myapi/isup
        public bool IsUp()
        {
            return true;
        }

        // URL umbraco/api/myapi/mugmeoff
        [HttpGet]
        public string MugMeOff()
        {
            return "Idiot";
        }

        [Route("api/getinsult")]
        [HttpGet]
        public string Insult()
        {
            return GetInsults();
        }

        private string GetInsults()
        {
            var insults = new[]
            {
                "Tosser",
                "Wanker",
                "Slag",
                "Cheese Eating Surrender Monkey",
                "Stupid",
                "Daft Cow",
                "Asshole",
                "Git",
                "Moron",
                "Idiot",
                "Gormless",
                "Minger",
                "Muppet",
                "Dimwit",
                "Pikey",
                "Pillock",
                "Plonker",
                "Prat",
                "Scrubber",
                "Trollop",
                "Twit",
                "Knob Head",
                "Dickhead",
                "Bell End",
                "Lazy Sod",
                "Useless idiot",
                "Knob",
                "Wazzock",
                "Ninny",
                "Berk",
                "Arse-licker",
                "Arsemonger",
                "Mingebag",
                "Plug-Ugly"
            };

            return insults[new Random().Next(0, insults.Length)];
        }
    }
}