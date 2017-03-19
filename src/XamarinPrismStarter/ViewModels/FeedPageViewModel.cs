using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XamarinPrismStarter.Models;

namespace XamarinPrismStarter.ViewModels
{
	public class FeedPageViewModel : _BaseViewModel
	{
		private ObservableCollection<FeedItem> _feedItem;
		public ObservableCollection<FeedItem> FeedItem
		{
			get { return this._feedItem; }
			set { SetProperty(ref _feedItem, value); }
		}

		public FeedPageViewModel()
		{
			this.FeedItem = new ObservableCollection<FeedItem>();
			this.LoadFeeds();
		}

		private void LoadFeeds()
		{
			var feedList = new List<FeedHeader>();
			feedList.Add(new FeedHeader()
			{
				Url = "http://www.nytimes.com/services/xml/rss/nyt/International.xml",
				Header = "NY Times"
			});

			MessagingCenter.Subscribe<List<FeedItem>>(this, RssParser.MessageName, (list) =>
			{
				foreach (var item in list)
				{
					FeedItem.Add(item);
				}
			});

			RssParser.GetFeeds(feedList);
		}
	}
}
