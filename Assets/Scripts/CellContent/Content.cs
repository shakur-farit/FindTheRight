using UnityEngine;
using Utility;

namespace CellContent
{
	public class Content : MonoBehaviour
	{
		public Transform Transform;
		
		public ContentType type { get; set; }
		public string ContentId { get; set; }
		public Sprite Sprite { get; set; }

		private void Start()
		{
			SpriteRenderer contentSprite = Transform.GetComponent<SpriteRenderer>();
			contentSprite.sprite = Sprite;

			ContentId = ContentId.ToUpper();

			NormalizeContentSprite();
		}

		private void NormalizeContentSprite() => 
			HelperUtility.NumberSpriteNormalize(type, Transform, ContentId);
	}
}
