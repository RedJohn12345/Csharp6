using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp6
{
    interface ITransport
    {
        double MaxSpeed { get; set; }
        string Start();
        string Stop();

        string GetInfo();
    }
}
