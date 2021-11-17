using System;
#pragma warning disable S2368
#pragma warning disable S3776

namespace LookingForArrayElements
{
    public static class DecimalCounter
    {
        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i] == null)
                {
                    throw new ArgumentNullException(nameof(ranges));
                }

                if (ranges[i].Length != 2 && ranges[i].Length != 0)
                {
                    throw new ArgumentException("Arrays of range starts and range ends contain different number of elements.");
                }
            }

            if (arrayToSearch.Length == 0 && ranges.Length == 0)
            {
                return 0;
            }

            var suitable = Array.Empty<decimal>();
            for (int i = 0; i < arrayToSearch.Length; i++)
            {
                for (int j = 0; j < ranges.Length; j++)
                {
                    if (ranges[j].Length != 0 && arrayToSearch[i] >= ranges[j][0] && arrayToSearch[i] <= ranges[j][1] && Dublicate(ref suitable, ref arrayToSearch[i]))
                    {
                        Array.Resize(ref suitable, suitable.Length + 1);
                        suitable[suitable.Length - 1] = arrayToSearch[i];
                    }
                }
            }

            return suitable.Length;
        }

        /// <summary>
        /// Searches an array of decimals for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="ranges">One-dimensional, zero-based <see cref="Array"/> of range arrays.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetDecimalsCount(decimal[] arrayToSearch, decimal[][] ranges, int startIndex, int count)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (ranges is null)
            {
                throw new ArgumentNullException(nameof(ranges));
            }

            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i] == null)
                {
                    throw new ArgumentNullException(nameof(ranges));
                }

                if (ranges[i].Length != 2 && ranges[i].Length != 0)
                {
                    throw new ArgumentException("Arrays of range starts and range ends contain different number of elements.");
                }
            }

            if (arrayToSearch.Length == 0 && ranges.Length == 0)
            {
                return 0;
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is less than zero");
            }

            if (startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "startIndex is greater than arrayToSearch.Length");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "count is less than zero");
            }

            if (startIndex + count > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "startIndex + count > arrayToSearch.Length");
            }

            var suitable = Array.Empty<decimal>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                for (int j = 0; j < ranges.Length; j++)
                {
                    if (ranges[j].Length != 0 && arrayToSearch[i] >= ranges[j][0] && arrayToSearch[i] <= ranges[j][1] && Dublicate(ref suitable, ref arrayToSearch[i]))
                    {
                       Array.Resize(ref suitable, suitable.Length + 1);
                       suitable[suitable.Length - 1] = arrayToSearch[i];
                    }
                }
            }

            return suitable.Length;
        }

        private static bool Dublicate(ref decimal[] array, ref decimal value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
