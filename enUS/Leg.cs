using System;
using System.Xml.Serialization;

namespace RoadbookUnifiedModel.enUS
{
	[Serializable]
	public partial class Leg
	{
		[XmlElement("Numero")]
		public int Number { get; set; }

		[XmlIgnore]
		public LegTypes LegType { get; set; }

		[XmlElement("KmInicial")]
		public decimal KmInitial { get; set; }

		public decimal KmFinal { get; set; }

		[XmlIgnore]
		public TimeSpan TimeInitial { get; set; }

		[XmlIgnore]
		public TimeSpan Duration { get; set; }

		[XmlElement("Velocidade")]
		public decimal Speed { get; set; }

		[XmlElement("Parcial")]
		public decimal Partial
		{
			get { return KmFinal - KmInitial; }
		}

		[XmlElement("TempoFinal")]
		public TimeSpan TimeFinal
		{
			get { return TimeInitial + Duration; }
		}

		[XmlElement("Zerar")]
		public bool Zero
		{
			get { return KmInitial == 0M; }
		}
	}
}