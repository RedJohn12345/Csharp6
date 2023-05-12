using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp6
{
   
    class Bus : PublicTransport
    {
        public double FielConsumption { get; set; }

        public string Number { get; set; }
        public override string MoveToNextStop()
        {
            return Start() + ". Bus tram arrived at the next stop." + Stop();
        }

        public override string LoadPassengers(int count)
        {
            int passengersBeforeLoading = CountPassengers;
            base.LoadPassengers(count);
            return string.Format("Loading {0} passengers to the bus", CountPassengers - passengersBeforeLoading);
        }

        public override string UnloadPassengers(int count)
        {
            int passengersBeforeUnloading = CountPassengers;
            base.UnloadPassengers(count);
            return string.Format("Unloading {0} passengers to the bus", passengersBeforeUnloading - CountPassengers);
        }

        public override string Start()
        {
            return "The bus started moving";
        }

        public override string Stop()
        {
            return "The bus stopped";
        }

        public string DoBeepBeep()
        {
            return "Beep-beep!";
        }
        public string Park()
        {
            return Start() + ". Bus is parked in the parking lot." + Stop();
        }

        public override string GetInfo()
        {
            return "Bus\n" + base.GetInfo() + "Number:" + Number + ", FielConsumption" + FielConsumption;
        }

    }
}
