using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiPathTeam.StringActivities.StringDistanceEngines
{
    public class LevenshteinEngine : IDistanceEngine
    {
        // TODO: CONTRACT - make inheirited class.
        private string storedValue;
        private int[] costs;

        /// <summary>
        /// Creates a new instance with base string value
        /// </summary>
        /// <param Name="value">Base string value.</param>
        public LevenshteinEngine(string value)
        {
            SetBaseString(value);
        }

        /// <summary>
        /// Compares a value to the stored value. 
        /// </summary>
        /// <returns>Difference. 0 complete match.</returns>
        public int Distance(string value)
        {
            // TODO: Investigate thread safety in this
            if (costs.Length == 0)
            {
                return value.Length;
            }

            // Add indexing for insertion to first row
            for (int i = 0; i < this.costs.Length;)
            {
                this.costs[i] = ++i;
            }

            for (int i = 0; i < value.Length; i++)
            {
                // cost of the first index
                int cost = i;
                int additionCost = i;

                // cache value for inner loop to avoid index lookup and bounds checking
                char value1Char = value[i];

                for (int j = 0; j < this.storedValue.Length; j++)
                {
                    int insertionCost = cost;
               
                    cost = additionCost;
                    additionCost = this.costs[j];
                    if (value1Char != this.storedValue[j])
                    {
                        if (insertionCost < cost)
                        {
                            cost = insertionCost;
                        }

                        if (additionCost < cost)
                        {
                            cost = additionCost;
                        }

                        cost++;
                    }
                    this.costs[j] = cost;
                }
            }
            return this.costs[this.costs.Length - 1];
        }

        public void SetBaseString(string baseString)
        {
            this.storedValue = baseString;
            // Create matrix row
            this.costs = new int[this.storedValue.Length];
        }
    }
}
