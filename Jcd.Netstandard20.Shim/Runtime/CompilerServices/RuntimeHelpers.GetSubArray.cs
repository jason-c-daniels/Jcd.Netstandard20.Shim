#if NETSTANDARD2_0

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// ReSharper disable UnusedType.Global
// ReSharper disable CheckNamespace
namespace System.Runtime.CompilerServices;

public static partial class RuntimeHelpers
{
   /// <summary>
   /// Slices the specified array using the specified range.
   /// </summary>
   public static T[] GetSubArray<T>(T[] array, Range range)
   {
      if (array == null)
      {
         throw new ArgumentNullException(nameof(array));
      }

      (int offset, int length) = range.GetOffsetAndLength(array.Length);

      if (length == 0)
      {
         return Array.Empty<T>();
      }

      ReadOnlySpan<T> span   = array;
      var             subset = span.Slice(offset, length);

      return subset.ToArray();
   }
}
#endif // NETSTANDARD2_0