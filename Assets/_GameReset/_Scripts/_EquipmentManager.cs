using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _EquipmentManager : MonoBehaviour {

	#region singleton
	public static _EquipmentManager instance;
	void Awake()
	{
		if (instance != null) {
			Debug.Log ("More than one instance of _EquipmentManager found!");
			return;
		}
		instance = this;
	}
	#endregion

	public _Equipment[] defualtEquipment;
	public SkinnedMeshRenderer targetMesh;

	private _Equipment[] currentEquipments;
	private SkinnedMeshRenderer[] currentMeshs;
	private _Inventory inventory;

	public delegate void OnEquipmentChanged(_Equipment newItem, _Equipment oldItem);
	public OnEquipmentChanged onEquipmentChanged;

	void Start()
	{
		int numSlot = System.Enum.GetNames (typeof(_EquipmentSlot)).Length;
		currentEquipments = new _Equipment[numSlot];
		currentMeshs = new SkinnedMeshRenderer[numSlot];
		inventory = _Inventory.instance;

		EquipDefaultEquipment ();
	}

	public void Equip(_Equipment newItem)
	{
		int index = (int)newItem.equipmentSlot;
		_Equipment oldItem = Unequip(index);

		if (currentEquipments[index] != null) {
			oldItem = currentEquipments [index];
			inventory.Add (oldItem);
		}

		if (onEquipmentChanged != null)
			onEquipmentChanged.Invoke (newItem, oldItem);

		SetEquipmentBlendShapes (newItem, 100);
		currentEquipments [index] = newItem;
		SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer> (newItem.mesh);

		newMesh.transform.parent = targetMesh.transform;
		newMesh.bones = targetMesh.bones;
		newMesh.rootBone = targetMesh.rootBone;
		currentMeshs [index] = newMesh;
	}

	public _Equipment Unequip(int index)
	{
		if (currentEquipments [index] != null) {
			if (currentMeshs [index] != null)
				Destroy (currentMeshs [index].gameObject);
			_Equipment oldItem = currentEquipments [index];
			Destroy (currentMeshs [index].gameObject);
			currentEquipments [index] = null;
			SetEquipmentBlendShapes (oldItem, 0);
			inventory.Add (oldItem);

			if (onEquipmentChanged != null)
				onEquipmentChanged.Invoke (null, oldItem);
			return oldItem;
		}
		return null;
	}

	void UnequipAll()
	{
		for (int i = 0; i < currentEquipments.Length; i++) {
			Unequip (i);
		}
		EquipDefaultEquipment ();
	}

	void SetEquipmentBlendShapes(_Equipment item, int weight)
	{
		foreach (_EquipmentMeshRegion blendShape in item.equipmentMeshRegion)
			targetMesh.SetBlendShapeWeight ((int)blendShape, weight);
	}

	void EquipDefaultEquipment()
	{
		foreach (_Equipment item in defualtEquipment) {
			Equip (item);
		}
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.U))
			UnequipAll ();
	}
}
