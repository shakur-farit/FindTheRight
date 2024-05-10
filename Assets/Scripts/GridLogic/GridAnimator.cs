using Cysharp.Threading.Tasks;
using Infrastructure.Services.Animation;
using Infrastructure.Services.StaticData;
using UnityEngine;

namespace GridLogic
{
	public class GridAnimator : IGridAnimator
	{
		private readonly StaticDataService _staticDataService;
		private readonly IBouncer _bouncer;

		public GridAnimator(StaticDataService staticDataService, IBouncer bouncer)
		{
			_staticDataService = staticDataService;
			_bouncer = bouncer;
		}

		public async UniTask BounceGrid(Transform gridParent)
		{
			float scalingValue = _staticDataService.ForGridBounceAnimation.BounceScaling;
			float duration = _staticDataService.ForGridBounceAnimation.BounceDuration;

			await _bouncer.DoBounceEffect(gridParent, scalingValue, duration);
		}
	}
}