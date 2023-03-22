using ProiectPS.Data;
using ProiectPS.Models.Domain;

namespace ProiectPS.Models.Persistence
{
    public class PacketPersistence : Packet
    {
        private readonly MVCDemoDbContext _db;
        public void AddPacket(Packet packet)
        {
            _db.Packets.Add(packet);
            _db.SaveChanges();
        }

        public Packet UpdatePacket(Packet packet)
        {
            using (var db = _db)
            {
                var existingPacket = db.Packets.Find(packet.Id);
                if (existingPacket != null)
                {
                    existingPacket.Destination = packet.Destination;
                    existingPacket.Price = packet.Price;
                    existingPacket.StartPeriodOfTime = packet.StartPeriodOfTime;
                    existingPacket.EndPeriodOfTime = packet.EndPeriodOfTime;

                    db.SaveChanges();
                }
            }
            return packet;
        }
        public Packet DeletePacket(Packet packet)
        {
            if (packet != null)
            {
                _db.Packets.Remove(packet);
                _db.SaveChanges();
            }
            return packet;
        }

        public List<Packet> GetPackets()
        {
            using (var db = _db)
            {
                return db.Packets.ToList();
            }
        }

        public List<Packet> FilterPackets(string filter, int? priceFilter = null, DateTime? periodFilter = null)
        {
            using (var db = _db)
            {
                var query = db.Packets.AsQueryable();

                if (!string.IsNullOrEmpty(filter))
                {
                    query = query.Where(p => p.Destination.Contains(filter));
                }

                if (priceFilter.HasValue)
                {
                    query = query.Where(u => u.Price == priceFilter.Value);
                }

                if (periodFilter.HasValue)
                {
                    query = query.Where(u => u.StartPeriodOfTime == periodFilter.Value);
                    query = query.Where(u => u.EndPeriodOfTime == periodFilter.Value);
                }

                return query.ToList();
            }
        }

        #region
        internal Packet DisplayFilteredPackets(List<Packet> packets)
        {
            throw new NotImplementedException();
        }

        internal Packet DisplayPackets(List<Packet> packets)
        {
            throw new NotImplementedException();
        }

        internal void DisplaySuccess(string v)
        {
            throw new NotImplementedException();
        }

        internal void DisplayError(string v)
        {
            throw new NotImplementedException();
        }

        internal void DisplaySucces(bool success)
        {
            throw new NotImplementedException();
        }

        internal User DisplayUserInfo(User user)
        {
            throw new NotImplementedException();
        }

        internal List<User> DisplayUsers(List<User> users)
        {
            throw new NotImplementedException();
        }

        internal void DisplaySucces()
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
