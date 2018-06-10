using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerAniamtor : _CharacterAnimator {

	public _WeaponAnimations[] weaponAniamtions;
	Dictionary<_Equipment, AnimationClip[]> weaponAnimationsDict;

	protected override void Start()
	{
		base.Start ();
		_EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;

		weaponAnimationsDict = new Dictionary<_Equipment, AnimationClip[]> ();
		foreach (_WeaponAnimations c in weaponAniamtions) {
			weaponAnimationsDict.Add (c.weapon, c.clips);
		}
	}

	void OnEquipmentChanged(_Equipment newItem, _Equipment oldItem)
	{
		if (newItem != null && newItem.equipmentSlot == _EquipmentSlot.Weapon) {
			animator.SetLayerWeight (1, 1);
			if (weaponAnimationsDict.ContainsKey (newItem))
				currentAnimSet = weaponAnimationsDict [newItem];
		} else if (newItem == null && oldItem.equipmentSlot == _EquipmentSlot.Weapon) {
			animator.SetLayerWeight (1, 0);
			currentAnimSet = defaultAttackAnimSet;
		}

		if (newItem != null && newItem.equipmentSlot == _EquipmentSlot.Shield) {
			animator.SetLayerWeight (2, 1);
			currentAnimSet = defaultAttackAnimSet;
		} else if (newItem == null && oldItem.equipmentSlot == _EquipmentSlot.Shield) {
			animator.SetLayerWeight (2, 0);
		}
	}
}

[System.Serializable]
public struct _WeaponAnimations
{
	public _Equipment weapon;
	public AnimationClip[] clips;
}
