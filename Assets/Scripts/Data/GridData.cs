using System;
using UnityEngine.Serialization;

namespace Data
{
	[Serializable]
	public class GridData
	{
		public int RowsNumber;
		public int ColumnNumber;
		[FormerlySerializedAs("Size")] public float CellSize;
	}
}