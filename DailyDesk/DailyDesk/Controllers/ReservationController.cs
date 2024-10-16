﻿using Microsoft.AspNetCore.Mvc;
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

        public ActionResult ReservationInfo(int id)
        {
            Reservation reservationModel = reservationService.GetReservationById(id);
            return View(reservationModel);
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
            Reservation reservationModel = newReservation.CreateModel();
            reservationService.AddReservation(reservationModel);
            return RedirectToAction("Index", "Reservation");

        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
