using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;

namespace RoadbookUnifiedModel.ptBR
{
	[Serializable]
	public partial class Trecho
	{
		[XmlElement("Tipo")]
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public string TipoChar
		{
			get { return ((char)Tipo).ToString(); }
			set { Tipo = (Tipos)value[0]; }
		}
		
		[XmlElement("TempoInicial")]
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public string TempoInicialString
		{
			get { return TempoInicial.ToString(@"hh\:mm\:ss\.ff"); }
			set { TempoInicial = TimeSpan.ParseExact(value, @"hh\:mm\:ss\.ff", CultureInfo.InvariantCulture); }
		}
		
		[XmlElement("Duracao")]
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public string DuracaoString
		{
			get { return Duracao.ToString(@"hh\:mm\:ss\.ff"); }
			set { Duracao = TimeSpan.ParseExact(value, @"hh\:mm\:ss\.ff", CultureInfo.InvariantCulture); }
		}
	}
}