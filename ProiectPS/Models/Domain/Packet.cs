using ProiectPS.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace ProiectPS.Models.Domain
{
	public class Packet
	{
		public Guid Id { get; set; }
		public string Destination { get; set; }
		public int Price { get; set; }
		public DateTime StartPeriodOfTime { get; set; }
		public DateTime EndPeriodOfTime { get; set; }

	}

}

