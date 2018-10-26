using System;

namespace ConsoleApplicationFramework.Framework.Utilities {
	public static class StringAlignment {
		public static string Centerize(this string stringToCenter, int totalLength) {
			return stringToCenter.PadLeft(((totalLength - stringToCenter.Length) / 2) 
			                              + stringToCenter.Length)
				.PadRight(totalLength);
		}
	}

	public class InvalidLengthException : Exception {
		public InvalidLengthException(string message) : base(message) {
		}
	}
}