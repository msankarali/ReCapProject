using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        /// <summary>
        /// null if no error
        /// </summary>
        /// <param name="rules"></param>
        /// <returns>IResult</returns>
        public static IResult Run(params IResult[] rules)
        {
            foreach (var rule in rules)
            {
                if (!rule.Success)
                {
                    return rule;
                }
            }
            return null;
        }

        /// <summary>
        /// return null if no error
        /// </summary>
        /// <param name="rules"></param>
        /// <returns></returns>
        public static List<IResult> RunRules(params IResult[] rules)
        {
            var businessRules = new List<IResult>();

            foreach (var rule in rules)
            {
                if (!rule.Success)
                {
                    businessRules.Add(rule);
                }
            }

            return businessRules;
        }

    }
}
