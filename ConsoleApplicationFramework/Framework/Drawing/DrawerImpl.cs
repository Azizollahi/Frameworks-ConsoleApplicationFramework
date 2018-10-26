using System;
using AzizollahiCommons.Services;
using ConsoleApplicationFramework.Framework.Frames.Models;

namespace ConsoleApplicationFramework.Framework.Drawing {
	public class DrawerImpl : Drawer {
		private readonly Event<DrawingModel> _drawingEvent;
		public DrawerImpl(Event<DrawingModel> drawingEvent) {
			this._drawingEvent = drawingEvent;
		}
		public void Draw(Point point, byte content, ConsoleColor color = ConsoleColor.White) {
			_drawingEvent.Notify(new DrawingModel(point, content, color));
		}
	}
}