using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10
{
    interface IStrengthParam
    {
        double GetInertiaMoment();
        double GetSectionModulus();
    }
}
