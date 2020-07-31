using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        public bool ShouldTellIfNumbersAreTheSameSomething(int num1, int num2)
        {
            if (num1 == num2)
            {
                return true;
            }
            else return false;
        }

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");
            var lines = File.ReadAllLines(csvPath);
            logger.LogInfo($"Lines: {lines[0]}");
            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse).ToArray();

            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            //Done :  You'll need two nested forloops
            // DON'T FORGET TO LOG YOUR STEPS
            // Grab the path from the name of your file
            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            // Create a new instance of your TacoParser class
            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            //DONE THE ABOVE//
            // Now, here's the new code
            // Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            ITrackable locA = null;
            ITrackable locB = null;





            double distanceVs = 0;
            double maxDistance = 0;
            for (int i=0; i< locations.Length; i++)
            {
                var corA = new GeoCoordinate(locations[i].Location.Latitude, locations[i].Location.Longitude);


                for (int m=0; m< locations.Length; m++)
                {//through the constructor
                    var corB = new GeoCoordinate(locations[m].Location.Latitude, locations[m].Location.Longitude);

                    distanceVs = corA.GetDistanceTo(corB);
                    if (maxDistance < distanceVs)
                    {
                        locA = locations[i];
                        locB = locations[m];

                        maxDistance = distanceVs;
                        
                    }

                    
                }
                
            }
            Console.WriteLine($"{locA.Name} {locB.Name}");
            Console.ReadLine();





        }
    }

}