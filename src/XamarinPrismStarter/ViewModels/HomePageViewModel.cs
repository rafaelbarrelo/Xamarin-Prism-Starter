using System;
using Prism.Commands;
using Prism.Navigation;

namespace XamarinPrismStarter.ViewModels
{
	public class HomePageViewModel : _BaseViewModel, INavigationAware
	{
		private string _texto;
		public string Texto
		{
			get
			{
				return this._texto;
			}
			set
			{
				SetProperty(ref _texto, value);
			}
		}

		public DelegateCommand ExecuteCommand { get; set; }

		private readonly INavigationService _navigationService;
		public HomePageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;

			this.Texto = "Xamarin Forms with Prism";

			this.ExecuteCommand = new DelegateCommand(Execute, () => true);
		}

		private void Execute()
		{
			_navigationService.NavigateAsync("Page1");
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
			
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			var id = string.Empty;
			if (parameters.ContainsKey("id"))
			{
				id = (string)parameters["id"];
			}

			this.Texto = $"{this.Texto} {id}";
		}
	}
}
