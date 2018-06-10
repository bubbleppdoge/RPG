using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class _CharacterAnimator : MonoBehaviour {

	public AnimationClip replaceableAttackAnim;
	public AnimationClip[] defaultAttackAnimSet;
	public AnimatorOverrideController overrideController;
	protected AnimationClip[] currentAnimSet;

	public float locomotionSmoothTime = 0.1f;

	protected Animator animator;
	private NavMeshAgent agent;
	protected _CharacterCombat combat;

	// Use this for initialization
	protected virtual void Start () {
		animator = GetComponentInChildren<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		combat = GetComponent<_CharacterCombat> ();

		if (overrideController == null)
			overrideController = new AnimatorOverrideController (animator.runtimeAnimatorController);
		animator.runtimeAnimatorController = overrideController;
		currentAnimSet = defaultAttackAnimSet;
		combat.OnAttack += OnAttack;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		float speedPercent = agent.velocity.magnitude / agent.speed;
		animator.SetFloat ("speedPercent", speedPercent, locomotionSmoothTime, Time.deltaTime);

		animator.SetBool ("inCombat", combat.inCombat);
	}

	protected void OnAttack()
	{
		animator.SetTrigger ("attack");
		int index = Random.Range (0, currentAnimSet.Length);
		overrideController [replaceableAttackAnim.name] = currentAnimSet [index];
	}
}
