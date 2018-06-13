using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiPathTeam.StringActivities.StringDistanceEngines
{
    public interface IDistanceEngine
    {
        void SetBaseString(String baseString);
        int Distance(String compareString);
    }
}
