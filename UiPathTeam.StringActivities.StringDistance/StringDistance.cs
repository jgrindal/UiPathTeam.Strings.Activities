using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using UiPathTeam.Strings.StringDistanceEngines;

namespace UiPathTeam.Strings.StringDistance
{
    public class StringDistance : CodeActivity
    {
        // Base string to compare against
        [Category("Input")]
        [RequiredArgument]
        public InArgument<String> BaseString { get; set; }

        // Array of possible strings to compare against base string
        [Category("Input")]
        [RequiredArgument]
        public InArgument<String> ComparisonString { get; set; }

        // Distance from selected string
        [Category("Output")]
        public OutArgument<Int32> Distance { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            IDistanceEngine engine = DistanceEngineFactory(BaseString.Get(context));
            Distance.Set(context, engine.Distance(ComparisonString.Get(context)));
        }

        /// <summary>
        /// Returns an IDistanceEngine appropriate to the activity
        /// </summary>
        /// <returns></returns>
        private IDistanceEngine DistanceEngineFactory(String baseString)
        {
            // TODO: Determine selection logic for algorithms
            return new LevenshteinEngine(baseString);
        }
    }

}

