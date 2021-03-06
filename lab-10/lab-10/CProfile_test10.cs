﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// the instruction says to locate all classes in this one file

namespace lab_10
{
    class CProfile : IStrengthParam
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
        public virtual double getArea() // usually method name should start from capital letter
        {
            return 0;
        }
        public virtual double GetSectionModulus()
        {
            return 0;
        }
        public virtual double GetInertiaMoment()
        {
            return 0;
        }
        public virtual void Show()
        {
            Console.WriteLine("wow you made a CProfile object!");
        }
        public void Show2()
        {
            Console.WriteLine("Section modulus: {0} , Inertia moment: {1}", GetSectionModulus(), GetInertiaMoment());
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

        public override void Show()
        {
            Console.WriteLine("Hello i am " + CIBeam.Type + " ,here are my parameters: \n lenght: {0}, weight perimeter: {1}, structural type: {2}, height: {3}, width: {4}, thickness: {5}", Length, WeightPerMeter, StructuralType, Height, Width, Thickness);
        }
        public override double getArea() // usually method name should start from capital letter
        {
            var result = (2 * Thickness * Width) + ((Height - (2 * Thickness)) * Thickness);
            return Math.Round(result,2); 
        }
        public override double GetSectionModulus()
        {
            var result = GetInertiaMoment() / (Height / 2);
            return Math.Round(result, 2);
        }
        public override double GetInertiaMoment()
        {
            var result = ((Width * Math.Pow(Height, 3)) - (Width - Thickness) * Math.Pow(Height - (2 * Thickness), 3)) / 12;
            return Math.Round(result, 2);
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
        public override void Show()
        {
            Console.WriteLine("Hello i am " + CRoundTube.Type + " ,here are my parameters:\n diameter: {0}, thickness: {1}, lenght: {2}, weight per meter: {3}, type: {4}", Diameter, Thickness, Length, WeightPerMeter, StructuralType);
        }
        public override double getArea() // usually method name should start from capital letter
        {
            var result = (Math.PI*Math.Pow((Math.Pow(Diameter, 4) - (Diameter - (2*Thickness))),4))/64;
            return Math.Round(result, 2);
        }
        public override double GetSectionModulus()
        {
            var result = GetInertiaMoment() / (Diameter / 2);
            return Math.Round(result, 2);
        }
        public override double GetInertiaMoment()
        {
            var result = (Math.PI*Math.Pow(((Diameter*Diameter) - (Diameter-(2*Thickness))),2)) / 4;
            return Math.Round(result, 2);
        }
    }

}
