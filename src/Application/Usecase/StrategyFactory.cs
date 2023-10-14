using System;
using Application.Constant;
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
			case Command.NEW:
				strategy = new NewStrategy(args);
				break;

			case Command.SHOW:
				strategy = new ShowStrategy(args);
				break;

			case Command.OPEN:
				strategy = new OpenStrategy(args);
				break;

			case Command.CLOSE:
				strategy = new CloseStrategy(args);
				break;

			case Command.MIGRATE:
				strategy = new MigrateStrategy(args);
				break;

			case Command.RENAME:
				strategy = new RenameStrategy(args);
				break;

			case Command.LIST:
				strategy = new ListStrategy(args);
				break;

			case Command.PWD:
				strategy = new PwdStrategy(args);
				break;

			case Command.REMOVE:
				strategy = new RemoveStrategy(args);
				break;

			default:
				throw new ArgumentException("定義されていないコマンドです");
		}

		return strategy;
	}
}
}
