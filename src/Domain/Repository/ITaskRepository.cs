using System.IO;
using System.Collections.Generic;
using Domain.Model;

namespace Domain.Repository
{
interface ITaskRepository
{
	void Create(Task task);
	Task Read(DirectoryInfo taskDir);
	List<Task> ReadList(DirectoryInfo vaultDir);
	void Update(Task task);
	void Delete(DirectoryInfo taskDir);
}
}
