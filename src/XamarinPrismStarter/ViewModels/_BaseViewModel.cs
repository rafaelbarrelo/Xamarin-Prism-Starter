using System;
using Prism.Mvvm;

namespace XamarinPrismStarter.ViewModels
{
	public class _BaseViewModel: BindableBase
	{
		private string _title;
		public string Title
		{
			get { return this._title; }
			set { SetProperty(ref _title, value); }
		}

		public _BaseViewModel()
		{
			this.Title = "Xamarin Prism Starter";
		}
	}
}
