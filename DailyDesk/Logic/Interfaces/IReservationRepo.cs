using Logic.Models;
using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IReservationRepo
    {
        ReservationDto GetReservationDtoById(int reservationId);
        List<ReservationDto> GetAllReservations();

        void AddReservationDto(ReservationDto reservationToAdd);
    }
}
