using System;
using System.Linq;

namespace PolynomialProject
{
    public class Polynomial : IEquatable<Polynomial>, ICloneable
    {
        private double[] _polynom;

        public Polynomial(double[] polynom)
        {
            CheckArrayInput(polynom);
            _polynom = new double[polynom.Length];
            polynom.CopyTo(_polynom, 0);
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="polynom1">The polynom1.</param>
        /// <param name="polynom2">The polynom2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator +(Polynomial polynom1, double[] polynom2)
        {
            CheckPolynomialInput(polynom1);
            CheckArrayInput(polynom2);
            for (int i = 0; i < polynom1._polynom.Length; i++)
            {
                polynom1._polynom[i] = polynom1._polynom[i] + polynom2[i];
            }
            
            return new Polynomial(polynom1._polynom);
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="polynom1">The polynom1.</param>
        /// <param name="polynom2">The polynom2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator +(Polynomial polynom1, Polynomial polynom2)
        {
            CheckPolynomialInput(polynom1);
            CheckPolynomialInput(polynom2);
            for (int i = 0; i < polynom1._polynom.Length; i++)
            {
                polynom1._polynom[i] = polynom1._polynom[i] + polynom2._polynom[i];
            }
            
            return new Polynomial(polynom1._polynom);
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="polynom1">The polynom1.</param>
        /// <param name="polynom2">The polynom2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator -(Polynomial polynom1, double[] polynom2)
        {
            CheckPolynomialInput(polynom1);
            CheckArrayInput(polynom2);
            for (int i = 0; i < polynom1._polynom.Length; i++)
            {
                polynom1._polynom[i] = polynom1._polynom[i] - polynom2[i];
            }
            return new Polynomial(polynom1._polynom);
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="polynom1">The polynom1.</param>
        /// <param name="polynom2">The polynom2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator -(Polynomial polynom1, Polynomial polynom2)
        {
            CheckPolynomialInput(polynom1);
            CheckPolynomialInput(polynom2);
            for (int i = 0; i < polynom1._polynom.Length; i++)
            {
                polynom1._polynom[i] = polynom1._polynom[i] - polynom2._polynom[i];
            }
            return new Polynomial(polynom1._polynom);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="polynom1">The polynom1.</param>
        /// <param name="polynom2">The polynom2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator *(Polynomial polynom1, Polynomial polynom2)
        {
            CheckPolynomialInput(polynom1);
            CheckPolynomialInput(polynom2);
            for (int i = 0; i < polynom1._polynom.Length; i++)
            {
                polynom1._polynom[i] = polynom1._polynom[i] * polynom2._polynom[i];
            }
            return new Polynomial(polynom1._polynom);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="polynom1">The polynom1.</param>
        /// <param name="polynom2">The polynom2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Polynomial polynom1, Polynomial polynom2)
        {
            CheckPolynomialInput(polynom1);
            CheckPolynomialInput(polynom1);
            if (polynom2._polynom.Length != polynom1._polynom.Length)
                return false;

            for (int i = 0; i < polynom1._polynom.Length; i++)
                if (Math.Abs(polynom1._polynom[i] - polynom2._polynom[i]) > 0.0001)
                    return false;
            return true;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="polynom1">The polynom1.</param>
        /// <param name="polynom2">The polynom2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Polynomial polynom1, Polynomial polynom2)
        {
            CheckPolynomialInput(polynom1);
            CheckPolynomialInput(polynom1);
            if (polynom2._polynom.Length != polynom1._polynom.Length)
                return false;
            for (int i = 0; i < polynom1._polynom.Length; i++)
                if (Math.Abs(polynom1._polynom[i] - polynom2._polynom[i]) < 0.0001)
                    return false;
            return true;
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public Polynomial Clone()
        {
            double[] polinom = new double[_polynom.Length];
            Array.Copy(_polynom, polinom, _polynom.Length);
            return new Polynomial(polinom);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _polynom.SequenceEqual(other._polynom);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Polynomial) obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            if (_polynom == null)
                return 0;
            int hash = 0;
            for (int i = 0; i < _polynom.Length; i++)
                hash = hash + (int) _polynom[i] * i;
            return hash;
        }

        private static void CheckPolynomialInput(Polynomial polynom)
        {
            if(polynom is null)
                throw new ArgumentNullException($"Reference {nameof(polynom)} is null");
        }

        private static void CheckArrayInput(double[] polynom)
        { 
            if(polynom is null)
                throw new ArgumentNullException($"Array {nameof(polynom)} is null");
            if(polynom.Length == 0)
                throw new ArgumentException($"Array {nameof(polynom)} has zero length");
        }
    }
}