using CanteenAIS_Models.Statics;

namespace CanteenAIS_ViewModel.StaticViewModels
{
    public static class ContentVM
    {
        public static string ContentText
        {
            get => Contents.Content;
        }

        public static string FormTitle
        {
            get => Contents.Title;
        }
    }
}
