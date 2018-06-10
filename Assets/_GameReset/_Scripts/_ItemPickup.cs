using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ItemPickup : _Interactable {

	public _Item item;

	public override void Interact ()
	{
		base.Interact ();
		PickUp ();
	}

	void PickUp()
	{
		bool wasPickedup = _Inventory.instance.Add (item);
		if(wasPickedup)
			Destroy (gameObject);
	}
}
