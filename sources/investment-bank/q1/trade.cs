using System;
using System.Collections.Generic;
using System.Text;

namespace investment_bank
{
	public class Trade : ITrade
	{
		private double         mValue;
		private string         mClientSector;
		private DateTime       mNextPaymentDate;
		private string         mCategory;
		private HashSet<IRule> mRules;

		void UpdateCategory()
		{
			this.ApplyRules();
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

		public string Category
		{ 
			get => this.mCategory; 
		}

		public HashSet<IRule> Rules
		{
			get => mRules;
			set
			{
				this.mRules = value;
				this.ApplyRules();
			}
		}

		private void ApplyRules()
		{
			this.mCategory = "DEFAULTED";
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


	
}

