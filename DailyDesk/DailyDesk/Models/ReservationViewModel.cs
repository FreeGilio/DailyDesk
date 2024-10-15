using Logic.Models;

namespace DailyDesk.Models
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Capacity { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public Reservation CreateModel()
        {
            DateTime startDate = StartDate.ToDateTime(StartTime);
            DateTime endDate = EndDate.ToDateTime(EndTime);
            Reservation reservation = new Reservation(Id, Title, Capacity, startDate, endDate);
            return reservation;
        }
    }
}
