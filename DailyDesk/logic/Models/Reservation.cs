using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Logic.DTO;

namespace Logic.Models
{
    public class Reservation
    {
        public int Id { get;  set; }
        public string? Title { get; set; }
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> Usernames { get; set; } = new List<string>();

        public Reservation() { }

        public Reservation(int id, string? title, int capacity, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Title = title;
            Capacity = capacity;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Reservation(ReservationDto reservationDto)
        {
            Id= reservationDto.Id;
            Title = reservationDto.Title;
            Capacity = reservationDto.Capacity;
            StartDate = reservationDto.StartDate;
            EndDate = reservationDto.EndDate;
            Usernames = reservationDto.Usernames ?? new List<string>();
        }

        public static List<Reservation> ConvertToReservations(List<ReservationDto> reservationDtos)
        {

            List<Reservation> reservations = new List<Reservation>();

            try
            {
                foreach (ReservationDto reservationDto in reservationDtos)
                {
                    reservations.Add(new Reservation(reservationDto));
                }
            }
            catch (Exception ex)
            {

            }


            return reservations;
        }
    }
}