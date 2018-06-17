using FFImageLoading;
using Prism;
using Prism.Autofac;
using Prism.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsPrismSvgSample.ViewModels;
using XamarinFormsPrismSvgSample.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace XamarinFormsPrismSvgSample
{
    public partial class App : PrismApplication
    {
        public App()
            : this(null)
        {

        }

        public App(IPlatformInitializer initializer)
                    : base(initializer)
        {
            ImageService.Instance.Initialize(new FFImageLoading.Config.Configuration()
            {
                VerboseLogging = false,
                VerbosePerformanceLogging = false,
                VerboseMemoryCacheLogging = false,
                VerboseLoadingCancelledLogging = false,
                Logger = new ImageServiceDebugLogger(),
            });
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("Nav/Sample");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>("Nav");
            containerRegistry.RegisterForNavigation<SampleView, SampleViewModel>("Sample");
        }
    }

    public class ImageServiceDebugLogger : FFImageLoading.Helpers.IMiniLogger
    {
        public void Debug(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        public void Error(string errorMessage)
        {
            System.Diagnostics.Debug.WriteLine(errorMessage);
        }

        public void Error(string errorMessage, Exception ex)
        {
            throw ex;
        }
    }
}
