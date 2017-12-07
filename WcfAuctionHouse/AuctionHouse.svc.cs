using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfAuctionHouse
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class AuctionHouse : IAuctionHouse
	{
		private static object _lock = new object();
		public List<Item> GetAllAuctionItems()
		{
			return Item.Items;
		}

		public Item GetAuctionItem(int ItemNumber)
		{
			return Item.Items.Find(x=>x.ItemNumber == ItemNumber);
		}

		public bool Bid(Bid bid)
		{
			lock (_lock)
			{
				var item = Item.Items.Find(x => x.ItemNumber == bid.ItemNumber);
				if (bid.Price > item.BidPrice)
				{
					item.BidPrice = bid.Price;
					item.BidCustomName = bid.CustomName;
					item.BidCustomPhone = bid.CustomPhone;
					item.BidTimestamp = DateTime.Now;
					return true;
				}
				return false;
			}
		}
	}
}
