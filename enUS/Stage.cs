using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Xml.Serialization;

namespace RoadbookUnifiedModel.enUS
{
	[Serializable]
	[XmlRoot("Etapa")]
	public class Stage
	{
		[XmlArray("Trechos")]
		[XmlArrayItem("Trecho")]
		public List<Leg> Legs { get; set; }

		[XmlArray("Referencias")]
		[XmlArrayItem("Referencia")]
		public List<Reference> References { get; set; }

		[XmlElement("Senha")]
		public string Password { get; set; }

		public void SaveXml(string xmlPath)
		{
			var x = new XmlSerializer(this.GetType());
			using (var sw = new StreamWriter(xmlPath))
			{
				x.Serialize(sw, this);
			}
		}

		public void LoadXml(string xmlPath)
		{
			var etapa = new Stage();

			var x = new XmlSerializer(this.GetType());
			using (var sr = new StreamReader(xmlPath))
			{
				etapa = (Stage)x.Deserialize(sr);
			}

			this.Legs = etapa.Legs;
			this.References = etapa.References;
			this.Password = etapa.Password;
		}
	}
}
