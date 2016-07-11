using System;
using System.Collections.Generic;
using NUnit.Framework;
using Task01;

namespace Task01.NUnitTests
{
    public class PolinomeTests
    {

        #region Operator tests

        [TestCase(new double[] { 5.3, 2.5, 1 }, new double[] { 4.3, 1.6, 0 }, Result = " + 1x^2 + 4,1x^1 + 9,6")]
        [TestCase(new double[] { 1, 2, 2.9 }, new double[] { 0, 0, 2 }, Result = " + 4,9x^2 + 2x^1 + 1")]
        [TestCase(new double[] { 5.3, 1.4, 0, 0, 0, 0, 0 }, new double[] { 5.3, 1.4, 0, 0, 15.1 }, Result = " + 15,1x^4 + 2,8x^1 + 10,6")]
        public string Polinome_Add(double[] firstCoefficients, double[] secondCoefficients)
        {
            Polinome firstPolynomial = new Polinome(firstCoefficients);
            Polinome secondPolynomial = new Polinome(secondCoefficients);

            Polinome resultPolynomial = firstPolynomial + secondPolynomial;
            return resultPolynomial.ToString();
        }

        [TestCase(new double[] { 5.3, 2.5, 1 }, new double[] { 4.3, 1.6, 0 }, Result = " + 1x^2 + 0,9x^1 + 1")]
        [TestCase(new double[] { 1, 2, 2.9 }, new double[] { 0, 0, 2 }, Result = " + 0,9x^2 + 2x^1 + 1")]
        [TestCase(new double[] { 5.3, 1.5, 0, 0, 0, 0, 0 }, new double[] { 10.1, 1.4, 0, 0, 15.1 }, Result = " - 15,1x^4 + 0,1x^1 - 4,8")]
        public string Polinome_Sub(double[] firstCoefficients, double[] secondCoefficients)
        {
            Polinome firstPolinome = new Polinome(firstCoefficients);
            Polinome secondPolinome = new Polinome(secondCoefficients);

            Polinome resultPolynomial = firstPolinome - secondPolinome;
            return resultPolynomial.ToString();
        }

        [TestCase(new double[] { 5.3, 2.6, 1 }, new double[] { 2, 1.5, 0 }, Result = " + 3,9x^1 + 10,6")]
        [TestCase(new double[] { 1, 2, 2.9 }, new double[] { 0, 0, 2 }, Result = " + 5,8x^2")]
        [TestCase(new double[] { 5.3, 1.5, 0, 0, 0, 0, 0 }, new double[] { 10.1, 1.4, 0, 0, 15.1 }, Result = " + 2,1x^1 + 53,53")]
        public string Polinome_Multiply(double[] firstCoefficients, double[] secondCoefficients)
        {
            Polinome firstPolinome = new Polinome(firstCoefficients);
            Polinome secondPolinome = new Polinome(secondCoefficients);

            Polinome resultPolynomial = firstPolinome * secondPolinome;
            return resultPolynomial.ToString();
        }

        #endregion

        [TestCase(new double[] { 5.3, 2.5, 0 }, Result = " + 2,5x^1 + 5,3")]
        [TestCase(new double[] { 0, 0, 2.9 }, Result = " + 2,9x^2")]
        [TestCase(new double[] { 5.3, 1.4, 0, 0, 0, 0, 0 }, Result = " + 1,4x^1 + 5,3")]
        [TestCase(new double[] { 5.3, 0, 1.4 }, Result = " + 1,4x^2 + 5,3")]
        [TestCase(new double[] { -12.7, -1.4, -1, -13.8, -23.2 }, Result = " - 23,2x^4 - 13,8x^3 - 1x^2 - 1,4x^1 - 12,7")]
        [TestCase(new double[] { 5.3, 1.4, -1.9 }, Result = " - 1,9x^2 + 1,4x^1 + 5,3")]
        public string Polinome_ToString(double[] coefficients)
        {
            Polinome pol = new Polinome(coefficients);
            return pol.ToString();
        }

        [TestCase(new double[] { 5.3, 2.5, 0 }, Result = true)]
        [TestCase(new double[] { 0, 0, 2.9 }, Result = true)]
        [TestCase(new double[] { 5.3, 1.4, 0, 0, 0, 0, 0 }, Result = true)]
        [TestCase(new double[] { 5.3, 0, 1.4 }, Result = true)]
        public bool Polinome_Equals_Positive(double[] firstCoefficients)
        {
            Polinome lhs = new Polinome(firstCoefficients);
            Polinome rhs = lhs;
            return lhs.Equals(rhs);
        }

        [TestCase(new double[] { 5.3, 2.5, 0 }, new double[] { 5.3, 2.5, 0 }, Result = false)]
        [TestCase(new double[] { 0, 0, 2.9 }, new double[] { 0, 0, 2.9 }, Result = false)]
        [TestCase(new double[] { 5.3, 1.4, 0, 0, 0, 0, 0 }, new double[] { 5.3, 1.4, 0, 0, 0, 0, 0 }, Result = false)]
        [TestCase(new double[] { 5.3, 0, 1.4 }, new double[] { 5.3, 1.4, 0, 0, 0, 0, 0 }, Result = false)]
        public bool Polinome_Equals_Negative(double[] firstCoefficients, double[] secondCoefficients)
        {
            Polinome lhs = new Polinome(firstCoefficients);
            Polinome rhs = new Polinome(secondCoefficients);
            return lhs.Equals(rhs);
        }

        [TestCase(new double[] { 5.3, 2.5, 0 }, new double[] { 5.3, 2.5, 0 }, Result = true)]
        [TestCase(new double[] { 0, 0, 2.9 }, new double[] { 0, 0, 2.9 }, Result = true)]
        [TestCase(new double[] { 5.3, 1.4, 0, 0, 0, 0, 0 }, new double[] { 5.3, 1.4, 0, 0, 0, 0, 0 }, Result = true)]
        [TestCase(new double[] { 5.3, 0, 1.4 }, new double[] { 5.3, 1.4, 0, 0, 0, 0, 0 }, Result = false)]
        public bool Polinome_GetHashCode(double[] firstCoefficients, double[] secondCoefficients)
        {
            Polinome lhs = new Polinome(firstCoefficients);
            Polinome rhs = new Polinome(secondCoefficients);
            return (lhs.GetHashCode() == rhs.GetHashCode());
        }
    }
}
