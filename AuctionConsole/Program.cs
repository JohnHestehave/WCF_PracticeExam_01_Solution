using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionConsole
{
    class Program
    {
		private static AuctionService.IAuctionHouse client = new AuctionService.AuctionHouseClient();
		static void Main(string[] args)
        {
			Run();
        }

		static void Run()
		{
			Console.WriteLine("Commands:     get     getall     bid");
			while (true)
			{
				switch (Console.ReadLine())
				{
					case "getall":
						GetAll();
						break;
					case "get":
						Console.WriteLine("Enter Number:");
						int num = int.Parse(Console.ReadLine());
						GetItem(num);
						break;
					case "bid":
						Console.WriteLine("Enter ItemNumber:");
						int itemnum = int.Parse(Console.ReadLine());
						Console.WriteLine("Enter Price:");
						int itemprice = int.Parse(Console.ReadLine());
						Console.WriteLine("Enter Name:");
						string itemname = Console.ReadLine();
						Console.WriteLine("Enter Phone Nr:");
						string itemphone = Console.ReadLine();
						AuctionService.Bid bid = new AuctionService.Bid() { ItemNumber = itemnum, Price = itemprice, CustomName = itemname, CustomPhone = itemphone };
						MakeBid(bid);
						break;
					default:
						break;
				}
			}
		}

		static async void MakeBid(AuctionService.Bid bid)
		{
			bool ok = await client.BidAsync(bid);
			if (ok)
			{
				Console.WriteLine("Your bid is now the highest!");
			}
			else
			{
				Console.WriteLine("Your bid was too low.");
			}
		}
		static async void GetAll()
		{
			AuctionService.Item[] items = await client.GetAllAuctionItemsAsync();
			if (items.Length == 0) {
				Console.WriteLine("No Items found.");
				return;
			}
			foreach(var item in items)
			{
				Console.WriteLine("--------------");
				Console.WriteLine("Item Number: " + item.ItemNumber);
				Console.WriteLine("Item Description: " + item.ItemDescription);
				Console.WriteLine("Rating Price: " + item.RatingPrice);
				Console.WriteLine("Bid Price: " + item.BidPrice);
				Console.WriteLine("Bid Custom Name: " + item.BidCustomName);
				Console.WriteLine("Bid Custom Phone: " + item.BidCustomPhone);
				Console.WriteLine("Bid Timestamp: " + item.BidTimestamp);
			}
			Console.WriteLine("--------------");
		}
		static async void GetItem(int num)
		{
			AuctionService.Item item = await client.GetAuctionItemAsync(num);
			Console.WriteLine("--------------");
			Console.WriteLine("Item Number: " + item.ItemNumber);
			Console.WriteLine("Item Description: " + item.ItemDescription);
			Console.WriteLine("Rating Price: " + item.RatingPrice);
			Console.WriteLine("Bid Price: " + item.BidPrice);
			Console.WriteLine("Bid Custom Name: " + item.BidCustomName);
			Console.WriteLine("Bid Custom Phone: " + item.BidCustomPhone);
			Console.WriteLine("Bid Timestamp: " + item.BidTimestamp);
			Console.WriteLine("--------------");
		}
    }
}
