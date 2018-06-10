using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _EnemyStats : _CharacterStat {

	public override void Die ()
	{
		base.Die ();
		Destroy (gameObject);
	}
}
