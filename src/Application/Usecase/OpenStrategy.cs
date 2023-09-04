using System;
using System.IO;
using System.Configuration;
using Domain.Model;
using Domain.Repository;
using Domain.Value;
using Infrastructure.FileSystem;

namespace Application.Usecase
{
class OpenStrategy : IStrategy
{
	private DirectoryInfo taskDir;
	private ITaskRepository repo;

	public OpenStrategy(string[] args)
	{
		string strVault = ConfigurationManager.AppSettings["Vault"];
		string strTaskDir = (args.Length == 1)
			? Environment.CurrentDirectory
			: Path.Combine(new string[] {strVault, args[1]});
		this.taskDir = new DirectoryInfo(strTaskDir);
		this.repo = new TaskRepository();
	}

	public void Execute()
	{
		Task task = repo.Read(this.taskDir);
		task.Open();
		repo.Update(task);
	}
}
}