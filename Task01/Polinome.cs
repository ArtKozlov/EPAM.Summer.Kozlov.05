using System;
using System.Collections.Generic;
using System.Text;

namespace Task01
{
    public class Polinome
    {
        private double x;
        private int degree;
        private List<int> coefficients = new List<int>();
        public double GetX
        {
            get { return x; }
        }
        public int GetDegree
        {
            get { return degree; }
        }
        public List<int> GetC//
        {
            get { return coefficients; }
        }

        public Polinome(int deg, double xVal, List<int> c)//
        {
            if ((deg > 0 && deg < 10) && deg == c.Count)
            {
                degree = deg;
                x = xVal;
                foreach (int n in c)
                    coefficients.Add(n);
            }
            else
                throw new Exception("Error input data in overloaded class constructor!");
        }
        /// <summary>
        /// is the sum of two polinomes.
        /// </summary>
        /// <returns>returns a new object of type polinome.</returns>
        public static Polinome operator +(Polinome firstPolinome, Polinome secondPolinome)//статический метод сложения полиномов
        {
            int degree;
            double xVal;
            List<int> lc = new List<int>();
            xVal = firstPolinome.GetX + secondPolinome.GetX;
            if (firstPolinome.GetDegree > secondPolinome.GetDegree)
            {
                degree = firstPolinome.GetDegree;
                for (int i = 0; i < secondPolinome.GetDegree; ++i)
                {
                    lc.Add(firstPolinome.GetC[i] + secondPolinome.GetC[i]);
                }
                for (int i = secondPolinome.GetDegree; i < firstPolinome.GetDegree; ++i)
                {
                    lc.Add(firstPolinome.GetC[i]);
                }
            }
            else
            {
                degree = secondPolinome.GetDegree;
                for (int i = 0; i < firstPolinome.GetDegree; ++i)
                {
                    lc.Add(firstPolinome.GetC[i] + secondPolinome.GetC[i]);
                }
                for (int i = firstPolinome.GetDegree; i < secondPolinome.GetDegree; ++i)
                {
                    lc.Add(secondPolinome.GetC[i]);
                }
            }

            return new Polinome(degree, xVal, lc);
        }
        /// <summary>
        /// is the difference of two polinomes.
        /// </summary>
        /// <returns>returns a new object of type polinome.</returns>
        public static Polinome operator -(Polinome firstPolinome, Polinome secondPolinome)//статический метод вычитания полиномов
        {
            int degree;
            double xVal;
            List<int> lc = new List<int>();
            xVal = firstPolinome.GetX - secondPolinome.GetX;
            if (firstPolinome.GetDegree > secondPolinome.GetDegree)
            {
                degree = firstPolinome.GetDegree;
                for (int i = 0; i < secondPolinome.GetDegree; ++i)
                {
                    lc.Add(firstPolinome.GetC[i] - secondPolinome.GetC[i]);
                }
                for (int i = secondPolinome.GetDegree; i < firstPolinome.GetDegree; ++i)
                {
                    lc.Add(-firstPolinome.GetC[i]);
                }
            }
            else
            {
                degree = secondPolinome.GetDegree;
                for (int i = 0; i < firstPolinome.GetDegree; ++i)
                {
                    lc.Add(firstPolinome.GetC[i] - secondPolinome.GetC[i]);
                }
                for (int i = firstPolinome.GetDegree; i < secondPolinome.GetDegree; ++i)
                {
                    lc.Add(-secondPolinome.GetC[i]);
                }
            }

            return new Polinome(degree, xVal, lc);
        }
        /// <summary>
        /// multiplying two polinomes.
        /// </summary>
        /// <returns>returns a new object of type polinome.</returns>
        public static Polinome operator *(Polinome firstPolinome, Polinome secondPolinome)//статический метод вычитания полиномов
        {
            int degree;
            double xVal;
            List<int> lc = new List<int>();
            xVal = firstPolinome.GetX * secondPolinome.GetX;
            if (firstPolinome.GetDegree > secondPolinome.GetDegree)
            {
                degree = firstPolinome.GetDegree;
                for (int i = 0; i < secondPolinome.GetDegree; ++i)
                {
                    lc.Add(firstPolinome.GetC[i] * secondPolinome.GetC[i]);
                }
                for (int i = secondPolinome.GetDegree; i < firstPolinome.GetDegree; ++i)
                {
                    lc.Add(firstPolinome.GetC[i]);
                }
            }
            else
            {
                degree = secondPolinome.GetDegree;
                for (int i = 0; i < firstPolinome.GetDegree; ++i)
                {
                    lc.Add(firstPolinome.GetC[i] * secondPolinome.GetC[i]);
                }
                for (int i = firstPolinome.GetDegree; i < secondPolinome.GetDegree; ++i)
                {
                    lc.Add(secondPolinome.GetC[i]);
                }
            }

            return new Polinome(degree, xVal, lc);
        }
        /// <summary>
        /// multipling polinome and number.
        /// </summary>
        /// <returns>returns a new object of type polinome.</returns>
        public static Polinome operator *(Polinome thisPolinome, int number)
        {
            double xVal = thisPolinome.GetX * number;
            List<int> lc = thisPolinome.coefficients;

            for (int i = 0; i < thisPolinome.GetDegree; i++)
            {
                lc.Add(thisPolinome.GetC[i] * number);
            }

            return new Polinome(thisPolinome.GetDegree, xVal, lc);
        }
        /// <summary>
        /// compares two objects of type polinome.
        /// </summary>
        /// <returns>Returns true if the objects are equal, False if the objects are not equal.</returns>
        public bool Equals(Polinome otherPolinom)
        {
            if (degree != otherPolinom.GetDegree)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < degree; i++)
                {
                    if (coefficients[i] != otherPolinom.GetC[i])
                        return false;
                }
                return true;
            }
        }
        /// <summary>
        /// compares two objects of type polinome.
        /// </summary>
        /// <returns>Returns true if the objects are equal, False if the objects are not equal.</returns>
        public static bool operator ==(Polinome firstPolinome, Polinome secondPolinome)
        {
                return firstPolinome.Equals(secondPolinome);
        }

        public static bool operator !=(Polinome firstPolinome, Polinome secondPolinome)
        {
                return !(firstPolinome.Equals(secondPolinome));
        }
        /// <summary>
        /// override ToString method of Object.
        /// </summary>
        /// <returns>Returns Polinome in string format.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (coefficients.Count != 0)
            {
                result.Append(coefficients[degree] + "x^" + degree);
                for (int i = degree - 1; i > 0; i--)
                {
                        result.Append(" + " + coefficients[i] + "x^" + i);
                }
            }
            return result.ToString();
        }
        /// <summary>
        /// override Equals method of Object 
        /// </summary>
        /// <returns>Returns true if the objects are equal, False if the objects are not equal.</returns>
        public override bool Equals(Object currentPolinome)
        {
            if (currentPolinome == null)
            {
                return false;
            }
            else
            {
                Polinome newPolinome = currentPolinome as Polinome;
                return Equals(newPolinome);
            }

        }




    }
}
