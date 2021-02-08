using System;
using System.Collections.Generic;
using System.Text;

namespace investment_bank
{
	public class Portfolio
	{
		private List<ITrade> mTrades;

		class EmptyRule : IRule
		{
			public Boolean Match(ITrade trade)
			{
				return false;
			}
		}

		public List<ITrade> Trades
		{
			get => this.mTrades;
		}

		public void Add(double Value, string ClientSector, DateTime NextPaymentDate)
		{
			Trade trade = new Trade(Value, ClientSector, NextPaymentDate);

			trade.Rules.Add(new EmptyRule());

			this.mTrades.Add(trade);
		}

		public void Display()
		{
			foreach (ITrade itrade in this.mTrades)
			{
				Trade trade = itrade as Trade;
				Console.WriteLine(" {0,18}  {1,-10}  {2,-10}  {3,15}", trade.Value.ToString("#,##0.00"), trade.ClientSector, trade.NextPaymentDate.ToString("dd/MM/yyyy"), trade.Category);
			}
		}

		public Portfolio()
		{
			this.mTrades = new List<ITrade>();
		}
	}
}
