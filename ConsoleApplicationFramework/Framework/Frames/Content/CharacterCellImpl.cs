using System;
using System.Drawing;
using ConsoleApplicationFramework.Framework.Drawing;
using Point = ConsoleApplicationFramework.Framework.Frames.Models.Point;

namespace ConsoleApplicationFramework.Framework.Frames.Content {
	public class CharacterCellImpl : CharacterCell {
		private byte _content;
		private ConsoleColor Color;
		public CharacterCellImpl(byte content, ConsoleColor color = ConsoleColor.White) {
			_content = content;
			Color = color;
		}
		
		public void Draw(Point point, Drawer drawable) {
			drawable.Draw(point, _content, Color);
		}

		public byte GetChar() {
			return _content;
		}

		public void Modify(byte content) {
			_content = content;
		}
	}
}