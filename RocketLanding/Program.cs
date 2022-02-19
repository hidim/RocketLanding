using System;

namespace RocketLanding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Rocket Landing Platform Example!");

            LandingDecider.LandingPlatform landingPlatform = new LandingDecider.LandingPlatform();

            Console.WriteLine("Platform is valid? : " + landingPlatform.ValidateLandingPlatform());

            //Console.WriteLine("Rocket 1 asks for 5,5: " + landingPlatform.LandingQuery("1", 7, 7));
            //Console.WriteLine("Rocket 2 asks for 7,7: " + landingPlatform.LandingQuery("2", 7, 7));
            //Console.WriteLine("Rocket 2 asks for 7,8: " + landingPlatform.LandingQuery("2", 7, 8));
            //Console.WriteLine("Rocket 2 asks for 6,7: " + landingPlatform.LandingQuery("2", 6, 7));
            //Console.WriteLine("Rocket 2 asks for 6,6: " + landingPlatform.LandingQuery("2", 6, 6));
            //Console.WriteLine("Rocket 2 asks for 16,15: " + landingPlatform.LandingQuery("2", 16, 15));
            //Console.WriteLine("Rocket 2 asks for 8,8: " + landingPlatform.LandingQuery("2", 9, 8));

            for (int i = 0; i < 2000; i++)
            {
                int rocketId = new Random().Next(1, 5);
                int rocketXPosition = new Random().Next(1, 100);
                int rocketYPosition = new Random().Next(1, 100);

                Console.WriteLine("Rocket {0} asks for {1}, {2}: {3}", rocketId, rocketXPosition, rocketYPosition, landingPlatform.LandingQuery(rocketId.ToString(), rocketXPosition, rocketYPosition));
            }

            landingPlatform.Dispose();
            Console.ReadKey();
        }
    }
}
