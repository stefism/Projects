using A1TicketSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A1TicketSystem
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var db = new A1TicketSysyemContext();

			var user = await db.Users.FirstOrDefaultAsync();

			var ticket = await db.Tickets
				.Where(t => t.UserId == user.Id)
				.OrderByDescending(t => t.DateCreated)
				.FirstOrDefaultAsync();

			Console.WriteLine($"Ticket Id: {ticket.Id}");
			Console.WriteLine($"Date Created: {ticket.DateCreated}");
		}
	}
}
