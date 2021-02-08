using System;
using System.Collections.Generic;


namespace investment_bank
{
	class Program
	{
		class Configuration
		{
			public static Boolean wait;

			public static void Decode(string[] parameters)
			{
				int index;
				List<string> options;

				index = -1;
				while ( ++index < parameters.Length)
				{
					options = new List<string>(new string[] { "-w", "--wait" });
					Configuration.wait = (options.Contains(parameters[index].ToLower()));
				}
			}
		}

		static Input ReadInput()
		{
			Input input = new Input();

			input.ReferenceDate = DateTime.Parse("12/11/2020");

			input.trades.Add( new Trade(  400_000, "Public",  DateTime.Parse("07/01/2020")) );
			input.trades.Add( new Trade(3_000_000, "Private", DateTime.Parse("12/03/2020")) );
			input.trades.Add( new Trade(  900_000, "Public",  DateTime.Parse("15/05/2021")) );

			return input;
		}


		static void Process(Input input)
		{
			Portfolio portfolio = new Portfolio(input.ReferenceDate);

			foreach(ITrade itrade in input.trades)
			{
				portfolio.Add(itrade.Value, itrade.ClientSector, itrade.NextPaymentDate);
			}

			portfolio.Display();
		}


		static void Main(string[] args)
		{
			Configuration.Decode(args);

			Console.WriteLine("Trades");
			Console.WriteLine();

			try
			{
				Process(ReadInput());
			}
			catch (Exception e)
			{
				Console.WriteLine("EXCEPTION : {0}", e.Message);
			}

			if (Configuration.wait)
				Console.ReadKey();
		}
	}
}

