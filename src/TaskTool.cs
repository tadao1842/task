using System;
using Application.Usecase;

class TaskTool
{
	public static void Main(string[] args)
	{
		try
		{
			UsecaseContext context = new UsecaseContext(args);
			context.Execute();
		}
		catch (ArgumentException ex)
		{
			Console.Error.WriteLine(ex.Message);
		}
	}
}
