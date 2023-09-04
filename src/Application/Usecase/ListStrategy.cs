using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using Domain.Model;
using Domain.Repository;
using Domain.Value;
using Infrastructure.FileSystem;

namespace Application.Usecase
{
class ListStrategy : IStrategy
{
	private DirectoryInfo vault;
	private bool showAll;
	private ITaskRepository repo;

	public ListStrategy(string[] args)
	{
		string strVault = ConfigurationManager.AppSettings["Vault"];
		this.vault = new DirectoryInfo(strVault);
		this.showAll = args.Length >= 2 && args[1] == Options.ALL;
		this.repo = new TaskRepository();
	}

	public void Execute()
	{
		List<Task> tasks = repo.ReadList(this.vault);
		tasks.Sort((a, b) => string.Compare(a.Name.Value, b.Name.Value));

		foreach(Task task in tasks)
		{
			if ((task.IsDeleted()) || (task.IsClosed() && !showAll))
			{
				continue;
			}

			task.Show();
		}
	}

	private static class Options
	{
		public const string ALL = "/a";
	}
}
}
