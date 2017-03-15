using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;

namespace XamarinPrismStarter.ViewModels
{
	public class Page1ViewModel : _BaseViewModel
	{
		private string _text;
		public string Text
		{
			get
			{
				return this._text;
			}
			set
			{
				SetProperty(ref _text, value);
			}
		}

		public Page1ViewModel()
		{
			this.Text = "Pagina 1";
			this.Title = "Pagina 1 Title";
		}
	}
}
