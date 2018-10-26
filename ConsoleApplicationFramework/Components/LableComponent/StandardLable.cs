using ConsoleApplicationFramework.Components.ButtonComponent;
using ConsoleApplicationFramework.Framework.Frames;
using ConsoleApplicationFramework.Framework.Frames.Content;
using ConsoleApplicationFramework.Framework.Frames.Models;
using ConsoleApplicationFramework.Framework.Utilities;

namespace ConsoleApplicationFramework.Components.LableComponent {
	public class StandardLable : AFrame {
		public string Caption { get; set; }
		public StandardLable(Point point, Size size) : base(point, size) { }
		public StandardLable(Size size) : base(size) { }
		protected override void ConstructMap() {
			Map = new Map(Size, new CharacterCellImpl((byte)' '));
		}
		public void SetCaption(string name) {
			if (name.Length > Map.XLength() - 2)
				throw new InvalidNameException("Lable caption length is larger that button size");
			Caption = name;
			SetCaptionInMap();
			
		}
		private void SetCaptionInMap() {
			var xPos = 1;
			var yPos = ((Map.YLength()-1) / 2);
			var totalLength = Map.XLength()-2;
			foreach (var captionChar in Caption.Centerize(totalLength)) {
				Map.SetCell(new Point(xPos, yPos), new CharacterCellImpl((byte)captionChar));
				xPos++;
			}
		}
	}
}