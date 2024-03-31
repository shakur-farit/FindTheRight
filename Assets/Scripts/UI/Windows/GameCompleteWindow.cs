using Infrastructure.Services.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows
{
	public class GameCompleteWindow : MonoBehaviour
	{
		public Button RestartButton;

		private IRestartable _restartable;

		[Inject]
		public void Constructor(IRestartable restartable) => 
			_restartable = restartable;

		private void Awake() => 
			RestartButton.onClick.AddListener(Restart);


		private void Restart() => 
			_restartable.RestartScene();
	}
}