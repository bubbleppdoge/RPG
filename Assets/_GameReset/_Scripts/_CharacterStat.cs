using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CharacterStat : MonoBehaviour {

	public int maxHealth = 100;
	public _Stat damage;
	public _Stat armor;

	public int currenHealth{ get; private set;}
	public System.Action<int, int> OnHealthChanged;

	void Awake()
	{
		currenHealth = maxHealth;
	}

	public void TakeDamage(int damage)
	{
		damage -= armor.GetValue();
		damage = Mathf.Clamp (damage, 0, int.MaxValue);
		Debug.Log (gameObject.name + " takes " + damage + " damage!");
		currenHealth -= damage;

		if (OnHealthChanged != null)
			OnHealthChanged (maxHealth, currenHealth);

		if (currenHealth <= 0)
			Die ();
	}

	public virtual void Die()
	{
		
	}
}
