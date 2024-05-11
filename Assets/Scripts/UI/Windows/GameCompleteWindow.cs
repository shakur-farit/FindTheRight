using Cysharp.Threading.Tasks;
using DG.Tweening;
using Events;
using UI.Services.Window;
using UnityEngine;
using Zenject;

namespace UI.Windows
{
	public class GameCompleteWindow : WindowBase
	{
		private IGameRestartEvent _gameRestartEvent;
		private IRestartButtonAnimator _restartButtonAnimator;

		[Inject]
		public void Constructor(IGameRestartEvent gameRestartEvent, IRestartButtonAnimator restartButtonAnimator)
		{
			_gameRestartEvent = gameRestartEvent;
			_restartButtonAnimator = restartButtonAnimator;
		}

		protected override void OnAwake() => 
			ActionButton.onClick.AddListener(Restart);

		private void OnDestroy() => 
			DOTween.Kill(ActionButton.transform);

		private async void Restart()
		{
			_gameRestartEvent.CallGameRestartedEvent();

			DisableButton();

			CloseWindow();

			await PlayButtonAnimation();
		}

		private async UniTask PlayButtonAnimation() => 
			await _restartButtonAnimator.Animate(ActionButton.transform);

		private void DisableButton() => 
			ActionButton.interactable = false;

		protected override async void CloseWindow()
		{
			await Animator.DoFadeOut();
			WindowsService.Close(WindowId.GameComplete);
		}
	}
}