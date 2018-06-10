using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class _EnemyController : MonoBehaviour {

	public float lookRadius = 10f;
	public Transform player;

	private NavMeshAgent agent;
	private _CharacterCombat combat;

	void Start()
	{
		agent = GetComponent<NavMeshAgent> ();
		combat = GetComponent<_CharacterCombat> ();
	}

	void Update()
	{
		float distance = Vector3.Distance (transform.position, player.position);
		if (distance <= lookRadius) {
			agent.SetDestination (player.position);
			if (distance <= agent.stoppingDistance) {
				_CharacterStat targetStat = player.GetComponent<_CharacterStat> ();
				if(targetStat != null)
					combat.Attack (targetStat);
				FaceToTarget ();
			}
		}
	}

	void FaceToTarget ()
	{
		Vector3 direction = (player.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation (new Vector3 (direction.x, 0f, direction.z));
		transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * 5f);
	}
}
