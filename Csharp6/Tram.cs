using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp6
{
    class Tram : PublicTransport
    {
        public int NumberOfWagons { get; set; }
        public double ElectricityConsumption { get; set; }
        

        public override string MoveToNextStop()
        {
            return Start() + ". Tram arrived at the next stop." + Stop();
        }

        public override string LoadPassengers(int count)
        {
            int passengersBeforeLoading = CountPassengers; 
            base.LoadPassengers(count);
            return string.Format("Loading {0} passengers to the tram", CountPassengers - passengersBeforeLoading);
        }

        public override string UnloadPassengers(int count)
        {
            int passengersBeforeUnloading = CountPassengers;
            base.UnloadPassengers(count);
            return string.Format("Unloading {0} passengers to the tram", passengersBeforeUnloading - CountPassengers);
        }

        public override string Start()
        {
            return "The tram started moving";
        }

        public override string Stop()
        {
            return "The tram stopped";
        }

        public string RingTheBell()
        {
            return "Ding-ding!";
        }

        public string StopAtTheDepot()
        {
            return Start() + ". Tram arrived at the depot." + Stop();
        }

        public override string GetInfo()
        {
            return "Tram\n" + base.GetInfo() + "Number of wagons: " + NumberOfWagons +
                ", ElectricityConsumption" + ElectricityConsumption;
        }
    }
}
