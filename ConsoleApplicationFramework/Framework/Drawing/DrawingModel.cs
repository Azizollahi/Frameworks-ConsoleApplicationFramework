using System;
using ConsoleApplicationFramework.Framework.Frames.Models;

namespace ConsoleApplicationFramework.Framework.Drawing {
	public class DrawingModel {
		public Point Point { get; set; }
		public byte Content { get; set; }
		public ConsoleColor Color { get; set; }
		public DrawingModel(Point point, byte content, ConsoleColor color) {
			Point = point;
			Content = content;
			Color = color;
		}
	}
}