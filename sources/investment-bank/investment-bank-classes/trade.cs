using System;
using System.Collections.Generic;
using System.Text;

namespace investment_bank
{
	public class Trade : ITrade
	{
		private double mValue;
		private string   mClientSector;
		private DateTime mNextPaymentDate;
		private string mCategory;

		void UpdateCategory()
		{
			this.mCategory = "DEFAULTED";
		}
		public double Value
		{
			get => mValue;
			set
			{
				this.mValue = value;
				this.UpdateCategory();
			}
		}
		public string ClientSector	
		{ 
			get => mClientSector;
			set
			{
				this.mClientSector = value;
				this.UpdateCategory();
			}
		}
		
		public DateTime NextPaymentDate	
		{ 
			get => mNextPaymentDate;
			set
			{
				this.mNextPaymentDate = value;
				this.UpdateCategory();
			}
		}

		public string	Category		
		{ 
			get => this.mCategory; 
		}

		private void Initialize()
		{
			this.mCategory = "DEFAULTED";
		}

		public Trade()
		{
			this.Initialize();
		}

		public Trade(double Value, string ClientSector, DateTime NextPaymentDate)
		{
			this.mValue           = Value;
			this.mClientSector    = ClientSector;
			this.mNextPaymentDate = NextPaymentDate;

			this.Initialize();
		}
	}


	public class Portfolio
	{
		private List<ITrade> mTrades;

		public List<ITrade> Trades
		{
			get => this.mTrades;
		}

		public void Add(ITrade trade)
		{
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

