using System;
using ConsoleApplicationFramework.Framework.Frames.Models;

namespace ConsoleApplicationFramework.Framework.Drawing {
	public interface Drawer {
		void Draw(Point point, byte content, ConsoleColor color = ConsoleColor.White);
	}
}