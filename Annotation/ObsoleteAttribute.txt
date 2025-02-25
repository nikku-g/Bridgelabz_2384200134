using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    public class LegacyAPI
    {
        // Used Obsolete method
        [Obsolete("Use NewMethod instead", true)]
        public void OldFeature()
        {
            Console.WriteLine("This will not be used anymore");
        }

        // Used NewMethod instead of OldMethod
        public void NewFeature()
        {
            Console.WriteLine("This will be used from now");

        }

    public class Program
    {
        public static void Main(String[] args)
        {
            // Instantiate LegacyAPI and called both methods()
            LegacyAPI legacy = new LegacyAPI();
            legacy.OldFeature(); // Compile time error
            legacy.NewFeature(); // This will work
            }
        }
    }
}