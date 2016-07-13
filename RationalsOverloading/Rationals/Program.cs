using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    class Program
    {
        struct Rational
        {
            private int Numerator { get; set; }
            private int Denominator { get; set; }
            private double Num { get;}

            public Rational(int numerator, int denominator)
            {
                Numerator = numerator;
                Denominator = denominator;
                Num =(double)numerator/denominator;
            }

            public Rational(int numerator)
            {
                Numerator = numerator;
                Denominator = 1;
                Num = (double)numerator / 1;
            }

            public static Rational operator +(Rational r1, Rational r2)
            {
                return (Add(r1, r2));
            }

            public static Rational operator -(Rational r1, Rational r2)
            {
                r2.Numerator = r2.Numerator*(-1);
                return (Add(r1, r2));
            }

            public static Rational Add(Rational rational1, Rational rational2)
            {
                var numerator = rational1.Numerator*rational2.Denominator
                                + rational2.Numerator*rational1.Denominator;
                var denominator = rational1.Denominator*rational2.Denominator;

                var rational= new Rational(numerator, denominator);

                return rational;
            }

            public static Rational operator *(Rational r1, Rational r2)
            {
                return (Mul(r1, r2));
            }

            public static Rational? operator /(Rational r1, Rational r2)
            {
                if (r2.Numerator==0)
                {
                    return null;
                }
                int temp = r2.Numerator;
                r2.Numerator = r2.Denominator;
                r2.Denominator = temp;
                return (Mul(r1, r2));
            }

            public static Rational Mul(Rational rational1, Rational rational2)
            {
                var numerator = rational1.Numerator * rational2.Numerator;
                var denominator = rational1.Denominator * rational2.Denominator;
                var rational = new Rational(numerator, denominator);

                return rational;
            }

            public void Reduce()
            {
                var gcd = Gcd(Numerator, Denominator);
                Numerator = Numerator/gcd;
                Denominator = Denominator/gcd;
            }

            private static int Gcd(int a, int b)
            {
                while (true)
                {
                    if (b == 0) return a;
                    var a1 = a;
                    a = b;
                    b = a1%b;
                }
            }

            public override string ToString()
            {
                return Numerator + "/" + Denominator + " = " + Num;
            }    

            public bool Equals(Rational other)
            {
                return  //Numerator == other.Numerator &&
                        //Denominator == other.Denominator && 
                    Num.Equals(other.Num);
                // i was not sure if i need to check equals for all the fields
                //if this what you meam for, you can see it on the comments above
            }

            public static implicit operator double(Rational rational)
            {
                return rational.Num;
            }

            public static explicit operator Rational(int num)
            {
                return new Rational(num);
            }

        }

        static void Main(string[] args)
        {
            Rational rational1= new Rational(2,4);
            Rational rational2= new Rational(1,3);
            Rational rational3= Rational.Add(rational1,rational2);
            Rational rational4 = Rational.Mul(rational1, rational3);
            Rational rational5 = rational1;
            rational5.Reduce();
            Console.WriteLine(rational1.ToString());
            Console.WriteLine(rational2.ToString());
            Console.WriteLine(rational3.ToString());
            Console.WriteLine(rational4.ToString());
            Console.WriteLine(rational5.ToString());
            Console.WriteLine(rational5.Equals(rational1));
            Console.WriteLine(rational5.Equals(rational4));

            Rational rational6 = new Rational(1, 2);
            Rational rational7 = new Rational(1, 2);
            Rational rational8 = rational6 + rational7;
            Rational rational9 = rational6- rational7;
            Rational rational10= rational6 * rational7;
            Rational? rational11= rational6 / rational7;

            Console.WriteLine("1/2 + 1/2 =" + rational8.ToString());
            Console.WriteLine("1/2 - 1/2 =" + rational9.ToString());
            Console.WriteLine("1/2 * 1/2 =" + rational10.ToString());
            Console.WriteLine("1/2 / 1/2 =" + rational11.ToString());

            double rat = rational10;
            rational11 = (Rational)2;

            Console.WriteLine(rat);
            Console.WriteLine(rational11);
        }
    }
}
