using Prism.Commands;
using Prism.Mvvm;

namespace XamarinFormsPrismSvgSample.ViewModels
{
    public class SampleViewModel : BindableBase
    {
        public string WelcomeMessage { get; set; } = "HelloWorld";

        public DelegateCommand SayWhatsAppleCommand { get; set; }

        public SampleViewModel()
        {
            SayWhatsAppleCommand = new DelegateCommand(() =>
            {
                WelcomeMessage = "Apple is a fruit!";
            });
        }
    }
}
