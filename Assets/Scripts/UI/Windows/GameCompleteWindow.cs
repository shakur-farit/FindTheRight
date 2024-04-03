using Infrastructure.Services.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows
{
	public class GameCompleteWindow : MonoBehaviour
	{
		public Button RestartButton;

		private bool _canButtonRotate;
		private IRestartable _restartable;

		[Inject]
		public void Constructor(IRestartable restartable) => 
			_restartable = restartable;

		private void Awake() => 
			RestartButton.onClick.AddListener(Restart);

		private void Update()
		{
			if(_canButtonRotate)
				RotateButton();
		}

		private void Restart()
		{
			_restartable.RestartScene();
			TurnOnButtonRotate();
		}

		private void TurnOnButtonRotate() => 
			_canButtonRotate = true;

		private void RotateButton() => 
			RestartButton.transform.Rotate(0,0,-140 * Time.deltaTime);
	}
}