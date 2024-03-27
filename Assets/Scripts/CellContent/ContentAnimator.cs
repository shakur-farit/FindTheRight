using DG.Tweening;
using Infrastructure.Services.Animation;
using UnityEngine;
using Zenject;

namespace CellContent
{
	public class ContentAnimator : MonoBehaviour
	{
		private IShaker _shaker;

		[Inject]
		public void Constructor(IShaker shaker) => 
			_shaker = shaker;

		private void OnDestroy() => 
			DOTween.Kill(transform);

		public void DoShakeEffect()
		{
			float duration = 0.4f;
			float strength = 0.5f;
			int vibrato = 10;
			float random = 20f;

			_shaker.DoShakeEffect(transform, duration, strength, vibrato, random);
		}
	}
}