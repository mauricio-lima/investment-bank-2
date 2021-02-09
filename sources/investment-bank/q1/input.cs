using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace investment_bank
{
	public class Input
	{
		public struct TradeInfo
		{
			public double   Value;
			public string   ClientSector;
			public DateTime NextPaymentDate;
		}

		public DateTime     ReferenceDate	{ get; set; }
		public List<ITrade> trades			{ get; private set; }

		private string NextLine()
		{
			string line;

			while (true)
			{
				line = Console.ReadLine().Trim();

				if (String.IsNullOrEmpty(line))
					continue;

				if (line[0] != '#')
					break;
			}

			return line;
		}

		private DateTime ParseDate(string input, string message = "")
		{
			try
			{
				return DateTime.ParseExact(input.Trim(), "MM/dd/yyyy", null);
			}
			catch (Exception)
			{
				if ( String.IsNullOrEmpty(message) )
				{
					message = String.Format("Date expected at first valid line, but '{0}' is not considered a valid date", input);
				}
				throw new Exception(message);
			}
		}

		private int ParseInteger(string input, string message = "Integer expected at second line")
		{
			try
			{
				return Int32.Parse(input.Trim());
			}
			catch (Exception)
			{
				throw new Exception(message);
			}
		}

		private TradeInfo ParseTradeData(string input, int row)
		{
			try
			{
				string[] tokens = Regex.Split(input, "\\s+");

				if (tokens.Length < 3)
					throw new Exception(String.Format("Expected three parameters separated by spaces for each trade row. Found only {0}", tokens.Length));

				List<string> options = new List<string>(new string[] { "public", "private" });
				if ( !options.Contains(tokens[1].ToLower()) )
					throw new Exception( String.Format("Invalid token '{0}' at second position in trades row {1}", tokens[1], row+1) );

				return new TradeInfo
				{
					Value           = Convert.ToDouble(this.ParseInteger(tokens[0], String.Format("Number expected at first position at line {0}", row))),
					ClientSector    = tokens[1],
					NextPaymentDate = this.ParseDate(tokens[2])
				};
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public void Read()
		{
			try
			{
				this.ReferenceDate = this.ParseDate(this.NextLine());

				int count = this.ParseInteger(this.NextLine());
				for(int row = 0; row < count; row++)
				{
					var trade = this.ParseTradeData(this.NextLine(), row);
					this.trades.Add(new Trade( trade.Value, trade.ClientSector, trade.NextPaymentDate ));
				}
			}
			catch (FormatException e)
			{
				Console.WriteLine("Invalid Date Format - {0}", e.Message);
				throw e;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public Input()
		{
			trades = new List<ITrade>();
		}
	}
}
