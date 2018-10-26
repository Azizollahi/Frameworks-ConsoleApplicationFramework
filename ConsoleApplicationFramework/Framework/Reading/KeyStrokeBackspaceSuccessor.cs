using System.Collections.Generic;

namespace ConsoleApplicationFramework.Framework.Reading {
	public class KeyStrokeBackspaceSuccessor : KeyStokeHandler {
		private List<Inputable> _subscribers;
		private KeyStokeHandler _successor;
		public KeyStrokeBackspaceSuccessor(List<Inputable> subscribers) {
			_subscribers = subscribers;
		}

		public bool CanHandle(KeyStroke keyStroke) {
			if(keyStroke.KeyControl == KeyControl.Backspace || _successor.CanHandle(keyStroke))
				return true;
			return false;
		}
		public void SetSuccessor(KeyStokeHandler successor) {
			_successor = successor;
		}
		public void Handle(KeyStroke keyStroke) {
			if(_successor.CanHandle(keyStroke))
				_successor.Handle(keyStroke);
			else {
				lock (_subscribers) {
					foreach (var subscriber in _subscribers) {
						subscriber.SetValue(
							subscriber.GetValue().Substring(0,
								subscriber.GetValue().Length)
						);
					}
				}
			}
		}
	}
}