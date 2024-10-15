using Logic.Models;
using Logic.DTO;
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

        public Reservation GetReservationById(int? reservationId)
        {

            ReservationDto reservationDto = _reservationRepo.GetReservationDtoById(reservationId.Value);         

            return new Reservation(reservationDto);
        }

        public List<Reservation> GetAllReservations()
        {

            List<ReservationDto> reservations = _reservationRepo.GetAllReservations();
            return Reservation.ConvertToReservations(reservations);
        }

        public void AddReservation(Reservation reservationToAdd)
        {

            ReservationDto reservationDto = new ReservationDto(reservationToAdd);
            _reservationRepo.AddReservationDto(reservationDto);
        }
    }
}
