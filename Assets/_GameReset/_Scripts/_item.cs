using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/_Item")]
public class _Item : ScriptableObject {

	new public string name = "New Item";
	public Sprite icon = null;
	public bool isDefaultItem = false;

	public virtual void Use()
	{
		
	}
}
