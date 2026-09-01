using System;
using UnityEngine;

namespace _01_Scripts
{
	[Serializable]
	public struct BigNumber
	{
		[SerializeField] private double mantissa;
		[SerializeField] private long exponent;


		public double Mantissa => mantissa;
		public long Exponent => exponent;

		public static BigNumber Zero => new BigNumber(0, 0);
		public static BigNumber One => new BigNumber(1, 0);

		public BigNumber(double mantissa, long exponent = 0)
		{
			this.mantissa = mantissa;
			this.exponent = exponent;

			Normalize();
		}

		private void Normalize()
		{
			if (mantissa == 0)
			{
				exponent = 0;
				return;
			}

			double absMantissa = Math.Abs(mantissa);

			// Math.Log10을 사용해서 반복문 없이 한 번에 정규화
			long adjustment = (long)Math.Floor(Math.Log10(absMantissa));

			mantissa /= Math.Pow(10, adjustment);
			exponent += adjustment;
		}

		

		public static BigNumber operator +(BigNumber a, BigNumber b)
		{
			if (a.mantissa == 0)
				return b;

			if (b.mantissa == 0)
				return a;

			// 더 큰 수를 a로 만든다.
			if (a < b)
				(a, b) = (b, a);

			long exponentDifference = a.exponent - b.exponent;

			// double 정밀도상 의미 없는 수준의 차이라면 무시
			if (exponentDifference > 15)
				return a;

			double adjustedMantissa =
				b.mantissa * Math.Pow(10, -exponentDifference);

			return new BigNumber(
				a.mantissa + adjustedMantissa,
				a.exponent
			);
		}

		public static BigNumber operator -(BigNumber a, BigNumber b)
		{
			return a + new BigNumber(-b.mantissa, b.exponent);
		}
		public static BigNumber operator *(BigNumber a, BigNumber b)
		{
			if (a.mantissa == 0 || b.mantissa == 0)
				return Zero;

			return new BigNumber(
				a.mantissa * b.mantissa,
				a.exponent + b.exponent
			);
		}

		public static BigNumber operator /(BigNumber a, BigNumber b)
		{
			if (b.mantissa == 0)
				throw new DivideByZeroException();

			return new BigNumber(
				a.mantissa / b.mantissa,
				a.exponent - b.exponent
			);
		}

		public static BigNumber operator +(BigNumber a, double b)
		{
			return a + FromDouble(b);
		}

		public static BigNumber operator +(double a, BigNumber b)
		{
			return FromDouble(a) + b;
		}

		public static BigNumber operator *(BigNumber a, double b)
		{
			return new BigNumber(
				a.mantissa * b,
				a.exponent
			);
		}

		public static BigNumber operator *(double a, BigNumber b)
		{
			return b * a;
		}

		public static BigNumber operator /(BigNumber a, double b)
		{
			if (b == 0)
				throw new DivideByZeroException();

			return new BigNumber(
				a.mantissa / b,
				a.exponent
			);
		}

		public static bool operator >(BigNumber a, BigNumber b)
		{
			if (a.mantissa >= 0 && b.mantissa < 0)
				return true;

			if (a.mantissa < 0 && b.mantissa >= 0)
				return false;

			// 둘 다 양수
			if (a.mantissa >= 0)
			{
				if (a.exponent != b.exponent)
					return a.exponent > b.exponent;

				return a.mantissa > b.mantissa;
			}

			// 둘 다 음수
			if (a.exponent != b.exponent)
				return a.exponent < b.exponent;

			return a.mantissa > b.mantissa;
		}

		public static bool operator <(BigNumber a, BigNumber b)
		{
			return b > a;
		}

		public static bool operator >=(BigNumber a, BigNumber b)
		{
			return a > b || a == b;
		}

		public static bool operator <=(BigNumber a, BigNumber b)
		{
			return a < b || a == b;
		}

		public static bool operator ==(BigNumber a, BigNumber b)
		{
			return a.mantissa == b.mantissa &&
			       a.exponent == b.exponent;
		}

		public static bool operator !=(BigNumber a, BigNumber b)
		{
			return !(a == b);
		}


		public static BigNumber FromDouble(double value)
		{
			return new BigNumber(value);
		}


		public override string ToString()
		{
			if (mantissa == 0)
				return "0";

			string[] suffixes =
			{
				"",   // 10^0
				"K",  // 10^3
				"M",  // 10^6
				"B",  // 10^9
				"T",  // 10^12
				"Qa", // 10^15
				"Qi", // 10^18
				"Sx", // 10^21
				"Sp", // 10^24
				"Oc", // 10^27
				"No", // 10^30
				"Dc"  // 10^33
			};

			long group = exponent / 3;
			int remainder = (int)(exponent % 3);

			// 예: 1.23e4 → 12.3K
			double displayValue = mantissa * Math.Pow(10, remainder);

			if (group < suffixes.Length)
			{
				return $"{displayValue:0.##}{suffixes[group]}";
			}

			return $"{mantissa:0.###}e{exponent}";
		}

		public override bool Equals(object obj)
		{
			if (!(obj is BigNumber))
				return false;

			BigNumber other = (BigNumber)obj;

			return this == other;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(mantissa, exponent);
		}

	}
}