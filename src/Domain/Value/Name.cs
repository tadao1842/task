using System;

namespace Domain.Value
{
class Name
{
	private string value;

	public Name(string value)
	{
		this.value = value;
	}

	public string Value
	{
		get {return this.value;}
	}
}
}
