using UnityEngine;

namespace Infrastructure.Services.SceneManagement
{
	public class SceneService : IQuitable
	{
		public void Quit()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}
	}
}