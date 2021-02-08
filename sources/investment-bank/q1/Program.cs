using System;
using System.Globalization;
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

			input.trades.Add( new Trade( 2_000_000, "Private", DateTime.Parse("12/29/2025", CultureInfo.GetCultureInfo("en-US"))) );
			input.trades.Add( new Trade(   400_000, "Public",  DateTime.Parse("07/01/2020", CultureInfo.GetCultureInfo("en-US"))) );
			input.trades.Add( new Trade( 2_000_000, "Public",  DateTime.Parse("01/02/2024", CultureInfo.GetCultureInfo("en-US"))) );
			input.trades.Add( new Trade( 3_000_000, "Public",  DateTime.Parse("10/26/2023", CultureInfo.GetCultureInfo("en-US"))) );

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

