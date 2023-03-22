using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Moq;
using NuGet.ContentModel;
using NUnit.Framework;
using ProiectPS.Data;
using ProiectPS.Models.Domain;

namespace ProiectPS.Tests
{
	public class PacketModelTesting
	{
		/*[Test]
		public void AddPacket_AddsPacketToDatabase()
		{
			// Arrange
			var mockDbContext = new Mock<MVCDemoDbContext>();
			var packet = new Packet { Destination = "Maldive", Price = 2000, StartPeriodOfTime = new DateTime(2021, 07, 20), EndPeriodOfTime = new DateTime(2021, 07, 22) };
			mockDbContext.Setup(c => c.Packets.Add(packet));


			var model = new YourModel(mockDbContext.Object);

			// Act
			model.AddPacket(packet);

			// Assert
			mockDbContext.Verify(c => c.SaveChanges(), Times.Once);
		}

		[Test]
		public void UpdatePacket_UpdatesPacketInDatabase()
		{
			// Arrange
			var mockDbContext = new Mock<MVCDemoDbContext>();
			var packet = new Packet { Id = 1, Destination = "Maldive", Price = 2000, StartPeriodOfTime = new DateTime(2021, 07, 20), EndPeriodOfTime = new DateTime(2021, 07, 22) };
			var updatedPacket = new Packet { Id = 1, Destination = "Maldive", Price = 2000, StartPeriodOfTime = new DateTime(2021, 07, 20), EndPeriodOfTime = new DateTime(2021, 07, 23) };
			mockDbContext.Setup(c => c.Packets.Find(packet.Id)).Returns(packet);

			var model = new YourModel(mockDbContext.Object);

			// Act
			model.UpdateUser(updatedPacket);

			// Assert
			mockDbContext.Verify(c => c.SaveChanges(), Times.Once);
			Assert.AreEqual("Maldive", packet.Destination);
			Assert.AreEqual(2000, packet.Price);
			Assert.AreEqual(new DateTime(2021, 07, 20), packet.StartPeriodOfTime);
			Assert.AreEqual(new DateTime(2021, 07, 23), packet.EndPeriodOfTime);
		}

		[Test]
		public void DeletePacket_DeletesPacketFromDatabase()
		{
			// Arrange
			var mockDbContext = new Mock<MVCDemoDbContext>();
			var packet = new Packet
			{
				Id = 1,
				Destination = "Maldive",
				Price = 2000,
				StartPeriodOfTime = new DateTime(2021, 07, 20),
				EndPeriodOfTime = new DateTime(2021, 07, 22),
			};
			mockDbContext.Setup(c => c.Packets.Find(packet.Id)).Returns(packet);

			var model = new YourModel(mockDbContext.Object);

			// Act
			model.DeleteUser(packet.Id);

			// Assert
			mockDbContext.Verify(c => c.Packets.Remove(packet), Times.Once);
			mockDbContext.Verify(c => c.SaveChanges(), Times.Once);
		}

		[Test]
		public void GetPackets_ReturnsAllPacketsFromDatabase()
		{
			// Arrange
			var dbContextOptions = new DbContextOptionsBuilder<MVCDemoDbContext>()
				.UseInMemoryDatabase(databaseName: "TestDatabase")
				.Options;

			using (var context = new MVCDemoDbContext(dbContextOptions))
			{
				var packet1 = new Packet { Id = 1, Destination = "Paris", Price = 100, StartPeriodOfTime = new DateTime(2023, 4, 1), EndPeriodOfTime = new DateTime(2023, 4, 10) };
				var packet2 = new Packet { Id = 2, Destination = "London", Price = 200, StartPeriodOfTime = new DateTime(2023, 5, 1), EndPeriodOfTime = new DateTime(2023, 5, 10) };

				context.Packets.AddRange(packet1, packet2);
				context.SaveChanges();
			}

			var model = new PacketModel(new MVCDemoDbContext(dbContextOptions));

			// Act
			var result = model.GetPackets();

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.Count, Is.EqualTo(2));
			Assert.That(result[0].Id, Is.EqualTo(1));
			Assert.That(result[0].Destination, Is.EqualTo("Paris"));
			Assert.That(result[0].Price, Is.EqualTo(100));
			Assert.That(result[0].StartPeriodOfTime, Is.EqualTo(new DateTime(2023, 4, 1)));
			Assert.That(result[0].EndPeriodOfTime, Is.EqualTo(new DateTime(2023, 4, 10)));
			Assert.That(result[1].Id, Is.EqualTo(2));
			Assert.That(result[1].Destination, Is.EqualTo("London"));
			Assert.That(result[1].Price, Is.EqualTo(200));
			Assert.That(result[1].StartPeriodOfTime, Is.EqualTo(new DateTime(2023, 5, 1)));
			Assert.That(result[1].EndPeriodOfTime, Is.EqualTo(new DateTime(2023, 5, 10)));
		}


		[Test]
		public void FilterUsers_ReturnsFilteredUsers()
		{
			// Arrange
			var mockDbContext = new Mock<MVCDemoDbContext>();
			var filter = "john";
			var priceFilter = 100;
			var periodFilter = DateTime.Now;
			var users = new List<User>
			{
				new User { Username = "john", Password = "password1", Email = "john@example.com", Phone = "1234567890", Price = 100, PeriodOfTime = DateTime.Now },
				new User { Username = "jane", Password = "password2", Email = "jane@example.com", Phone = "2345678901", Price = 200, PeriodOfTime = DateTime.Now.AddDays(1) },
				new User { Username = "jack", Password = "password3", Email = "jack@example.com", Phone = "3456789012", Price = 300, PeriodOfTime = DateTime.Now.AddDays(2) }
			};
			mockDbContext.Setup(c => c.Users).ReturnsDbSet(users);

			var model = new YourModel(mockDbContext.Object);

			// Act
			var filteredUsers = model.FilterUsers(filter, priceFilter, periodFilter);

			// Assert
			Assert.AreEqual(1, filteredUsers.Count);
			Assert.AreEqual("john", filteredUsers[0].Username);
		}*/

	}
}
