using Cysharp.Threading.Tasks;
using Infrastructure.Services.Animation;
using Infrastructure.Services.StaticData;
using UnityEngine;

namespace UI.Windows
{
	public class RestartButtonAnimator : IRestartButtonAnimator
	{
		private readonly StaticDataService _staticDataService;
		private readonly IRotator _rotator;

		public RestartButtonAnimator(StaticDataService staticDataService, IRotator rotator)
		{
			_staticDataService = staticDataService;
			_rotator = rotator;
		}

		public async UniTask Animate(Transform transform)
		{
			float xAngle = _staticDataService.ForRestartButtonRotateAnimation.XAngle;
			float yAngle = _staticDataService.ForRestartButtonRotateAnimation.YAngle;
			float zAngle = _staticDataService.ForRestartButtonRotateAnimation.ZAngle;

			float duration = _staticDataService.ForRestartButtonRotateAnimation.RotateDuration;

			Vector3 enaValue = new Vector3(xAngle, yAngle, zAngle);

			await _rotator.DoRotate(transform, enaValue, duration);
		}
	}
}