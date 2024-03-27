using System.Collections;
using StaticEvents;
using UnityEngine;

namespace UI.Windows
{
	public class LoadingWindow : MonoBehaviour
	{
		private const float SecondsToDestroy = 2;

		private void Start() => 
			StartCoroutine(StartGamePlay());

		private IEnumerator StartGamePlay()
		{
			yield return new WaitForSeconds(SecondsToDestroy);
			StaticEventsHandler.CallStartedGamePlayEvent();
			Destroy(gameObject);
		}
	}
}