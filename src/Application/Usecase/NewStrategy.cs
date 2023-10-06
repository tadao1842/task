using System;
using System.IO;
using System.Configuration;
using Domain.Model;
using Domain.Repository;
using Domain.Value;
using Infrastructure.FileSystem;

namespace Application.Usecase
{
class NewStrategy : IStrategy
{
	private DirectoryInfo taskDir;
	private ITaskRepository repo;
	private Name name;

	public NewStrategy(string[] args)
	{
		string strVault = ConfigurationManager.AppSettings["Vault"];
		this.taskDir = new DirectoryInfo(Path.Combine(new string[] {strVault, DateTime.Now.ToString("yyyyMMddHHmmss")}));
		this.repo = new TaskRepository();
		this.name = new Name(args[1]);
	}

	public void Execute()
	{
		Task task = new Task(this.taskDir, this.name, new Status("open"));
		repo.Create(task);
		Console.WriteLine(task.TaskDir.FullName);
	}
}
}
