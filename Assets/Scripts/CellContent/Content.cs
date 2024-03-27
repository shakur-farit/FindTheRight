using UnityEngine;

namespace CellContent
{
	public class Content : MonoBehaviour
	{
		[field: SerializeField] public string ContentId { get; private set; }

		private void Start() => 
			ContentId = ContentId.ToUpper();
	}
}
