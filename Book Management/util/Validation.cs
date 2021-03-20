using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Book_Management.util
{
    class Validation
    {
        public int GetInt(string mgs, int min, int max)
        {
            while (true)
            {
                Console.WriteLine(mgs);

                try
                {
                    int result = Int32.Parse(Console.ReadLine());
                    if ((result) >= min || result <= max) return result;
                        
                }
                catch (Exception)
                {
                    Console.WriteLine("Input must an integer from {0} to {1}", min, max);
                }
                
            }
        }

        public string GetString(string mgs)
        {
            while (true)
            {
                Console.WriteLine(mgs);

                string input = Console.ReadLine();

                if(Regex.IsMatch(input, @"[a-zA-Z]"))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Input must be an string!");
                }
            }
        }
    }
}
