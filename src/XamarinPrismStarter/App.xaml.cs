using XamarinPrismStarter.Views;
using Prism.Unity;
using Xamarin.Forms;

namespace XamarinPrismStarter
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer platform = null) : base(platform) { }

		protected override void OnInitialized()
		{
			InitializeComponent();

			NavigationService.NavigateAsync("MasterDetailHomePage/NavigationPage/HomePage", animated: false);
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<MasterDetailHomePage>();
			Container.RegisterTypeForNavigation<NavigationPage>();
			Container.RegisterTypeForNavigation<HomePage>();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
