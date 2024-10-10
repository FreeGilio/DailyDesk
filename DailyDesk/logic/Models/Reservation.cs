using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Reservation
    {
        private int Id { get; set; }
        public string? Title { get; private set; }
        public int Capacity { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }
}