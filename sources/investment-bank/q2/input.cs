using System;
using System.Globalization;
using System.Collections.Generic;


namespace investment_bank
{
	public class Input
	{
		public DateTime     ReferenceDate	{ get; set; }
		public List<ITrade> trades			{ get; private set; }

		public void Read()
		{
			string line;

			try
			{
				line = Console.ReadLine();

				byte[] bytes = System.Text.Encoding.Default.GetBytes(line);

				//this.ReferenceDate = DateTime.ParseExact(line, "MM/dd/yyyy", null);
				//this.ReferenceDate = DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", null);
				this.ReferenceDate = DateTime.ParseExact(line.Trim(), "MM/dd/yyyy", null);
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


			Console.WriteLine(this.ReferenceDate);
		}

		public Input()
		{
			trades = new List<ITrade>();
		}
	}
}
