using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiPathTeam.ClosestString
{
    public class Levenshtein
    {
        // TODO: CONTRACT - make inheirited class.
        private readonly string storedValue;
        private readonly int[] costs;

        /// <summary>
        /// Creates a new instance with base string value
        /// </summary>
        /// <param Name="value">Base string value.</param>
        public Levenshtein(string value)
        {
            this.storedValue = value;
            // Create matrix row
            this.costs = new int[this.storedValue.Length];
        }

        /// <summary>
        /// Getter for length of the stored value
        /// </summary>
        public int StoredLength
        {
            get
            {
                return this.storedValue.Length;
            }
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
    }
}
