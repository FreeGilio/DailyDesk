using Microsoft.AspNetCore.Mvc;
using Logic.Services;

namespace DailyDesk.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationService reservationService;
        public ReservationController(ReservationService reservationService) 
        { 
            this.reservationService = reservationService;
        }
        public IActionResult Index()
        {
            var reservations = reservationService.GetAllReservations();
            return View(reservations);
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}
