using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Events;
using Infrastructure.Services.SceneManagement;
using UI.Services.Window;
using UI.Windows.Animation;
using UnityEngine;
using Zenject;

namespace UI.Windows
{
	public class GameCompleteWindow : WindowBase
	{
		private IGameRestartEvent _gameRestartEvent;
		private IRestartButtonAnimator _restartButtonAnimator;
		private GameCompleteWindowAnimator _windowsAnimator;

		[Inject]
		public void Constructor(IGameRestartEvent gameRestartEvent, IRestartButtonAnimator restartButtonAnimator, 
			GameCompleteWindowAnimator windowsAnimator)
		{
			_gameRestartEvent = gameRestartEvent;
			_restartButtonAnimator = restartButtonAnimator;
			_windowsAnimator = windowsAnimator;
		}

		protected override void OnAwake()
		{
			ActionButton.onClick.AddListener(Restart);
			QuitButton.onClick.AddListener(QuitGame);
		}

		private void Start() => 
			FadeInWindow();

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

		protected override async void CloseWindow()
		{
			await _windowsAnimator.DoFadeOut(CanvasGroup);
			WindowsService.Close(WindowId.GameComplete);
		}

		protected override void QuitGame() => 
			Quitable.Quit();

		private async void FadeInWindow() => 
			await _windowsAnimator.DoFadeIn(CanvasGroup);

		private void DisableButton() => 
			ActionButton.interactable = false;
	}
}