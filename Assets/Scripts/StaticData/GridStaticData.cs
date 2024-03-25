using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Grid Static Data", menuName = "ScriptableObjects/Static Data/Grid")]
	public class GridStaticData : ScriptableObject
	{
		[Range(1, 100)] public int RowsNumber;
		[Range(1, 100)] public int ColumnsNumber;
		[Range(0.5f, 10f)] public float CellSize;
	}
}