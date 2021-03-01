using System;

namespace TutorialCode.ViewModel.Umbraco
{
    public class CachingViewModel
    {
        public string Date { get; set; }
        public DateTime DateTwo { get; internal set; }
    }
}