using System;
using Application.Constants;
using Application.Usecase;

namespace Application.Usecase
{
class UsecaseContext
{
	private IStrategy strategy;

	public UsecaseContext(string[] args)
	{
		this.strategy = StrategyFactory.Create(args);
	}

	public void Execute()
	{
		this.strategy.Execute();
	}
}
}
