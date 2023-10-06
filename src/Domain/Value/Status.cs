using System;

namespace Domain.Value
{
enum EStatus
{
	Open,
	Close,
	Migrate,
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

	public bool IsClose()
	{
		return this.value == EStatus.Close;
	}

	public bool IsDelete()
	{
		return this.value == EStatus.Delete;
	}

	public string Bullet()
	{
		switch(this.value)
		{
			case EStatus.Open:
				return "・";

			case EStatus.Close:
				return "Ｘ";

			case EStatus.Migrate:
				return "＞";

			default: // Delete
				return "－";
		}
	}
}
}
