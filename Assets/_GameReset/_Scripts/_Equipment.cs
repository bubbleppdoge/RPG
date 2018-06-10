using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/_Equipment")]
public class _Equipment : _Item {

	public _EquipmentSlot equipmentSlot;
	public SkinnedMeshRenderer mesh;

	public int damageModifier;
	public int armorModifier;
	public _EquipmentMeshRegion[] equipmentMeshRegion;

	public override void Use ()
	{
		base.Use ();
		_EquipmentManager.instance.Equip (this);
		RemoveFromInventory ();
	}

	void RemoveFromInventory()
	{
		_Inventory.instance.Remove (this);
	}
}

public enum _EquipmentSlot {Head, Chest, Legs, Weapon, Shield, Feet}
public enum _EquipmentMeshRegion {Legs, Arms, Torso}