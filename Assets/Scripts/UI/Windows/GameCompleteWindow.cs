using Cysharp.Threading.Tasks;
using DG.Tweening;
using Events;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows
{
	public class GameCompleteWindow : MonoBehaviour
	{
		public Button RestartButton;

		private IGameRestartEvent _gameRestartEvent;
		private IRestartButtonAnimator _restartButtonAnimator;

		[Inject]
		public void Constructor(IGameRestartEvent gameRestartEvent, IRestartButtonAnimator restartButtonAnimator)
		{
			_gameRestartEvent = gameRestartEvent;
			_restartButtonAnimator = restartButtonAnimator;
		}

		private void Awake() => 
			RestartButton.onClick.AddListener(Restart);

		private void OnDestroy() => 
			DOTween.Kill(RestartButton.transform);

		private async void Restart()
		{
			_gameRestartEvent.CallGameRestartedEvent();

			DisableButton();

			await PlayButtonAnimation();
		}

		private async UniTask PlayButtonAnimation() => 
			await _restartButtonAnimator.Animate(RestartButton.transform);

		private void DisableButton() => 
			RestartButton.interactable = false;
	}
}