using CellContent;
using UnityEngine;

namespace Utility
{
	public static class HelperUtility
	{
		public static void NumberSpriteNormalize(ContentType type, Transform transform, string id)
		{
			if (type != ContentType.Numbers) 
				return;

			transform.localScale = new Vector2(0.2f, 0.2f);

			if (id == "7" || id == "8")
				transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
		}
	}
}