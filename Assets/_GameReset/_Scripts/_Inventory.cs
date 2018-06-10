using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Inventory : MonoBehaviour {

	#region singleton
	public static _Inventory instance;
	void Awake()
	{
		if (instance != null) {
			Debug.Log ("More than one instance of _Inventory found!");
			return;
		}
		instance = this;
	}
	#endregion

	public int space = 20;
	public List<_Item> items = new List<_Item>();

	public delegate void OnItemChanged ();
	public OnItemChanged onItemChangedCallBack;

	public bool Add(_Item item)
	{
		if (!item.isDefaultItem) {
			if (items.Count >= space)
				return false;
			
			items.Add (item);
			if (onItemChangedCallBack != null)
				onItemChangedCallBack ();
		}
		return true;
	}

	public void Remove(_Item item)
	{
		items.Remove (item);

		if (onItemChangedCallBack != null)
			onItemChangedCallBack ();
	}
}
