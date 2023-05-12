using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp6
{
    class Metro : PublicTransport
    {
        public double TrackWidth { get; set; }

        public string BranchName { get; set; }

        public override string MoveToNextStop()
        {
            return Start() + ". Metro tram arrived at the next station." + Stop();
        }

        public override string LoadPassengers(int count)
        {
            int passengersBeforeLoading = CountPassengers;
            base.LoadPassengers(count);
            return string.Format("Loading {0} passengers to the metro", CountPassengers - passengersBeforeLoading);
        }

        public override string UnloadPassengers(int count)
        {
            int passengersBeforeUnloading = CountPassengers;
            base.UnloadPassengers(count);
            return string.Format("Unloading {0} passengers to the metro", passengersBeforeUnloading - CountPassengers);
        }

        public override string Start()
        {
            return "The metro started moving";
        }

        public override string Stop()
        {
            return "The metro stopped";
        }

        public string DoHorn()
        {
            return "Hooooorn!";
        }

        public string StopAtTerminalStation()
        {
            return Start() + ". Metro stopped at the terminal station." + Stop();
        }

        public override string GetInfo()
        {
            return "Metro\n" + base.GetInfo() + "Branch name:" + BranchName + ", Track width" + TrackWidth;
        }
    }
}
