using System;
using System.IO;
using System.Configuration;
using Domain.Model;
using Domain.Repository;
using Domain.Value;
using Infrastructure.FileSystem;

namespace Application.Usecase
{
class ShowStrategy : MultiTaskStrategy
{
	public ShowStrategy(string[] args) : base(args){}

	public override void Execute()
	{
		foreach (DirectoryInfo taskDir in this.taskDirs)
		{
			Task task = repo.Read(taskDir);
			task.Show();
		}
	}
}
}
