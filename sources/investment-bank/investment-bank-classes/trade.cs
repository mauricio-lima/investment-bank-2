using System;
using System.Collections.Generic;
using System.Text;

namespace investment_bank
{
	public class Trade : ITrade
	{
		private double mValue;
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
		public string	ClientSector	{ get; }
		public DateTime NextPaymentDate	{ get; }
		public string	Category		
		{ 
			get => this.mCategory; 
		}

		public Trade()
		{
			this.mCategory = "DEFAULTED";
		}
	}
}

