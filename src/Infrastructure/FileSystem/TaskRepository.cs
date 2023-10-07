using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Xml.Linq;
using Domain.Model;
using Domain.Repository;
using Domain.Value;

namespace Infrastructure.FileSystem
{
class TaskRepository : ITaskRepository
{
	private const string TASK_FILE_NAME = "Task.xml";

	public void Create(Task task)
	{
		Directory.CreateDirectory(task.TaskDir.FullName);

		FileInfo taskFilePath = this.CreateTaskFilePath(task.TaskDir);
		XElement xmlTask = new XElement(
			"Task",
			new XElement("TaskDir", task.TaskDir.FullName),
			new XElement("Name", task.Name.Value),
			new XElement("Status", task.Status.Value)
		);
		xmlTask.Save(taskFilePath.FullName);

		DirectoryInfo resourceDir = new DirectoryInfo(
			ConfigurationManager.AppSettings["Resource"]
		);
		FileHelper.CopyAll(resourceDir, task.TaskDir);
	}

	public Task Read(DirectoryInfo taskDir)
	{
		FileInfo taskFilePath = this.CreateTaskFilePath(taskDir);

		XElement xmlTask = XElement.Load(taskFilePath.FullName);
		Name name = new Name(xmlTask.Element("Name").Value);
		Status status = new Status(xmlTask.Element("Status").Value);

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
		FileInfo taskFilePath = this.CreateTaskFilePath(task.TaskDir);

		XElement xmlTask = new XElement(
			"Task",
			new XElement("TaskDir", task.TaskDir.FullName),
			new XElement("Name", task.Name.Value),
			new XElement("Status", task.Status.Value)
		);

		xmlTask.Save(taskFilePath.FullName);
	}

	public void Delete(DirectoryInfo taskDir)
	{
		Directory.Delete(taskDir.FullName, true);
	}

	private FileInfo CreateTaskFilePath(DirectoryInfo taskDir)
	{
		return new FileInfo(
			Path.Combine(new string[] {taskDir.FullName, TASK_FILE_NAME})
		);
	}
}
}
