using Microsoft.AspNetCore.Mvc;
using Logic.Services;
using Logic.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [HttpGet]
        public IActionResult AddReservation()
        {
            var reservations = reservationService.GetAllReservations();
            return View(new Reservation());
        }

        [HttpPost]
        public IActionResult AddChar(Reservation reservationToBeAdded)
        {         
                reservationService.AddReservation(reservationToBeAdded);
                return RedirectToAction("Index", "Reservation");
          
        }
    }
}
