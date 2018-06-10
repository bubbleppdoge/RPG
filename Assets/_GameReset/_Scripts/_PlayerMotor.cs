using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class _PlayerMotor : MonoBehaviour {

	private _Interactable target;
	private NavMeshAgent agent;

	void Start()
	{
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update()
	{
		if (target != null) {
			agent.SetDestination (target.transform.position);
			FaceTarget ();
		}
	}

	public void MoveToPoint(Vector3 point)
	{
		agent.SetDestination (point);
	}

	public void FollowTarget(_Interactable newTarget)
	{
		agent.stoppingDistance = 2f;
		agent.updateRotation = false;
		target = newTarget;
	}

	public void StopFollowingTarget()
	{
		target = null;
		agent.stoppingDistance = 0f;
		agent.updateRotation = true;
	}

	void FaceTarget()
	{
		Vector3 direction = target.transform.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (new Vector3(direction.x, 0f, direction.z));
		transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * 5f);
	}
}
