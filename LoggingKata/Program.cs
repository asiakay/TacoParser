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
            
            //ITrackable point1 = null;
            //ITrackable point2 = null;

            //GeoCoordinate cordA = new GeoCoordinate();


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



            //    // Location 1
            //cordA.Latitude = locA.Location.Latitude;
            //cordA.Longitude = locA.Location.Longitude;

            ////Location 2
            //cordB.Latitude = locB.Location.Latitude;
            //cordB.Longitude = locB.Location.Longitude;

            ////First TacoBell
            //TacoBell NewtacoBell1 = new TacoBell();
            //var currLocation = NewtacoBell1.Location;
            //currLocation.Latitude = locA.Location.Latitude;
            //currLocation.Longitude = locA.Location.Longitude;
            //NewtacoBell1.Name = locA.Name;

            ////Second TacoBell
            //TacoBell NewtacoBell2 = new TacoBell();
            //var currLocation2 = NewtacoBell1.Location;
            //currLocation.Latitude = locA.Location.Latitude;
            //currLocation.Longitude = locA.Location.Longitude;
            //NewtacoBell1.Name = locA.Name;

            //foreach (item in locations)
            //{
            //    Console.WriteLine();

            //}


            // Create a `double` variable to store the distance


            //var double DistanceBetween = 0;?



            //foreach (item in DistanceBetween)

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            // Create a new corA Coordinate with your locA's lat and long
            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
            // Create a new Coordinate with your locB's lat and long
            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above
            // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.
        }
    }

}