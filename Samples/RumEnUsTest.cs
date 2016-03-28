using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoadbookUnifiedModel.enUS;

namespace ConverterTests
{
	[TestClass]
	public class RumEnUsTest
	{
		[TestMethod]
		public void SerializeTest()
		{
			Stage stage = new Stage();
			stage.Legs = new List<Leg>();
			stage.References = new List<Reference>();

			var l1 = new Leg();
			l1.Number = 1;
			l1.LegType = LegTypes.Displacement;
            l1.KmInitial = 0;
			l1.KmFinal = 1.5M;
			l1.TimeInitial = TimeSpan.Zero;
			l1.Duration = new TimeSpan(0, 3, 0);
			l1.Speed = 30;
			stage.Legs.Add(l1);

			var l2 = new Leg();
			l2.Number = 2;
			l2.LegType = LegTypes.Speed;
			l2.KmInitial = 1.5M;
			l2.KmFinal = 3M;
			l2.TimeInitial = new TimeSpan(0, 3, 0);
			l2.Speed = 45;
			l2.Duration = new TimeSpan(0, 2, 0);
			stage.Legs.Add(l2);

			var r1 = new Reference();
			r1.Number = 1;
			r1.LegNumber = 1;
			r1.Km = 0;
			r1.Partial = 0;
			r1.Zero = true;
			stage.References.Add(r1);

			var r2 = new Reference();
			r2.Number = 2;
			r2.LegNumber = 1;
			r2.Km = 0.5M;
			r2.Partial = 0.5M;
			r2.Zero = false;
			stage.References.Add(r2);

			var r3 = new Reference();
			r3.Number = 3;
			r3.LegNumber = 2;
			r3.Km = 1.5M;
			r3.Partial = 1M;
			r3.Zero = false;
			stage.References.Add(r3);

			var r4 = new Reference();
			r4.Number = 4;
			r4.LegNumber = 2;
			r4.Km = 3M;
			r4.Partial = 1.5M;
			r4.Zero = false;
			stage.References.Add(r4);

			stage.SaveXml("RumEnUsTest.xml");


			var stagePT = new RoadbookUnifiedModel.ptBR.Etapa();
			stagePT.LoadXml("RumEnUsTest.xml");
        }
	}
}
