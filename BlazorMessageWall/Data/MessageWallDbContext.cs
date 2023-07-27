using BlazorMessageWall.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BlazorMessageWall.Data
{
	public class MessageWallDbContext : DbContext
	{
		public MessageWallDbContext(DbContextOptions<MessageWallDbContext> options) : base(options)
		{
		}
		public DbSet<PersonModel> People { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PersonModel>().HasData(
				new PersonModel { Id = 1, FirstName = "Mattias", LastName = "Gabriel", Email = "", PhoneNumber = "", Message="" },
				new PersonModel { Id = 2, FirstName = "Joanna", LastName = "Gabriel", Email = "", PhoneNumber = "", Message = "" }
			);
		}
	}
}
