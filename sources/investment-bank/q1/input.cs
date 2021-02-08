using System;
using System.Collections.Generic;
using System.Text;

namespace investment_bank
{
	public class Input
	{
		public DateTime     ReferenceDate	{ get; set; }
		public List<ITrade> trades			{ get; private set; }

		public Input()
		{
			trades = new List<ITrade>();
		}
	}
}
