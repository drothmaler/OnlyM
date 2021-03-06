namespace OnlyMSlideManager.ViewModel
{
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;
    using OnlyM.CoreSys.Services.Snackbar;
    using OnlyM.CoreSys.Services.UI;
    using OnlyMSlideManager.Services;
    using OnlyMSlideManager.Services.DragAndDrop;
    using OnlyMSlideManager.Services.Options;

    internal class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ShouldSaveViewModel>();

            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<IDragAndDropServiceCustom, DragAndDropServiceCustom>();
            SimpleIoc.Default.Register<ISnackbarService, SnackbarService>();
            SimpleIoc.Default.Register<IUserInterfaceService, UserInterfaceService>();
            SimpleIoc.Default.Register<IOptionsService, OptionsService>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public ShouldSaveViewModel ShouldSaveDialog => ServiceLocator.Current.GetInstance<ShouldSaveViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}