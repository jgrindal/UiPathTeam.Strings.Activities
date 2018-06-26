using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiPathTeam.ClosestString
{
    interface IDistanceEngine
    {
        void SetBaseString(String baseString);
        Int32 Distance(String compareString);
    }
}
