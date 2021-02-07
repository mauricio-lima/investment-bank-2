using System;
using System.Collections.Generic;
using System.Text;

namespace investment_bank
{
	public class Trade : ITrade
	{
		public double	Value			{ get; }
		public string	ClientSector	{ get; }
		public DateTime NextPaymentDate	{ get; }
		public string	Category		{ get; }
	}
}
