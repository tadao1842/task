using System;
using Application.Usecase;

class TaskTool
{
	public static void Main(string[] args)
	{
		try
		{
			IStrategy strategy = StrategyFactory.Create(args);
			strategy.Execute();
		}
		catch (ArgumentException ex)
		{
			Console.Error.WriteLine(ex.Message);
		}
	}
}
