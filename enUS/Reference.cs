using System;
using System.Xml.Serialization;

namespace RoadbookUnifiedModel.enUS
{
	[Serializable]
	public partial class Reference
	{
		[XmlElement("Numero")]
		public int Number { get; set; }

		[XmlElement("Km")]
		public decimal Km { get; set; }

		[XmlElement("Parcial")]
		public decimal Partial { get; set; }

		[XmlElement("Afer")]
		public bool Calibation { get; set; }

		[XmlElement("NumeroTrecho")]
		public int LegNumber { get; set; }

		[XmlElement("Zerar")]
		public bool Zero { get; set; }
	}
}
