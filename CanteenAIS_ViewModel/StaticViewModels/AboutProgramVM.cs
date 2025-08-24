using CanteenAIS_Models.Statics;

namespace CanteenAIS_ViewModel.StaticViewModels
{
    public static class AboutProgramVM
    {
        public static string AboutProgramText
        {
            get => AboutProgram.AboutText;
        }

        public static string Title
        {
            get => AboutProgram.FormTitle;
        }
    }
}
