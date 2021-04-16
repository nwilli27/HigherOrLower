using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigherOrLower.Models
{
    /// <summary>
    /// Holds query options for a Turn
    /// 
    /// Author: Nolan Williams
    /// Date:   4/7/2021
    /// </summary>
    /// <seealso cref="WilliamsSalesRep.Models.QueryOptions{WilliamsSalesRep.Models.Sale}" />
    public class TurnQueryOptions : QueryOptions<Turn>
    {

        /// <summary>
        /// Appends Where & OrderBy clauses based on the given [builder].
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Sort(TurnGridBuilder builder)
        {
            
        }
    }
}
