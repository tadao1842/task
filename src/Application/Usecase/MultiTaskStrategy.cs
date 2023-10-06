using System;
using System.IO;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;
using Domain.Model;
using Domain.Repository;
using Domain.Value;
using Infrastructure.FileSystem;

namespace Application.Usecase
{
class MultiTaskStrategy : IStrategy
{
	protected List<DirectoryInfo> taskDirs;
	protected ITaskRepository repo;

	public MultiTaskStrategy(string[] args)
	{
		string strVault = ConfigurationManager.AppSettings["Vault"];
		this.taskDirs = new List<DirectoryInfo>();
		if (args.Length == 1)
		{
			this.taskDirs.Add(
				new DirectoryInfo(
					Environment.CurrentDirectory
				)
			);
		}
		else
		{
			foreach (string arg in args.Skip(1))
			{
				this.taskDirs.Add(
					new DirectoryInfo(
						Path.Combine(new string[] {strVault, arg})
					)
				);
			}
		}
		this.repo = new TaskRepository();
	}

	public virtual void Execute(){}
}
}
