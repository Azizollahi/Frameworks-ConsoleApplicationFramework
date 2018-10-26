using ConsoleApplicationFramework.Framework.Frames.Models;

namespace ConsoleApplicationFramework.Components.LableComponent {
	public class LinkedLabled : StandardLable {
		public LinkedLabled(Point point, Size size) : base(point, size) { }
		public LinkedLabled(Size size) : base(size) { }
	}
}