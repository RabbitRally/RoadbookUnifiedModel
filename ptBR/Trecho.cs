using System;
using System.Xml.Serialization;

namespace RoadbookUnifiedModel.ptBR
{
	public partial class Trecho
	{
		public int Numero { get; set; }

		[XmlIgnore]
		public Tipos Tipo { get; set; }
		
		public decimal KmInicial { get; set; }

		public decimal KmFinal { get; set; }

		[XmlIgnore]
		public TimeSpan TempoInicial { get; set; }

		[XmlIgnore]
		public TimeSpan Duracao { get; set; }

		public decimal Velocidade { get; set; }

		public decimal Parcial
		{
			get { return KmFinal - KmInicial; }
		}

		public TimeSpan TempoFinal
		{
			get { return TempoInicial + Duracao; }
		}

		public bool Zerar
		{
			get { return KmInicial == 0M; }
		}
	}
}