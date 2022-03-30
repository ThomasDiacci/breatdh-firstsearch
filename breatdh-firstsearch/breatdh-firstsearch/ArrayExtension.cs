using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breatdh_firstsearch
{
    public static class ArrayExtension
    {
        public static string[] EnqueueDataToArray(this string[] originalArray, string[] dataToAdd)
        {
            var result = new string[originalArray.Length + dataToAdd.Length];

            var count = 0;
            for (var i = 0; i < originalArray.Length; i++)
            {
                if (count == dataToAdd.Length)
                {
                    return result;
                }

                if (string.IsNullOrWhiteSpace(originalArray[i]))
                {
                    result[i] = dataToAdd[count];

                    count++;
                }
            }

            return result;
        }
    }
}
