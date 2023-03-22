using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProiectPS.Models.Domain;
using ProiectPS.Models.Persistence;
using static ProiectPS.Presenter.EmployeePresenter;

namespace ProiectPS.Presenter
{
	public class AdminPresenter : EmployeePresenter
	{
		private UserPersistence user;
		private UserPersistence userView;

        public AdminPresenter(Model model, View view) : base(model, view)
        {
        }

        public User GetPendingUsers()
		{
			List<User> users = user.GetPendingUsers();
			return userView.DisplayPendingUsers(users);
		}

		public void ApproveUser(User Username)
		{
			bool success = user.ApproveUser(Username);
			if (success)
			{
				userView.DisplaySuccess(success);
			}
			else
			{
				userView.DisplayError(success);
			}
		}

		public void RejectUser(User Username)
		{
			bool success = user.RejectUser(Username);
			if (success)
			{
				userView.DisplaySuccess(success);
			}
			else
			{
				userView.DisplayError(success);
			}
		}
	}
}
