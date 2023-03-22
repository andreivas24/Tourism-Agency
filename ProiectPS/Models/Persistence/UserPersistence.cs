using ProiectPS.Data;
using ProiectPS.Models.Domain;

namespace ProiectPS.Models.Persistence
{
    public class UserPersistence : User
    {
        private readonly MVCDemoDbContext _db;
        private bool IsAccepted;
        public User CreateUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            using (var db = _db)
            {
                var existingUser = db.Users.Find(user.Id);
                if (existingUser != null)
                {
                    //existingUser.Username = user.Username;
                    existingUser.Password = user.Password;
                    existingUser.Email = user.Email;
                    existingUser.Phone = user.Phone;

                    db.SaveChanges();
                }
            }
            return user;
        }

        public User DeleteUser(User user)
        {
            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
            return user;
        }

        public List<User> GetUsers()
        {
            using (var db = _db)
            {
                return db.Users.ToList();
            }
        }

        public User GetUserInfo(int userId)
        {
            using (var db = _db)
            {
                return db.Users.Find(userId);
            }
        }

        public List<User> GetPendingUsers()
        {
            using (var db = _db)
            {
                return db.Users.Where(u => u.IsAccepted == false).ToList();
            }
        }

        public bool ApproveUser(User user)
        {
            using (var db = _db)
            {
                var existingUser = db.Users.Find(user.Id);
                if (existingUser != null)
                {
                    existingUser.IsAccepted = true;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool RejectUser(User user)
        {
            using (var db = _db)
            {
                var existingUser = db.Users.Find(user.Id);
                if (existingUser != null)
                {
                    existingUser.IsAccepted = false;
                    db.SaveChanges();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        #region
        public void DisplaySuccess(bool isApproved)
        {
            if (isApproved)
            {
                Console.WriteLine("User approved successfully!");
            }
            else
            {
                Console.WriteLine("User approval failed.");
            }
        }

        public void DisplayError(bool isApproved)
        {
            if (isApproved)
            {
                Console.WriteLine("User approval failed");
            }
            else
            {
                Console.WriteLine("User approved successfully.");
            }
        }

        internal User DisplayPendingUsers(List<User> users)
        {
            throw new NotImplementedException();
        }

        internal void DisplaySuccess()
        {
            throw new NotImplementedException();
        }

        internal void DisplayError()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
