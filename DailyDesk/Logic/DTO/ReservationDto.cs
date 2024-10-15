using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logic.Models;
using System.Threading.Tasks;

namespace Logic.DTO
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> Usernames { get; set; } = new List<string>(); // List of usernames

        public ReservationDto() { }

        public ReservationDto(Reservation reservation, List<string>? usernames = null)
        {
            Id = reservation.Id;
            Title = reservation.Title;
            Capacity = reservation.Capacity;
            StartDate = reservation.StartDate;
            EndDate = reservation.EndDate;

            // Initialize Usernames either from parameter or as an empty list
            Usernames = usernames ?? new List<string>();
        }
    }
}
