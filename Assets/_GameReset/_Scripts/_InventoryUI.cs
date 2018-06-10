using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _InventoryUI : MonoBehaviour {

	public GameObject inventoryUI;
	public Transform itemParent;

	private _InventorySlot[] inventorySlots;
	private _Inventory inventory;

	void Start()
	{
		inventory = _Inventory.instance;
		inventorySlots = itemParent.GetComponentsInChildren<_InventorySlot> ();
		inventory.onItemChangedCallBack += UpdateUI;
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.I)) {
			inventoryUI.SetActive (!inventoryUI.activeSelf);
		}
	}

	void UpdateUI()
	{
		for (int i = 0; i < inventorySlots.Length; i++) {
			if (i < inventory.items.Count) {
				inventorySlots [i].AddItem (inventory.items [i]);
			} else {
				inventorySlots [i].ClearSlot ();
			}
		}
	}

}
