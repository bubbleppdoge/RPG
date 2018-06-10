using UnityEngine;

public class ItemPickUp : Interactable {

	public Item item;

	public override void Interact()
	{
		base.Interact ();
		PickUp ();
	}

	void PickUp()
	{
		Debug.Log ("Picking Up " + item.name);
		bool wasPicedkUp = Inventory.instance.Add (item);
		if(wasPicedkUp)
			Destroy (gameObject);
	}

}
