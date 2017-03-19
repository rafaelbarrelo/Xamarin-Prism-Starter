using System;
namespace XamarinPrismStarter.Models
{
	public class FeedItem
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Header { get; set; }

		public string Description { get; set; }

		public string ImageUrl { get; set; }

		public Uri Link { get; set; }

		public DateTime PubDate { get; set; }
	}
}
