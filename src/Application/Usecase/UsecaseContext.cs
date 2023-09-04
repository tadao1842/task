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
		if (args.Length == 0)
		{
			throw new ArgumentException("コマンドが入力されていません");
		}

		switch(args[0])
		{
			case Commands.NEW:
				this.strategy = new NewStrategy(args);
				break;

			case Commands.SHOW:
				this.strategy = new ShowStrategy(args);
				break;

			case Commands.OPEN:
				this.strategy = new OpenStrategy(args);
				break;

			case Commands.CLOSE:
				this.strategy = new CloseStrategy(args);
				break;

			case Commands.RENAME:
				this.strategy = new RenameStrategy(args);
				break;

			case Commands.LIST:
				this.strategy = new ListStrategy(args);
				break;

			case Commands.PWD:
				this.strategy = new PwdStrategy(args);
				break;

			case Commands.REMOVE:
				this.strategy = new RemoveStrategy(args);
				break;

			default:
				throw new ArgumentException("定義されていないコマンドです");
		}
	}

	public void Execute()
	{
		this.strategy.Execute();
	}
}
}
