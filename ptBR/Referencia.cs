using System;

namespace RoadbookUnifiedModel.ptBR
{
	[Serializable]
	public class Referencia
	{
		public int Numero { get; set; }

		public decimal Km { get; set; }

		public decimal Parcial { get; set; }

		public bool Afer { get; set; }

		public int NumeroTrecho { get; set; }

		public bool Zerar { get; set; }

		public string ImgTulipa { get; set; }

		public string Observacoes { get; set; }
	}
}
