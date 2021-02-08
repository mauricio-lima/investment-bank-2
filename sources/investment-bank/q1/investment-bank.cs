using System;
using System.Collections.Generic;


namespace investment_bank
{
	public class Input
	{
		public DateTime		date;
		public List<ITrade> trades { get; private set; }

		public Input()
		{
			trades = new List<ITrade>();
		}
	}
}
