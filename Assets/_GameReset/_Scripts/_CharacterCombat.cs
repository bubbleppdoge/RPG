using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CharacterCombat : MonoBehaviour {

	public float attackSpeed = 0.6f;
	public float attackCoolDown = 0f;
	private const float combatCoolDown = 5f;

	private float lastAttackTime;
	private _CharacterStat myStat;
	private _CharacterStat opponentStat;
	public bool inCombat{ get; private set;}

	public event System.Action OnAttack;

	void Start()
	{
		myStat = GetComponent<_CharacterStat> ();
	}

	void Update()
	{
		attackCoolDown -= Time.deltaTime;

		if (Time.time - lastAttackTime >= combatCoolDown) {
			inCombat = false;
		}
	}

	public void Attack(_CharacterStat targetStat)
	{
		if (attackCoolDown <= 0) {
			opponentStat = targetStat;
			opponentStat.TakeDamage(myStat.damage.GetValue());

			if (OnAttack != null)
				OnAttack ();

			attackCoolDown = 1f / attackSpeed;
			inCombat = true;
			lastAttackTime = Time.time;
		}
	}

	public void AttackHit_AnimationEvent()
	{
		opponentStat.TakeDamage(myStat.damage.GetValue());
		if (opponentStat.currenHealth <= 0) {
			inCombat = false;
		}
	}
}
