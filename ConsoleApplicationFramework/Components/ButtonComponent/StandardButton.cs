using System;
using ConsoleApplicationFramework.Framework.Frames;
using ConsoleApplicationFramework.Framework.Frames.Content;
using ConsoleApplicationFramework.Framework.Frames.Models;
using ConsoleApplicationFramework.Framework.Utilities;

namespace ConsoleApplicationFramework.Components.ButtonComponent {
	public class StandardButton : AFrame, Button {
		public string Caption { get; set; }
		public StandardButton(Point point, Size size) : base(point, size) { }
		public StandardButton(Size size) : base(size) { }
		protected override void ConstructMap() {
			Map = new Map(Size, new CharacterCellImpl((byte)' '));
			SetupMapForTop();
			SetupMapForSides();
			SetupMapForBottom();
		}

		private void SetupMapForTop() {
			Map.SetCell(new Point(0, 0), new CharacterCellImpl((byte)'+'));
			Map.SetRow(new Point(1, 0), Size.Width-2, new CharacterCellImpl((byte)'-'));
			Map.SetCell(new Point(Size.Width - 1, 0), new CharacterCellImpl((byte)'+'));
		}

		private void SetupMapForSides() {
			for (var yPos = 1; yPos < Size.Height; yPos++) {
				Map.SetCell(new Point(0, yPos), new CharacterCellImpl((byte)'|'));
				Map.SetCell(new Point(Size.Width-1, yPos), new CharacterCellImpl((byte)'|'));
			}
		}

		private void SetupMapForBottom() {
			Map.SetCell(new Point(0, Size.Height-1), new CharacterCellImpl((byte)'+'));
			Map.SetRow(new Point(1, Size.Height-1), Size.Width-2, new CharacterCellImpl((byte)'-'));
			Map.SetCell(new Point(Size.Width - 1, Size.Height-1), new CharacterCellImpl((byte)'+'));
			
		}

		public void SetCaption(string name) {
			if (name.Length > Map.XLength() - 2)
				throw new InvalidNameException("Button caption length is larger that button size");
			Caption = name;
			SetCaptionInMap();
			
		}

		public string GetCaption() {
			return Caption;
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

	public class InvalidNameException : Exception {
		public InvalidNameException(string message) : base(message){
		}
	}
}