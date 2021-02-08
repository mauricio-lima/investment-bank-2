using System;
using System.Collections.Generic;


namespace investment_bank
{
	public interface ITrade
	{
		double Value { get; }
		string ClientSector { get; }
		DateTime NextPaymentDate { get; }
	}

	public interface IRule
	{
		Boolean Match(ITrade trade);
	}

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
