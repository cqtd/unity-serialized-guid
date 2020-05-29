using System;
using UnityEngine;

[Serializable]
public struct SerializedGUID
{
	[SerializeField] 
	byte[] guidBytes;
	Guid guid;

	public Guid Guid
	{
		get
		{
			if (guid != Guid.Empty)
			{
				return guid;
			}

			if (guidBytes != null && guidBytes.Length == 16)
			{
				guid = new Guid(guidBytes);
				return guid;
			}

			return Guid.Empty;
		}
		set
		{
			guid = value;
			guidBytes = value.ToByteArray();
		}
	}

	public override string ToString()
	{
		return Guid.ToString();
	}
}