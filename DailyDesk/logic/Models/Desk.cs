using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Desk
    {
        private int Id { get; set; }
        private int Workplaceid { get; set; }
        public double XCoordinate { get; private set; }
        public double YCoordinate { get; private set; }
        public int Screens { get; private set; }
        public int Adjustable { get; private set; }
        public bool Occupied { get; private set; }
    }
}
