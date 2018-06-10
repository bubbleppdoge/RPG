using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _PlayerStat : _CharacterStat {

	void Start()
	{
		_EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}

	void OnEquipmentChanged(_Equipment newItem, _Equipment oldItem)
	{
		if (newItem != null) {
			damage.AddModifier (newItem.damageModifier);
			armor.AddModifier (newItem.armorModifier);
		}

		if(oldItem != null){
			damage.RemoveModifier (oldItem.damageModifier);
			armor.RemoveModifier (oldItem.armorModifier);
		}
	}

	public override void Die ()
	{
		base.Die ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
