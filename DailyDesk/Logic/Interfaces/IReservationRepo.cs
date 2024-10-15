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
        List<ReservationDto> GetAllReservations();

        void AddReservationDto(ReservationDto reservationToAdd);
    }
}
