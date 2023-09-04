using System;
using System.IO;
using System.Configuration;
using Domain.Model;
using Domain.Repository;
using Domain.Value;
using Infrastructure.FileSystem;

namespace Application.Usecase
{
class RenameStrategy : IStrategy
{
	private DirectoryInfo taskDir;
	private ITaskRepository repo;
	private Name name;

	public RenameStrategy(string[] args)
	{
		this.name = new Name(args[1]);
		string strVault = ConfigurationManager.AppSettings["Vault"];
		string strTaskDir = (args.Length == 2)
			? Environment.CurrentDirectory
			: Path.Combine(new string[] {strVault, args[2]});
		this.taskDir = new DirectoryInfo(strTaskDir);
		this.repo = new TaskRepository();
	}

	public void Execute()
	{
		Task task = repo.Read(this.taskDir);
		task.Rename(this.name);
		repo.Update(task);
	}
}
}
