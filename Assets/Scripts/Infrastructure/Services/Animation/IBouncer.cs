using System.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Animation
{
	public interface IBouncer
	{
		Task DoBounceEffect(Transform transform, float scalingValue, float duration);
	}
}