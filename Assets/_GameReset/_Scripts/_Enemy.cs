using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Enemy : _Interactable {

	public GameObject playerGb;

	private _EnemyStats myStats;

	void Start()
	{
		myStats = GetComponent<_EnemyStats> ();
	}

	public override void Interact ()
	{
		base.Interact ();
		_CharacterCombat combat = playerGb.GetComponent<_CharacterCombat> ();
		if (combat != null)
			combat.Attack (myStats);
	}
}
