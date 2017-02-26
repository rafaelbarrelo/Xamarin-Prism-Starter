using System;
using System.Collections.Generic;
using Prism.Navigation;
using Xamarin.Forms;

namespace XamarinPrismStarter.Views
{
	public partial class MasterDetailHomePage : MasterDetailPage, IMasterDetailPageOptions
	{
		public MasterDetailHomePage()
		{
			InitializeComponent();
		}

		public bool IsPresentedAfterNavigation => false;
	}
}
