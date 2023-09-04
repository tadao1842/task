using System;
using System.IO;
using Domain.Value;

namespace Domain.Model
{
class Task
{
	private DirectoryInfo taskDir;
	private Name name;
	private Status status;

	public Task(DirectoryInfo taskDir, Name name, Status status)
	{
		this.taskDir = taskDir;
		this.name = name;
		this.status = status;
	}

	public DirectoryInfo TaskDir
	{
		get {return this.taskDir;}
	}

	public Name Name
	{
		get {return this.name;}
	}

	public Status Status
	{
		get {return this.status;}
	}

	public void Open()
	{
		this.status = new Status("open");
	}

	public void Close()
	{
		this.status = new Status("close");
	}

	public void Delete()
	{
		this.status = new Status("delete");
	}

	public void Rename(Name name)
	{
		this.name = name;
	}

	public void Show()
	{
		Console.ForegroundColor = this.status.Color();
		Console.Write("● ");
		Console.ForegroundColor = ConsoleColor.Gray;
		Console.Write(Path.GetFileName(this.taskDir.FullName) + " - ");
		Console.WriteLine(name.Value);
	}

	public bool IsClosed()
	{
		return this.status.IsClose();
	}

	public bool IsDeleted()
	{
		return this.status.IsDelete();
	}
}
}
