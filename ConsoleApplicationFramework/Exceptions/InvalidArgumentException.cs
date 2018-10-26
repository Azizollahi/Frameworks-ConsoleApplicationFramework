using System;

namespace ConsoleApplicationFramework.Exceptions {
	public class InvalidArgumentException : Exception {
		public InvalidArgumentException(string message): base(message) {
		}
	}
}