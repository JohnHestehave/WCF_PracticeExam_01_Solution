using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfAuctionHouse
{
	[DataContract]
    public class Item
    {
		public static List<Item> Items = new List<Item>() {
			new Item(5, "Dør", 100m, 20m, "John", "12345678", new DateTime(2017, 12, 07, 12, 12, 12)),
			new Item(10, "Vindue", 200m, 50m, "John", "12345678", new DateTime(2017, 12, 07, 22, 22, 22))
		};

		[DataMember]
		public int ItemNumber { get; set; }
		[DataMember]
		public string ItemDescription { get; set; }
		[DataMember]
		public decimal RatingPrice { get; set; }
		[DataMember]
		public decimal BidPrice { get; set; }
		[DataMember]
		public string BidCustomName { get; set; }
		[DataMember]
		public string BidCustomPhone { get; set; }
		[DataMember]
		public DateTime BidTimestamp { get; set; }

		private Item(int a, string b, decimal c, decimal d, string e, string f, DateTime g)
		{
			ItemNumber = a;
			ItemDescription = b;
			RatingPrice = c;
			BidPrice = d;
			BidCustomName = e;
			BidCustomPhone = f;
			BidTimestamp = g;
		}
    }
}