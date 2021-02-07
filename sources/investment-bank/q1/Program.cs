using System;
using System.Collections.Generic;


namespace investment_bank
{
	class Program
	{
		static Input ReadInput()
		{
			Input input = new Input();

			input.trades.Add(new Trade());		
			
			return input;
		}


		static void Process(Input input)
		{
			foreach(ITrade itrade in input.trades)
			{
				Trade trade = itrade as Trade;
				Console.WriteLine("  {0,18}  {1,-10}  {2,-10}  {3,15}", trade.Value.ToString("#,##0.00"), trade.ClientSector, trade.NextPaymentDate.ToString("dd/MM/yyyy"), trade.Category);
			}
		}


		static void Main(string[] args)
		{
			Console.WriteLine("Trades");
			Console.WriteLine();

			try
			{
				Process(ReadInput());
			}
			catch (Exception)
			{

			}
			
		}
	}
}

