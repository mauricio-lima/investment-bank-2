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

			input.Read();

			return input;
		}


		static void Process(Input input)
		{
			Portfolio portfolio = new Portfolio(input.ReferenceDate);

			foreach(ITrade itrade in input.trades)
			{
				portfolio.Add(itrade.Value, itrade.ClientSector, itrade.NextPaymentDate, itrade.IsPoliticallyExposed);
			}

			portfolio.Display();
		}


		static int Main(string[] args)
		{
			int result = 0;

			Configuration.Decode(args);
			try
			{
				Process(ReadInput());
			}
			catch (Exception e)
			{
				Console.WriteLine("EXCEPTION : {0}", e.Message);
				result = 1;
			}

			if (Configuration.wait)
				Console.Read();


			return result;
		}
	}
}

