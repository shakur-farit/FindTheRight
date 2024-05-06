using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using StaticData;
using UnityEngine;

namespace CellContent
{
	public interface IContentGenerator
	{
		UniTask GenerateContent(Transform transform, List<ContentStaticData> currentContentList);
	}
}