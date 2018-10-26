using ConsoleApplicationFramework.Framework.Frames;
using ConsoleApplicationFramework.Framework.Frames.Content;
using ConsoleApplicationFramework.Framework.Frames.Models;

namespace ConsoleApplicationFramework.Components.EmptyComponent {
	public class EmptyFrame : AFrame {
		public EmptyFrame(Point point, Size size) : base(point, size) { }
		public EmptyFrame(Size size) : base(size) { }
		protected override void ConstructMap() {
			Map = new Map(Size, new CharacterCellImpl((byte)' '));
		}
	}
}