using NUnit.Framework;
using Polynomial = PolynomialProject.Polynomial;

namespace Polynomial.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [TestCase(new double[] { 1, 2, 3.88, 0, 5 }, ExpectedResult = true)]
        [TestCase(new double[] { 0}, ExpectedResult = true)]
        public bool Polynomial_TrueIfCloneAndPolynomialAreEqual(double[] d1)
        {
            PolynomialProject.Polynomial p1 = new PolynomialProject.Polynomial(d1);
            PolynomialProject.Polynomial p2 = p1.Clone();
            return p1.GetHashCode() == p2.GetHashCode();
        }


        [TestCase(new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 2, 3, 4, 5 }, new double[] { 2, 4, 3, 4, 5 }, ExpectedResult = false)]
        public bool Polynomial_TrueIfPolynomialsAreEqual(double[] d1, double[] d2)
        {
            PolynomialProject.Polynomial p1 = new PolynomialProject.Polynomial(d1);
            PolynomialProject.Polynomial p2 = new PolynomialProject.Polynomial(d2);
            return p1.Equals(p2);
        }

        [TestCase(new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, new double[] {2, 4, 6, 8, 10 }, ExpectedResult = true)]
        public bool Polynomial_SumOfPolinomials(double[] d1, double[] d2, double[] result)
        {
            PolynomialProject.Polynomial p1 = new PolynomialProject.Polynomial(d1);
            PolynomialProject.Polynomial p2 = new PolynomialProject.Polynomial(d2);
            PolynomialProject.Polynomial p3 = new PolynomialProject.Polynomial(result);
            PolynomialProject.Polynomial p = p1 + p2;
            return p.Equals(p3);
        }

        [TestCase(new double[] { 1, 2, 3, 4, 5 }, new double[] { 2, 4, 6, 8, 10 }, new double[] { 1, 2, 3, 4, 5 }, ExpectedResult = true)]
        public bool Polynomial_DifferenceOfPolinomials(double[] d1, double[] d2, double[] result)
        {
            PolynomialProject.Polynomial p1 = new PolynomialProject.Polynomial(d1);
            PolynomialProject.Polynomial p2 = new PolynomialProject.Polynomial(d2);
            PolynomialProject.Polynomial p3 = new PolynomialProject.Polynomial(result);
            PolynomialProject.Polynomial p = p2 - p1;
            return p.Equals(p3);
        }

        [TestCase(new double[] { 1, 2, 3, 4, 5 }, new double[] { 2, 4, 6, 8, 10 }, new double[] { 2, 8, 18, 32, 50 }, ExpectedResult = true)]
        public bool Polynomial_MultiplyOfPolinomials(double[] d1, double[] d2, double[] result)
        {
            PolynomialProject.Polynomial p1 = new PolynomialProject.Polynomial(d1);
            PolynomialProject.Polynomial p2 = new PolynomialProject.Polynomial(d2);
            PolynomialProject.Polynomial p3 = new PolynomialProject.Polynomial(result);
            PolynomialProject.Polynomial p = p2 * p1;
            return p.Equals(p3);
        }

    }
}