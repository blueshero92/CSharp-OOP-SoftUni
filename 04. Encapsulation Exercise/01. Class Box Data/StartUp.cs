﻿using _01.ClassBoxData.Models;

namespace _01.ClassBoxData
{
    public class StartUp
    {
        static void Main()
        {

            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new(length, width, height);

                Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {box.Volume():f2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}