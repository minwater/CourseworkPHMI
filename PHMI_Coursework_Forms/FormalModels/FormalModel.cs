using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHMI_Coursework_Forms
{
    abstract class FormalModel
    {
        public abstract DialogStep CurrentStep { get; }
        public abstract void MakeStep(string response, out string error, out Dialog inner);
        public abstract void MoveNext();
    }
}
