using System.Collections;
using UnityEngine;

namespace FX
{
	public class FXDestroyer : MonoBehaviour
	{
		private const int TimeToDestroy = 3;

		private void Start() => 
			StartCoroutine(DestroyWithTime(TimeToDestroy));

		private void OnDestroy() => 
			StopAllCoroutines();

		private IEnumerator DestroyWithTime(int timeToDestroy)
		{
			yield return new WaitForSeconds(timeToDestroy);
			Destroy(gameObject);
		}
	}
}
