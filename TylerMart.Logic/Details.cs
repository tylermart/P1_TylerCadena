using System.Collections.Generic;

using TylerMart.Storage.Models;
using TylerMart.Storage.Repositories;

namespace TylerMart.Logic {
	public static class Details {
		public static string OrderDetail(int orderID, RepositoryCollection rc) {
			Order order = rc.Orders.Get(orderID);
			if (order == null) {
				return "";
			}
			string result = "";
			result += "[Order]\n";
			result += $"ID = {order.OrderID}\n";
			result += $"Date = {order.PlacedAt.ToLongDateString()}\n";
			result += $"Completed = {order.Completed}\n";
			result += $"Customer = {order.Customer.FirstName} {order.Customer.LastName}\n";
			result += $"Location = {order.Location.Name}";
			result += $"[Products]";
			List<Product> products = rc.Products.FindFromOrder(order);
			int it = 1;
			foreach (var p in products) {
				result += $"{it} = {p.Name}";
				++it;
			}
			return result;
		}
	}
}