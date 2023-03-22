using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProiectPS.Models.Domain;
using ProiectPS.Models.Persistence;
using static ProiectPS.Presenter.ClientPresenter;

namespace ProiectPS.Presenter
{
	public class EmployeePresenter : ClientPresenter
	{
		private PacketPersistence pp;
		private PacketPersistence packetView;
        private UserPersistence user;
        private PacketPersistence userView;

        public EmployeePresenter(Model model, View view) : base(model, view)
        {
        }

        public void AddPacket(Packet packet_info)
		{
			pp.AddPacket(packet_info);
			packetView.DisplaySucces();
		}

		public void UpdatePacket(Packet packet_info)
		{
			pp.UpdatePacket(packet_info);
			packetView.DisplaySucces();
            packetView.DisplayError();
        }

		public void DeletePacket(Packet packet_info)
		{
			pp.DeletePacket(packet_info);
            packetView.DisplaySucces();
            packetView.DisplayError();
        }

		public List<User> GetUsers()
		{
			List<User> users = user.GetUsers();
			return userView.DisplayUsers(users);
		}

		public void UpdateUser(User Username)
		{
			user.UpdateUser(Username);
            user.DisplaySuccess();
            user.DisplayError();
        }

		public void DeleteUser(User Username)
		{
			user.DeleteUser(Username);
			user.DisplaySuccess();
			user.DisplayError();
			
		}
	}
}

