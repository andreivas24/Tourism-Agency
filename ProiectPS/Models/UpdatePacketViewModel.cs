namespace ProiectPS.Models
{
    public class UpdatePacketViewModel
    {
        public Guid Id { get; set; }
        public string Destination { get; set; }
        public int Price { get; set; }
        public DateTime StartPeriodOfTime { get; set; }
        public DateTime EndPeriodOfTime { get; set; }
    }
}
