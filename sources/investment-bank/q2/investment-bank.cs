using System;
using System.Collections.Generic;


namespace investment_bank
{
	public interface ITrade
	{
		double   Value					{ get; }
		string   ClientSector			{ get; }
		DateTime NextPaymentDate		{ get; }
		Boolean  IsPoliticallyExposed	{ get; }
	}

	public interface IRule
	{
		Boolean Match(ITrade trade);
		string  Category				{ get;  }
	}

}
