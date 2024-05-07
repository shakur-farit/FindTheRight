using Cysharp.Threading.Tasks;
using Infrastructure.Services.Animation;
using UnityEngine;

namespace CellContent
{
	public class ContentAnimator : IContentAnimator
	{
		private readonly IShaker _shaker;
		private readonly IBouncer _bouncer;

		private const float ScalingValue = 1.3f;
		private const float Duration = 0.5f;

		public ContentAnimator(IShaker shaker, IBouncer bouncer)
		{
			_shaker = shaker;
			_bouncer = bouncer;
		}

		public void DoShakeEffect(Transform transform)
		{
			float duration = 0.4f;
			float strength = 0.5f;
			int vibrato = 10;
			float random = 20f;

			_shaker.DoShakeEffect(transform, duration, strength, vibrato, random);
		}

		public async UniTask BounceContent(Transform transform) =>
			await _bouncer.DoBounceEffect(transform, ScalingValue, Duration);
	}
}