using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProiectPS.Models.Domain;
using ProiectPS.Models.Persistence;

namespace ProiectPS.Presenter
{
	public class ClientPresenter
	{
		private Model models;
		private View views;
		private PacketPersistence pp;
		private PacketPersistence packetView;
		public ClientPresenter(Model model, View view)
		{
			models = model;
			views = view;
		}

		public Packet GetPackets(Packet TouristPacket)
		{
			List<Packet> packets = pp.GetPackets();
			return packetView.DisplayPackets(packets);
		}

		public Packet FilterPackets(string Filters, int priceFilter, DateTime periodFilter)
		{
			List<Packet> packets = pp.FilterPackets(Filters, priceFilter, periodFilter);
			return packetView.DisplayFilteredPackets(packets);
		}
	}
}
