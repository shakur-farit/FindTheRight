using Events;
using UI.Services.Window;
using UnityEngine;
using Zenject;

namespace UI.Windows
{
	public class MainMenuWindow : WindowBase
	{
		private IGameStartEvent _eventor;

		[Inject]
		public void Constructor(IGameStartEvent eventor) => 
			_eventor = eventor;

		protected override void OnAwake() => 
			ActionButton.onClick.AddListener(StartGamePlay);

		public void StartGamePlay()
		{
			_eventor.CallGameStartedEvent();

			CloseWindow();
		}

		protected override void CloseWindow() => 
			WindowsService.Close(WindowId.MainMenu);
	}
}