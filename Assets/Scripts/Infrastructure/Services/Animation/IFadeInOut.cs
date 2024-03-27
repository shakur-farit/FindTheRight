using System.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Animation
{
	public interface IFadeInOut
	{
		Task DoFade(CanvasGroup canvasGroup, float endValue, float duration);
	}
}