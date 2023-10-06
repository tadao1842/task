using System;
using System.IO;
using System.Configuration;
using Domain.Model;
using Domain.Repository;
using Domain.Value;
using Infrastructure.FileSystem;

namespace Application.Usecase
{
class OpenStrategy : MultiTaskStrategy
{
	public OpenStrategy(string[] args) : base(args){}

	public override void Execute()
	{
		foreach (DirectoryInfo taskDir in this.taskDirs)
		{
			Task task = repo.Read(taskDir);
			task.Open();
			repo.Update(task);
		}
	}
}
}
