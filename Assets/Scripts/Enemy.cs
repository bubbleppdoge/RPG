using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Handles interaction with the Enemy */

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable {

	PlayerManager playerManager;
	CharacterStats myStats;

	Interactable myFoucus;

	void Start ()
	{
		playerManager = PlayerManager.instance;
		myStats = GetComponent<CharacterStats>();
	}

	public override void Interact()
	{
		base.Interact();
//		StartCoroutine ("InvokeAttack");
		CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
		if (playerCombat != null)
		{
			playerCombat.Attack(myStats);
		}
	}

	IEnumerator InvokeAttack()
	{
		PlayerController playerController = playerManager.player.GetComponent<PlayerController> ();
		CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
		while (playerController.focus != null &&  playerController.focus.gameObject == this.gameObject) {
			if (playerCombat != null)
			{
				playerCombat.Attack(myStats);
			}
			yield return new WaitForSeconds (playerCombat.attackDelay + playerCombat.attackSpeed);
		}
		yield return null;
	}
}