using System;

namespace Domain.Value
{
enum EStatus
{
	Open,
	Close,
	Delete
}

class Status
{
	private EStatus value;

	public Status(string value)
	{
		this.value = (EStatus)Enum.Parse(typeof(EStatus), value, true);
	}

	public string Value
	{
		get {return this.value.ToString();}
	}

	public bool IsOpen()
	{
		return this.value == EStatus.Open;
	}

	public bool IsClose()
	{
		return this.value == EStatus.Close;
	}

	public bool IsDelete()
	{
		return this.value == EStatus.Delete;
	}

	public ConsoleColor Color()
	{
		switch(this.value)
		{
			case EStatus.Open:
				return ConsoleColor.Red;

			case EStatus.Close:
				return ConsoleColor.Green;

			default:
				return ConsoleColor.Gray;
		}
	}
}
}
