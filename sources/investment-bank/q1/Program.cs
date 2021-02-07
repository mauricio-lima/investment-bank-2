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
				Trade trade = new Trade();
				Console.WriteLine("  {0,-12}  {1,-10}", trade.Value, trade.Category);
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

