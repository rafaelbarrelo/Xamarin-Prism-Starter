using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XamarinPrismStarter.Models
{

	public static class RssParser
	{
		public const string MessageName = "FeedItens";

		// Parse the xml using XMLDocument class.
		public static async Task GetFeeds(List<FeedHeader> source)
		{
			int i = 0;
			var haberDetayList = new List<FeedItem>();
			try
			{
				foreach (FeedHeader item in source)
				{
					var webClient = new HttpClient();

					try
					{
						string result = await webClient.GetStringAsync(item.Url);

						await Task.Factory.StartNew(() =>
						{
							try
							{
								XDocument document = XDocument.Parse(result);

								XNamespace media = "http://search.yahoo.com/mrss/";

								var temp = ((from u in document.Descendants("item")
											 select new FeedItem()
											 {
												 Id = i++,
												 Header = item.Header,
												 Title = u.Element("title").Value,
												 Description = u.Element("description").Value,
												 Link = new Uri(u.Element("link").Value),
									ImageUrl = u.Element(media + "content").Attribute("url").Value,
												 PubDate = TryDateTime(u.Element("pubDate").Value)

											 }).ToList());

								haberDetayList.AddRange(temp);
							}
							catch
							{

							}
						});
					}
					catch
					{
						continue;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			MessagingCenter.Send(haberDetayList, MessageName);
		}

		static DateTime TryDateTime(string value)
		{
			var dt = DateTime.UtcNow;
			DateTime.TryParse(value, out dt);
			return dt;
		}
	}
}