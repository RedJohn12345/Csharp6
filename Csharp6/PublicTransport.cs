using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp6
{
    abstract class PublicTransport : ITransport
    {
        public double MaxSpeed { get; set; }
        public int Capacity { get; set; }
        public int NumberOfStops { get; set; }
        public string CompanyName { get; set; }

        public int CountPassengers { get; set; }

        public virtual string LoadPassengers(int count)
        {
            if (CountPassengers + count >= Capacity)
            {
                CountPassengers = Capacity;
            }
            else
            {
                CountPassengers += count;
            }

            return "";
        }
        public virtual string UnloadPassengers(int count)
        {
            if (CountPassengers - count <= 0)
            {
                CountPassengers = 0;
            }
            else
            {
                CountPassengers -= count;
            }

            return "";
        }
        public abstract string MoveToNextStop();
        public abstract string Start();
        public abstract string Stop();

        public virtual string GetInfo()
        {
            return "Max speed: " + MaxSpeed + ", Capacity: " + Capacity + ", Number of stops: " + NumberOfStops +
                "\nCompany name: " + CompanyName + ", Count passengers: " + CountPassengers + "\n";
        }
    }
}
