using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10
{
    class CProfile
    {
        private double m_dLength;
        private double m_dWeightPerMeter;
        private string m_sType = "unknown";

        public double Length
        {
            get { return m_dLength; }
            set { m_dLength = value; }
        }

        public double WeightPerMeter
        {
            get { return m_dWeightPerMeter; }
            set { m_dWeightPerMeter = value; }
        }

        public string StructuralType
        {
            get { return m_sType; }
            set { m_sType = value; }
        }


        public CProfile()
        {
            m_dLength = 0;
            m_dWeightPerMeter = 0;
        }

        public CProfile(double length, double weightPerMeter)
        {
            Length = length;
            WeightPerMeter = weightPerMeter;
        }
        public double getOverallWeight()
        {
            return Length / 1000 * WeightPerMeter;
        }
    }

    class CIBeam : CProfile
    {
        private double m_dHeight;
        private double m_dWidth;
        private double m_dThickness;

        public static readonly string Type = "I-beam";

        public double Height
        {
            get
            {
                return m_dHeight;
            }
            set
            {
                m_dHeight = value;
            }
        }
        public double Width
        {
            get
            {
                return m_dWidth;
            }
            set
            {
                m_dWidth = value;
            }
        }

        public double Thickness
        {
            get
            {
                return m_dThickness;
            }
            set
            {
                m_dThickness = value;
            }
        }

        public CIBeam()
        {
            StructuralType = CIBeam.Type;
        }

        public CIBeam(double height, double width, double thickness, double lenght, double weightPerMeter) : base(lenght, weightPerMeter)
        {
            Width = width;
            Height = height;
            Thickness = thickness;
            StructuralType = CIBeam.Type;
        }

        public void Show()
        {
            Console.WriteLine("Hello i am " + CIBeam.Type + " ,here are my parameters: \n lenght: {0}, weight perimeter: {1}, structural type: {2}, height: {3}, width: {4}, thickness: {5} \n", Length, WeightPerMeter, StructuralType, Height, Width, Thickness);
        }
    }

    class CRoundTube : CProfile
    {
        private double m_dDiameter;
        private double m_dThickness;

        public static readonly string Type = "Round tube";

        public double Diameter
        {
            get
            {
                return m_dDiameter;
            }
            set
            {
                m_dDiameter = value;
            }
        }
        public double Thickness
        {
            get
            {
                return m_dThickness;
            }
            set
            {
                m_dThickness = value;
            }
        }
        public CRoundTube()
        {
            StructuralType = CRoundTube.Type;
        }
        public CRoundTube(double diameter, double thickness, double length, double weight) : base(length, weight)
        {
            Diameter = diameter;
            Thickness = thickness;
            StructuralType = CRoundTube.Type;
        }
        public void Show()
        {
            Console.WriteLine("Hello i am " + CRoundTube.Type + " ,here are my parameters:\n diameter: {0}, thickness: {1}, lenght: {2}, weight per meter: {3}, type: {4}", Diameter, Thickness, Length, WeightPerMeter, StructuralType);
        }
    }

}
