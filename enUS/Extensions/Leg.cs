using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;

namespace RoadbookUnifiedModel.enUS
{
	public partial class Leg
	{
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public string Tipo
		{
			get { return ((char)LegType).ToString(); }
			set { LegType = (LegTypes)value[0]; }
		}
		
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public string TempoInicial
		{
			get { return TimeInitial.ToString(@"hh\:mm\:ss\.ff"); }
			set { TimeInitial = TimeSpan.ParseExact(value, @"hh\:mm\:ss\.ff", CultureInfo.InvariantCulture); }
		}
		
		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		public string Duracao
		{
			get { return Duration.ToString(@"hh\:mm\:ss\.ff"); }
			set { Duration = TimeSpan.ParseExact(value, @"hh\:mm\:ss\.ff", CultureInfo.InvariantCulture); }
		}
	}
}