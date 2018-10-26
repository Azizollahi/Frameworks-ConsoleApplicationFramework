using System.Collections.Generic;

namespace ConsoleApplicationFramework.Framework.Reading {
	public class KeyStrokeContentSuccessor : KeyStokeHandler {
		private List<Inputable> _subscribers;
		private KeyStokeHandler _successor;
		public KeyStrokeContentSuccessor(List<Inputable> subscribers) {
			_subscribers = subscribers;
			
		}

		public bool CanHandle(KeyStroke keyStroke) {
			if (keyStroke.KeyControl == KeyControl.Content || _successor.CanHandle(keyStroke))
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
						subscriber.SetValue(subscriber.GetValue()+keyStroke.Content);
					}
				}
			}
		}
	}
}