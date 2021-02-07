using System;
using PlayStationSharp.Model.ErrorModelJsonTypes;

namespace PlayStationSharp.Exceptions
{
	[Serializable]
	public class CouldNotWakeUpPlayStation : Exception
	{
		public Error Error;

		public CouldNotWakeUpPlayStation(Error error) => Error = error;
	}
}
