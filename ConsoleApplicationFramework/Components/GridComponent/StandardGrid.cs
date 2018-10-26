using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplicationFramework.Components.EmptyComponent;
using ConsoleApplicationFramework.Exceptions;
using ConsoleApplicationFramework.Framework.Drawing;
using ConsoleApplicationFramework.Framework.Frames;
using ConsoleApplicationFramework.Framework.Frames.Models;

namespace ConsoleApplicationFramework.Components.GridComponent {
	public class StandardGrid : AFrame, Grid {
		private List<List<Frame>> _components;
		private int _horizontalCount;
		private int _verticalCount;
		private int _maxAllowedWidthSize;
		private int _maxAllowedHeigthSize;
		public StandardGrid(int horizontalCount, int verticalCount, Point point, Size size) : base(point, size) {
			_verticalCount = verticalCount;
			_horizontalCount = horizontalCount;
			Initialize();
		}

		public StandardGrid(int horizontalCount, int verticalCount, Size size) : base(size) {
			_verticalCount = verticalCount;
			_horizontalCount = horizontalCount;
			Initialize();
		}

		private void Initialize() {
			_maxAllowedHeigthSize = Size.Height / _verticalCount;
			_maxAllowedWidthSize = Size.Width / _horizontalCount;
			var vCounter = 0;
			while (vCounter != _verticalCount) {
				var hCounter = 0;
				var hComponents = new List<Frame>(_horizontalCount);
				while (hCounter != _horizontalCount) {
					var componentPoint = AccurateTheChildPoint(hCounter, vCounter);
					hComponents.Add(new EmptyFrame(componentPoint,new Size(_maxAllowedWidthSize, _maxAllowedHeigthSize)));
					hCounter++;
				}
				_components.Add(hComponents);
				vCounter++;
			}
		}
		protected override void ConstructMap() {
			_components = new List<List<Frame>>(Size.Height);
			
		}

		public void Add(int horizontalNum, int verticalNum, Frame frame) {
			CheckSize(frame.GetSize().Width, frame.GetSize().Height);
			frame.SetPosition(AccurateTheChildPoint(horizontalNum, verticalNum));
			_components[verticalNum][horizontalNum] = frame;
		}
		public override void Draw(Drawer drawer) {
			foreach (var componentArray in _components) {
				foreach (var frame in componentArray) {
					frame.Draw(drawer);
				}
			}
		}
		private void CheckSize(int width, int height) {
			if(width > _maxAllowedWidthSize || height > _maxAllowedHeigthSize)
				throw new InvalidArgumentException("Height/Width of selected frame is not compatible with this grid system");
			if (width <= 0) throw new ArgumentOutOfRangeException();
			if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height));
		}

		private Point AccurateTheChildPoint(int hNum, int vNum) {
			return new Point((hNum * _maxAllowedWidthSize)+ Point.XPosition, (vNum * _maxAllowedHeigthSize)+ Point.YPosition);
		}
		
	}
}