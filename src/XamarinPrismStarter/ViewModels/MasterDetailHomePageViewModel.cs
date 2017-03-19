using System.Collections.ObjectModel;
using Prism.Navigation;

namespace XamarinPrismStarter.ViewModels
{
	public class MasterDetailHomePageViewModel : _BaseViewModel
	{
		private ObservableCollection<MenuItem> _menu;
		public ObservableCollection<MenuItem> Menu
		{
			get { return this._menu; }
			set { SetProperty(ref _menu, value); }
		}

		private MenuItem _selected;
		public MenuItem Selected
		{
			get { return this._selected; }
			set
			{
				if (this._selected != value)
				{
					SetProperty(ref _selected, value);
					this.SelectedItem(value);
				}
			}
		}

		private readonly INavigationService _navigationService;
		public MasterDetailHomePageViewModel(INavigationService navigationService)
		{
			this._navigationService = navigationService;

			this.Menu = new ObservableCollection<MenuItem>();

			for (var i = 0; i < 3; i++)
			{
				this.Menu.Add(new MenuItem { Text = $"Menu Item {i}", ViewDestination = "HomePage", Parameters = $"{i}" });
			}
			this.Menu.Add(new MenuItem { Text = $"Batman", ViewDestination = "Page1", Parameters = "" });
			this.Menu.Add(new MenuItem { Text = $"Xamarin Data Page", ViewDestination = "XamarinDataPage", Parameters = "" });
			this.Menu.Add(new MenuItem { Text = $"Feed", ViewDestination = "FeedPage", Parameters = "" });
		}

		void SelectedItem(MenuItem item)
		{
			if (string.IsNullOrEmpty(item.Parameters))
			{
				this._navigationService.NavigateAsync($"NavigationPage/{item.ViewDestination}");
			}
			else
			{
				this._navigationService.NavigateAsync($"NavigationPage/{item.ViewDestination}?id={item.Parameters}");
				//this._navigationService.NavigateAsync($"{item.ViewDestination}?id={item.Parameters}");
			}
		}
	}

	public class MenuItem
	{
		public string Text { get; set; }
		public string ViewDestination { get; set; }
		public string Parameters { get; set; } = null;
	}
}
