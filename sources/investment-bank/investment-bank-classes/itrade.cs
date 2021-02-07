using System;
using System.Collections.Generic;
using System.Text;

namespace investment_bank
{
	public interface ITrade
	{
		double Value				{ get; }
		string ClientSector			{ get; }
		DateTime NextPaymentDate	{ get; }
	}
}
