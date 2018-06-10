using UnityEngine;

public class _Interactable : MonoBehaviour {

	public float radius = 3f;
	public Transform interactionTransform;

	private Transform player;
	private bool isFocus = false;
	private bool hasFocused = false;

	public virtual void Interact()
	{
	}

	void Update()
	{
		if (isFocus && !hasFocused) {
			float distance = Vector3.Distance (transform.position, player.position);
			if (distance <= radius) {
				Interact ();
				hasFocused = true;
			}
		}
	}

	public void OnFocused(Transform playerTransform)
	{
		isFocus = true;
		player = playerTransform;
		hasFocused = false;
	}

	public void OnDefocused()
	{
		isFocus = false;
		player = null;
		hasFocused = false;
	}

	void OnDrawGizmosSelected()
	{
		if (interactionTransform == null)
			interactionTransform = transform;
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (interactionTransform.position, radius);
	}
}
