using System;

namespace PadawansTask11
{
    public static class ArrayExtensions
    {
        public static int? FindIndex(double[] array, double accuracy)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (array.Length == 0)
            {
                throw new ArgumentException();
            }
            if (accuracy >= 1 || accuracy <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            // Leftside sum
            double[] prefixSum = new double[array.Length];
            prefixSum[0] = array[0];
            for (int i = 0; i < prefixSum.Length - 1; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + array[i + 1];
            }
            // Rightside sum
            double[] suffixSum = new double[array.Length];
            suffixSum[array.Length - 1] = array[array.Length - 1];
            for (int i = array.Length - 2; i > -1; i--)
            {
                suffixSum[i] = suffixSum[i + 1] + array[i];
            }
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (Math.Abs(prefixSum[i] - suffixSum[i]) < accuracy)
                {
                    return i;
                }
            }
            return null;
        }
    }
}
