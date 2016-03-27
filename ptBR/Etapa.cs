using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace RoadbookUnifiedModel.ptBR
{
	[Serializable]
	public class Etapa
	{
		public List<Trecho> Trechos { get; set; }
		public List<Referencia> Referencias { get; set; }
		public string Senha { get; set; }

		public void SaveXml(string xmlPath)
		{
			var x = new System.Xml.Serialization.XmlSerializer(this.GetType());
			using (var sw = new StreamWriter(xmlPath))
			{
				x.Serialize(sw, this);
			}
		}

		public void LoadXml(string xmlPath)
		{
			var etapa = new Etapa();

			var x = new System.Xml.Serialization.XmlSerializer(this.GetType());
			using (var sr = new StreamReader(xmlPath))
			{
				etapa = (Etapa)x.Deserialize(sr);
			}

			this.Trechos = etapa.Trechos;
			this.Referencias = etapa.Referencias;
			this.Senha = etapa.Senha;
		}

		public void AddTrecho(string strTipo, string strNum, string strKi, string strKf, string strVouTmp, string strHrIni)
		{
			if (Trechos == null)
				Trechos = new List<Trecho>();

			Trechos.Add(ConvertToTrecho(strTipo, strNum, strKi, strKf, strVouTmp, strHrIni));
		}

		public Trecho ConvertToTrecho(string strTipo, string strNum, string strKi, string strKf, string strVouTmp, string strHrIni)
		{
			var _enUS = new CultureInfo("en-US");

			var t = new Trecho();
			t.Numero = Convert.ToInt32(strNum);
			t.Tipo = (Tipos)strTipo[0];

			t.KmInicial = Convert.ToDecimal(strKi, _enUS);
			t.KmFinal = Convert.ToDecimal(strKf, _enUS);

			string[] auxT = strHrIni.Split(':');
			string[] auxT2 = auxT[2].Replace(',', '.').Split('.');
			if (auxT2.Length == 1)
				t.TempoInicial = new TimeSpan(0, Convert.ToInt32(auxT[0]), Convert.ToInt32(auxT[1]), Convert.ToInt32(auxT2[0], _enUS));
			else
				t.TempoInicial = new TimeSpan(0, Convert.ToInt32(auxT[0]), Convert.ToInt32(auxT[1]), Convert.ToInt32(auxT2[0], _enUS), Convert.ToInt32(auxT2[1], _enUS) * 10);

			if (t.Tipo == Tipos.Velocidade)
			{
				t.Velocidade = Convert.ToDecimal(strVouTmp, _enUS);
			}
			else
			{
				string[] auxTN = strVouTmp.Split(':');
				t.Duracao = new TimeSpan(Convert.ToInt32(auxTN[0]), Convert.ToInt32(auxTN[1]), Convert.ToInt32(auxTN[2]));
			}

			return t;
		}
	}
}
