// Written by Piotr Szołtys 17.05.2018 (maybe 18.05)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10
{
    class Program
    {
        private static double BendingForce;
        private static double TensileForce;
        static void Main(string[] args)
        {
            CProfile[] profileArr = new CProfile[6];
            // here comes the part i rly dont like
            profileArr[0] = new CIBeam(80, 46, 4, 2500, 6);
            profileArr[1] = new CIBeam(100, 55, 5, 1500, 8.1);
            profileArr[2] = new CIBeam(120, 64, 5.5, 2000, 10.4);
            profileArr[3] = new CRoundTube(42.4, 3, 2500, 2.91);
            profileArr[4] = new CRoundTube(60.3, 3, 1500, 4.24);
            profileArr[5] = new CRoundTube(101.6, 5, 1000, 11.9);

            foreach(var entry in profileArr)
            {
                entry.Show();
                entry.Show2();
            }
            Console.WriteLine("Input bending force value:");
            BendingForce = GetDouble();
            Console.WriteLine("Input tensile force value:");
            TensileForce = GetDouble();
            var stressArr = new double[6, 2];
            for(int i = 0; i<6; i++) // FYI: usually we want to keep sizes, string values etc. in some util class so that we can change them rly easy
            {
                stressArr[i,0] = CalcBendingStress(profileArr[i].Length, profileArr[i].GetSectionModulus());
                stressArr[i,1] = CalcTensileStress(profileArr[i].getArea());
                Console.WriteLine("Bending stress for position: " + i + " is: " + stressArr[i, 0]);
                Console.WriteLine("Tensile stress for position: " + i + " is: " + stressArr[i, 1]);
            }
            Console.ReadKey();
        }
        private static double GetDouble() => Convert.ToDouble(Console.ReadLine());
        private static double CalcBendingStress(double length, double secModulus) => (BendingForce*length)/secModulus;
        private static double CalcTensileStress(double area) => TensileForce / area;
    }
}
