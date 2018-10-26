using System.Collections.Generic;
using System.Linq;
using ConsoleApplicationFramework.Framework.Exceptions;
using ConsoleApplicationFramework.Framework.Frames.Models;

namespace ConsoleApplicationFramework.Framework.Frames.Content {
	public class Map {
		private List<List<Cell>> _table;
		private Size _size;
		private Cell _defaultCell;
		public Map(Size size,Cell defaultCell) {
			_size = size;
			_defaultCell = defaultCell;
			Initialize();
		}
		public void SetRow(Point point, int length, Cell cell) {
			CheckPosition(length, point.YPosition);
			Point localPoint = new Point();
			localPoint.YPosition = point.YPosition;
			for (int xIndex = 0; xIndex < length; xIndex++) {
				localPoint.XPosition = point.XPosition + xIndex;
				SetCell(localPoint, cell);
			}
		}
		public void SetRow(Point point, List<Cell> row) {
			CheckPosition(row.Count, point.YPosition);
			Point localPoint = new Point();
			localPoint.YPosition = point.YPosition;
			for (int xIndex = 0; xIndex < row.Count; xIndex++) {
				localPoint.XPosition = point.XPosition + xIndex;
				SetCell(localPoint, row[xIndex]);
			}
			
		}
		
		public void SetCell(Point point, Cell cell) {
			CheckPosition(point.XPosition, point.YPosition);
			_table[point.YPosition][point.XPosition] = cell;
		}
		
		public Cell GetCell(Point point) {
			return _table
				.ElementAt(point.YPosition).
				ElementAt(point.XPosition);
		}

		public int YLength() {
			return _table.Count;
		}

		public int XLength() {
			var length = _table.FirstOrDefault()?.Count;
			return (length ?? 0);
		}
		
		private void Initialize() {
			_table = new List<List<Cell>>();
			for (var counter = 0; counter < _size.Height; counter++) {
				var row = new List<Cell>();
				_table.Add(row);
				for (int rowCounter = 0; rowCounter < _size.Width; rowCounter++) {
					row.Add(_defaultCell);
				}
			}
		}

		private void CheckPosition(int width, int height) {
			if (width > _size.Width || width < 0)
				throw new InvalidXPositionException($"Ending X axis: {width} is out of range. max width: {_size.Width}");
			if (height > _size.Height || height < 0)
				throw new InvalidYPositionException($"Ending Y axis: {height} is out of range. max height: {_size.Height}");
		}
	}
}