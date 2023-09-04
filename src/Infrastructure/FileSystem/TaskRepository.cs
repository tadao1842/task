using System;
using System.IO;
using System.Collections.Generic;
using Domain.Model;
using Domain.Repository;
using Domain.Value;

namespace Infrastructure.FileSystem
{
class TaskRepository : ITaskRepository
{
	private static string INI_FILE_NAME = ".task";
	private static string AF_DIR_NAME = "artifacts";
	private static string REF_DIR_NAME = "references";

	private const string TASK_SECTION = "TASK";
	private const string NAME_KEY = "NAME";
	private const string STATUS_KEY = "STATUS";

	public void Create(Task task)
	{
		FileInfo iniFilePath = CreateIniFilePath(task.TaskDir);
		Directory.CreateDirectory(task.TaskDir.FullName);
		Directory.CreateDirectory(CreateArtifactsDirectoryInfo(task.TaskDir).FullName);
		Directory.CreateDirectory(CreateReferencesDirectoryInfo(task.TaskDir).FullName);
		IniFileManager.SetValue(TASK_SECTION, NAME_KEY, task.Name.Value, iniFilePath.FullName);
		IniFileManager.SetValue(TASK_SECTION, STATUS_KEY, task.Status.Value, iniFilePath.FullName);
	}

	public Task Read(DirectoryInfo taskDir)
	{
		FileInfo iniFilePath = CreateIniFilePath(taskDir);
		Name name = new Name(IniFileManager.GetValueString(TASK_SECTION, NAME_KEY, iniFilePath.FullName));
		Status status = new Status(IniFileManager.GetValueString(TASK_SECTION, STATUS_KEY, iniFilePath.FullName));
		return new Task(taskDir, name, status);
	}

	public List<Task> ReadList(DirectoryInfo vaultDir)
	{
		List<Task> list = new List<Task>();

		foreach(DirectoryInfo taskDir in vaultDir.GetDirectories())
		{
			list.Add(this.Read(taskDir));
		}

		return list;
	}

	public void Update(Task task)
	{
		FileInfo iniFilePath = CreateIniFilePath(task.TaskDir);
		IniFileManager.SetValue(TASK_SECTION, NAME_KEY, task.Name.Value, iniFilePath.FullName);
		IniFileManager.SetValue(TASK_SECTION, STATUS_KEY, task.Status.Value, iniFilePath.FullName);
	}

	public void Delete(DirectoryInfo taskDir)
	{
		Directory.Delete(taskDir.FullName, true);
	}

	private FileInfo CreateIniFilePath(DirectoryInfo taskDir)
	{
		return new FileInfo(Path.Combine(new string[] {taskDir.FullName, INI_FILE_NAME}));
	}

	private DirectoryInfo CreateArtifactsDirectoryInfo(DirectoryInfo taskDir)
	{
		return new DirectoryInfo(Path.Combine(new string[] {taskDir.FullName, AF_DIR_NAME}));
	}

	private DirectoryInfo CreateReferencesDirectoryInfo(DirectoryInfo taskDir)
	{
		return new DirectoryInfo(Path.Combine(new string[] {taskDir.FullName, REF_DIR_NAME}));
	}
}
}
