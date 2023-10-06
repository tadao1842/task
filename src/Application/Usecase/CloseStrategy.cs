using System;
using System.IO;
using System.Configuration;
using Domain.Model;
using Domain.Repository;
using Domain.Value;
using Infrastructure.FileSystem;

namespace Application.Usecase
{
class CloseStrategy : MultiTaskStrategy
{
	public CloseStrategy(string[] args) : base(args){}

	public override void Execute()
	{
		foreach (DirectoryInfo taskDir in this.taskDirs)
		{
			Task task = repo.Read(taskDir);
			task.Close();
			repo.Update(task);
		}
	}
}
}
