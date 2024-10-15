using Microsoft.AspNetCore.Mvc;
using Logic.Services;
using Logic.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using DailyDesk.Models;

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
        public IActionResult GetReservations()
        {
            var reservations = reservationService.GetAllReservations();
            return View(new Reservation());
        }

        [HttpPost]
        public IActionResult AddReservation(ReservationViewModel newReservation)
        {
                
                //reservationService.AddReservation(reservationToBeAdded);
                return RedirectToAction("Index", "Reservation");
          
        }
    }
}
