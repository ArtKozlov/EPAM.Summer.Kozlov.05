using System;
using System.Text;

namespace Task01
{
    public class Polinome
    {
        private int degree;
        private readonly double[] coefficients;

        public int Degree
        {
            get { return degree; }
        }

        public double[] Coeff
        {
            get { return coefficients; }
        }

        public Polinome(params double[] c)
        {
            if (c == null)
                throw new ArgumentNullException();

            if (c.Length != 0)
            {
                coefficients = new double[0];
                for (int i = 0; i < c.Length; i++)
                {
                    Array.Resize(ref coefficients, coefficients.Length + 1);
                    coefficients[i] = c[i];
                }
                degree = coefficients.Length - 1;
            }
        }
        /// <summary>
        /// is the sum of two polinomes.
        /// </summary>
        /// <returns>returns a new object of type polinome.</returns>
        public static Polinome operator +(Polinome lhs, Polinome rhs)
        {
            double[] lc = new double[0];
            if (lhs.Degree > rhs.Degree)
            {
                for (int i = 0; i <= rhs.Degree; ++i)
                {
                    Array.Resize(ref lc, lc.Length + 1);
                    lc[i] = lhs.Coeff[i] + rhs.Coeff[i];
                }
                for (int i = rhs.Degree + 1; i < lhs.Degree; ++i)
                {
                    Array.Resize(ref lc, lc.Length + 1);
                    lc[i] = lhs.Coeff[i];
                }
            }
            else
            {
                for (int i = 0; i <= lhs.Degree; ++i)
                {
                    Array.Resize(ref lc, lc.Length + 1);
                    lc[i] = lhs.Coeff[i] + rhs.Coeff[i];
                }
                for (int i = lhs.Degree; i < rhs.Degree; ++i)
                {
                    Array.Resize(ref lc, lc.Length + 1);
                    lc[i] = rhs.Coeff[i];
                }
            }

            return new Polinome(lc);
        }
        /// <summary>
        /// is the difference of two polinomes.
        /// </summary>
        /// <returns>returns a new object of type polinome.</returns>
        public static Polinome operator -(Polinome lhs, Polinome rhs)
        {
            double[] lc = new double[0];
            if (lhs.Degree > rhs.Degree)
            {
                for (int i = 0; i <= rhs.Degree; ++i)
                {
                    Array.Resize(ref lc, lc.Length + 1);
                    lc[i] = lhs.Coeff[i] - rhs.Coeff[i];
                }
                for (int i = rhs.Degree + 1; i < lhs.Degree; ++i)
                {
                    Array.Resize(ref lc, lc.Length + 1);
                    lc[i] = -lhs.Coeff[i];
                }
            }
            else
            {
                for (int i = 0; i <= lhs.Degree; ++i)
                {
                    Array.Resize(ref lc, lc.Length + 1);
                    lc[i] = lhs.Coeff[i] - rhs.Coeff[i];
                }
                for (int i = lhs.Degree; i < rhs.Degree; ++i)
                {
                    Array.Resize(ref lc, lc.Length + 1);
                    lc[i] = -rhs.Coeff[i];
                }
            }

            return new Polinome(lc);
        }
        /// <summary>
        /// multiplying two polinomes.
        /// </summary>
        /// <returns>returns a new object of type polinome.</returns>
        public static Polinome operator *(Polinome lhs, Polinome rhs)
        {
            double[] lc = new double[0];
            if (lhs.Degree > rhs.Degree)
            {
                for (int i = 0; i <= rhs.Degree; ++i)
                {
                    Array.Resize(ref lc, lc.Length + 1);
                    lc[i] = lhs.Coeff[i] * rhs.Coeff[i];
                }
                for (int i = rhs.Degree + 1; i < lhs.Degree; ++i)
                {
                    Array.Resize(ref lc, lc.Length + 1);
                    lc[i] = lhs.Coeff[i];
                }
            }
            else
            {
                for (int i = 0; i <= lhs.Degree; ++i)
                {
                    Array.Resize(ref lc, lc.Length + 1);
                    lc[i] = lhs.Coeff[i] * rhs.Coeff[i];
                }
                for (int i = lhs.Degree; i < rhs.Degree; ++i)
                {
                    Array.Resize(ref lc, lc.Length + 1);
                    lc[i] = rhs.Coeff[i];
                }
            }

            return new Polinome(lc);
        }
        /// <summary>
        /// multipling polinome and number.
        /// </summary>
        /// <returns>returns a new object of type polinome.</returns>
        public static Polinome operator *(Polinome currentPolinome, int number)
        {
            double[] lc = currentPolinome.coefficients;

            for (int i = 0; i < currentPolinome.Degree; i++)
            {
                lc[i] = currentPolinome.Coeff[i] * number;
            }

            return new Polinome(lc);
        }
        /// <summary>
        /// compares two objects of type polinome.
        /// </summary>
        /// <returns>Returns true if the objects are equal, False if the objects are not equal.</returns>
        public bool Equals(Polinome otherPolinom)
        {
            if (ReferenceEquals(this, otherPolinom))
                return true;
            if (ReferenceEquals(null, otherPolinom))
                return false;
            
            return false;
        }
        /// <summary>
        /// compares two objects of type polinome.
        /// </summary>
        /// <returns>Returns true if the objects are equal, False if the objects are not equal.</returns>
        public static bool operator ==(Polinome lhs, Polinome rhs) => lhs.Equals(rhs);

        public static bool operator !=(Polinome lhs, Polinome rhs) => !(lhs.Equals(rhs));
        /// <summary>
        /// override ToString method of Object.
        /// </summary>
        /// <returns>Returns Polinome in string format.</returns>
        public override string ToString()
        {
            
            StringBuilder result = new StringBuilder();
            if (coefficients.Length != 0)
            {
                for (int i = degree; i >= 0; i--)
                {
                    if (coefficients[i] != 0)
                    { 
                        if (coefficients[i] > 0)
                        { 
                            result.Append(" + ");
                        }
                        else
                        {
                            result.Append(" - ");
                        }
                        if(i != 0)
                            result.Append(Math.Abs(coefficients[i]) + "x^" + i);
                        else
                            result.Append(Math.Abs(coefficients[i]));
                    }

                }
            }
            
            return result.ToString();
        }


        /// <summary>
        /// override GetHashCode method of Object.
        /// </summary>
        /// <returns>Returns GetHashCode of Polinome.</returns>
        public override int GetHashCode() => ToString().GetHashCode();
        /// <summary>
        /// override Equals method of Object 
        /// </summary>
        /// <returns>Returns true if the objects are equal, False if the objects are not equal.</returns>
        public override bool Equals(Object currentObj)
        {
            if (ReferenceEquals(this, currentObj))
                return true;
            if (currentObj == null || GetType() != currentObj.GetType())
            {
                return false;
            }
            return Equals((Polinome)currentObj);

        }




    }
}
