using ConsoleApplicationFramework.Framework.Frames;
using ConsoleApplicationFramework.Framework.Frames.Content;
using ConsoleApplicationFramework.Framework.Frames.Models;
using ConsoleApplicationFramework.Framework.Reading;

namespace ConsoleApplicationFramework.Components.TextBoxComponent {
	public class StandardTexBox : AFrame, TexBox, Inputable {
		private string _value;
		public StandardTexBox(Point point, Size size) : base(point, size) { }
		public StandardTexBox(Size size) : base(size) { }
		protected override void ConstructMap() {
			Map = new Map(Size, new CharacterCellImpl((byte)' '));
			SetupMapForTop();
			SetupMapForSides();
			SetupMapForBottom();
		}

		public string GetValue() {
			return _value;
		}

		public void SetValue(string value) {
			_value = value;
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
	}
}