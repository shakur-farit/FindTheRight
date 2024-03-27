using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;

namespace CellContent
{
	public class ContentTypeRandomizer
	{
		private readonly StaticDataService _staticDataService;
		private readonly RandomService _randomService;

		public ContentTypeRandomizer(StaticDataService staticDataService, RandomService randomService)
		{
			_staticDataService = staticDataService;
			_randomService = randomService;
		}

		public List<Content> GetRandomContentList()
		{
			List<List<Content>> contentList = new List<List<Content>>
			{
				_staticDataService.ForLettersContent.ToList(),
				_staticDataService.ForNumbersContent.ToList()
			};

			int randomIndex = _randomService.Next(0, contentList.Count);

			return contentList[randomIndex];
		}
	}
}