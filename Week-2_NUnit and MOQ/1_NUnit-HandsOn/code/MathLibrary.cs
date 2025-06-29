using System;

namespace CalcLibrary
{
    public interface IMathLibrary
    {
        double Addition(double a, double b);
        double Subtraction(double a, double b);
        double Multiplication(double a, double b);
        double Division(double a, double b);
    }

    public class SimpleCalculator : IMathLibrary
    {
        private double result = 0;

        /// <summary>
        /// Adds two numbers.
        /// </summary>
        public double Addition(double a, double b)
        {
            result = a + b;
            return result;
        }

        /// <summary>
        /// Subtracts the second number from the first.
        /// </summary>
        public double Subtraction(double a, double b)
        {
            result = a - b;
            return result;
        }

        /// <summary>
        /// Multiplies two numbers.
        /// </summary>
        public double Multiplication(double a, double b)
        {
            result = a * b;
            return result;
        }

        /// <summary>
        /// Divides the first number by the second.
        /// Throws if the divisor is zero.
        /// </summary>
        public double Division(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("The divisor cannot be zero.");
            result = a / b;
            return result;
        }

        /// <summary>
        /// Clears the result.
        /// </summary>
        public void Clear()
        {
            result = 0;
        }

        /// <summary>
        /// Gets the last result.
        /// </summary>
        public double Result => result;
    }
}
