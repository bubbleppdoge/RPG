using UnityEngine;

public class CharacterStats : MonoBehaviour {

	public int maxHealth = 100;
	public int currentHealth { get; private set; }

	public Stat damage;
	public Stat armor;

	public System.Action<int, int> OnHealthChanged;

	void Awake()
	{
		currentHealth = maxHealth;
	}

	public void TakeDamage(int damage)
	{
		damage -= armor.GetValue ();
		damage = Mathf.Clamp (damage, 0, int.MaxValue);
		print (gameObject.name + " take " + damage + " damage!");
		currentHealth -= damage;

		if (OnHealthChanged != null)
			OnHealthChanged (maxHealth, currentHealth);

		if (currentHealth <= 0) {
			Die ();
		}
	}

	public virtual void Die()
	{
		
	}
}
