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

        public ReservationDto() { }

        public ReservationDto(Reservation reservation)
        {
            Id = reservation.Id;
            Title = reservation.Title;
            Capacity = reservation.Capacity;
            StartDate = reservation.StartDate;
            EndDate = reservation.EndDate;
        }
    }
}
