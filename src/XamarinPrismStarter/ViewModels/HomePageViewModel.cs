using System;
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

		public HomePageViewModel()
		{
			this.Texto = "Xamarin Forms with Prism";
			//this.Title = "Home";
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
