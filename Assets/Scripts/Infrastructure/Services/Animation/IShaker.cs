using System.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Animation
{
	public interface IShaker
	{
		Task DoShakeEffect(Transform transform, float duration, float strength, int vibrato, float randomness);
	}
}