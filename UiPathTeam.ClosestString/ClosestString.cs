using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using UiPathTeam.Strings.StringDistanceEngines;

namespace UiPathTeam.Strings.ClosestString
{
    public class ClosestString : NativeActivity
    {
        // Base string to compare against
        [Category("Input")]
        [RequiredArgument]
        public InArgument<String> BaseString { get; set; }

        // Array of possible strings to compare against base string
        [Category("Input")]
        [RequiredArgument]
        public InArgument<String[]> Possibles { get; set; }

        // String value with the lowest distance
        [Category("Output")]
        public OutArgument<String> SelectedString { get; set; }
   
        // Distance from selected string
        [Category("Output")]
        public OutArgument<Int32> Distance { get; set; }

        /// <summary>
        /// Uses Levenshtein Distance to determine the closest string.  Outputs the string and the distance
        /// </summary>
        /// <param name="context"></param>
        protected override void Execute(NativeActivityContext context)
        {
            LevenshteinEngine engine = new LevenshteinEngine(BaseString.Get(context));
            Boolean first = true;

            foreach(String possible in Possibles.Get(context))
            {
                int currentDistance = engine.Distance(possible);

                if (currentDistance < Distance.Get(context) || first)
                {
                    Distance.Set(context, currentDistance);
                    SelectedString.Set(context, possible);
                }
                first = false;
            }
        }
    }
}
