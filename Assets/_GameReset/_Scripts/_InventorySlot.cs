using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _InventorySlot : MonoBehaviour {

	private _Item item;

	public Image icon;
	public Button removeButton;

	public void AddItem(_Item newItem)
	{
		item = newItem;
		icon.enabled = true;
		icon.sprite = newItem.icon;
		removeButton.interactable = true;
	}

	public void ClearSlot()
	{
		item = null;
		icon.enabled = false;
		icon.sprite = null;
		removeButton.interactable = false;
	}

	public void ItemButton()
	{
		if (item != null)
			item.Use ();
	}

	public void RemoveButton()
	{
		_Inventory.instance.Remove (item);
	}
}
