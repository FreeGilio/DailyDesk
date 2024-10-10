using Logic.Models;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class ReservationService
    {

        private readonly IReservationRepo _reservationRepo;

        public ReservationService(IReservationRepo reservationRepo)
        {
            this._reservationRepo = reservationRepo;
        }

        public List<Reservation> GetAllReservations()
        {

            List<Reservation> reservations = _reservationRepo.GetAllReservations();
            return reservations;
            //try
            //{
               
            //}
            //catch (Exception ex)
            //{
            //    Logger.LogError("Error getting all reservations", ex);
            //    throw;
            //}
        }
    }
}
