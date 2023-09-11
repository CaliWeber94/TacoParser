using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Data.Common;

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

                                  
                        
            ITrackable location1 = null;
            ITrackable location2 = null;
            
            double greatestDistance = 0;

                                  
            
             for(int i = 0; i < locations.Length - 1; i++)
            {
                ITrackable locA = locations[i];
                Point corA = locations[i].Location;
                GeoCoordinate geoA = new GeoCoordinate(corA.Latitude, corA.Longitude);
                for(int j  = i + 1; j < locations.Length -1; j++)
                {
                     ITrackable locB = locations[j];
                    Point corB = locations[j].Location;
                    GeoCoordinate geoB = new GeoCoordinate(corB.Latitude, corB.Longitude);

                    double distance = geoA.GetDistanceTo(geoB);
                    if (distance > greatestDistance)
                    {
                        greatestDistance = distance;
                        location1 = locA;
                        location2 = locB;
                    }
                }
            }

            
            var greatestDistanceInMiles = Math.Round(greatestDistance * 0.00062137, 1);

            Console.WriteLine($"The two Taco Bells that are the furthest distance apart are {location1.Name} and {location2.Name}");
            Console.WriteLine($"They are {greatestDistanceInMiles} apart");

        }
    }
}
