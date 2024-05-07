using Events;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows
{
	public class GameCompleteWindow : MonoBehaviour
	{
		public Button RestartButton;

		private bool _canButtonRotate;
		private IGameRestartEvent _gameRestartEvent;

		[Inject]
		public void Constructor(IGameRestartEvent gameRestartEvent) => 
			_gameRestartEvent = gameRestartEvent;

		private void Awake() => 
			RestartButton.onClick.AddListener(Restart);

		private void Update()
		{
			if(_canButtonRotate)
				RotateButton();
		}

		private void Restart()
		{
			_gameRestartEvent.CallGameRestartedEvent();

			TurnOnButtonRotate();
		}

		private void TurnOnButtonRotate() => 
			_canButtonRotate = true;

		private void RotateButton() => 
			RestartButton.transform.Rotate(0,0,-140 * Time.deltaTime);
	}
}