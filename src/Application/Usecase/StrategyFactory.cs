using System;
using Application.Constants;
using Application.Usecase;

namespace Application.Usecase
{
static class StrategyFactory
{
	public static IStrategy Create(string[] args)
	{
		IStrategy strategy = null;

		if (args.Length == 0)
		{
			throw new ArgumentException("コマンドが入力されていません");
		}

		switch(args[0])
		{
			case Commands.NEW:
				strategy = new NewStrategy(args);
				break;

			case Commands.SHOW:
				strategy = new ShowStrategy(args);
				break;

			case Commands.OPEN:
				strategy = new OpenStrategy(args);
				break;

			case Commands.CLOSE:
				strategy = new CloseStrategy(args);
				break;

			case Commands.MIGRATE:
				strategy = new MigrateStrategy(args);
				break;

			case Commands.RENAME:
				strategy = new RenameStrategy(args);
				break;

			case Commands.LIST:
				strategy = new ListStrategy(args);
				break;

			case Commands.PWD:
				strategy = new PwdStrategy(args);
				break;

			case Commands.REMOVE:
				strategy = new RemoveStrategy(args);
				break;

			default:
				throw new ArgumentException("定義されていないコマンドです");
		}

		return strategy;
	}
}
}
