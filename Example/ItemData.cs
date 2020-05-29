using UnityEngine;

[CreateAssetMenu(menuName = "Example/GUID Example")]
public class ItemData : ScriptableObject
{
	public SerializedGUID guid;
	public string itemName;
}
