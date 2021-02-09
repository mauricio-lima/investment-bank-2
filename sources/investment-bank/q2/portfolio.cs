using System;
using System.Collections.Generic;
using System.Text;

namespace investment_bank
{
	public class Portfolio
	{
		private List<ITrade> mTrades;
		private DateTime     mReferenceDate;

		class DefaultedRule : IRule
		{
			private DateTime mReferenceDate;

			public Boolean Match(ITrade trade)
			{
				double late = (this.mReferenceDate - trade.NextPaymentDate).TotalDays;
				if (late > 30)
				{
					this.Category = "DEFAULTED";
					return true;
				}

				this.Category = "UNKNOWN";
				return false;
			}

			public string Category { get; private set; }

			public DefaultedRule(DateTime ADate)
			{
				this.mReferenceDate = ADate;
			}
		}

		class MediumRiskRule : IRule
		{
			public Boolean Match(ITrade trade)
			{
				if ((trade.Value > 1_000_000) && (trade.ClientSector == "Public"))
				{
					this.Category = "MEDIUMRISK";
					return true;
				}

				this.Category = "UNKNOWN";
				return false;
			}

			public string Category { get; private set; }
		}


		class HighRiskRule : IRule
		{
			public Boolean Match(ITrade trade)
			{
				if ( (trade.Value > 1_000_000) && (trade.ClientSector == "Private") )
				{
					this.Category = "HIGHRISK";
					return true;
				}

				this.Category = "UNKNOWN";
				return false;
			}

			public string Category { get; private set; }
		}

		class PoliticallyExposedRiskRule : IRule
		{
			public Boolean Match(ITrade trade)
			{
				if ( trade.IsPoliticallyExposed )
				{
					this.Category = "PEP";
					return true;
				}

				this.Category = "DEFAULTED";
				return false;
			}

			public string Category { get; private set; }
		}

		//public List<ITrade> Trades
		//{
		//	get => this.mTrades;
		//}

		public void Add(double Value, string ClientSector, DateTime NextPaymentDate, Boolean IsPoliticallyExposed)
		{
			Trade trade = new Trade();

			trade.Rules.Add(new PoliticallyExposedRiskRule());
			trade.Rules.Add(new DefaultedRule(this.mReferenceDate));
			trade.Rules.Add(new MediumRiskRule());
			trade.Rules.Add(new HighRiskRule  ());

			trade.Value = Value;
			trade.ClientSector = ClientSector;
			trade.NextPaymentDate = NextPaymentDate;
			trade.IsPoliticallyExposed = IsPoliticallyExposed;
			
			this.mTrades.Add(trade);
		}

		public void Display()
		{
			Console.WriteLine();
			Console.WriteLine("  Trades");
			Console.WriteLine();
			Console.WriteLine("  +--------------------+--------------+--------------+-----------------+");
			Console.WriteLine("  |                    |              |     Next     |                 |");
			Console.WriteLine("  |       Value        |    Client    |    Payment   |    Category     |");
			Console.WriteLine("  |                    |    Sector    |     Date     |                 |");
			Console.WriteLine("  +--------------------+--------------+--------------+-----------------+");

			foreach (ITrade itrade in this.mTrades)
			{
				Trade trade = itrade as Trade;
				Console.WriteLine("  | {0,18} |  {1,-11} | {2,12} | {3,-15} |", trade.Value.ToString("#,##0.00"), trade.ClientSector, trade.NextPaymentDate.ToString("dd/MM/yyyy"), trade.Category);
			}

			Console.WriteLine("  +--------------------+--------------+--------------+-----------------+");
			Console.WriteLine();
		}

		public Portfolio(DateTime ADate)
		{
			this.mTrades = new List<ITrade>();
			this.mReferenceDate = ADate;
		}
	}
}
