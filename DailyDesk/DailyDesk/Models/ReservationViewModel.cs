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
    }
}
