using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(_PlayerMotor))]
public class _PlayerController : MonoBehaviour {

	public LayerMask movementLayer;
	public _Interactable focus;

	private Camera cam;
	private _PlayerMotor motor;

	void Start()
	{
		cam = Camera.main;
		motor = GetComponent<_PlayerMotor> ();
	}

	void Update()
	{
		if (EventSystem.current.IsPointerOverGameObject ())
			return;

		if (Input.GetMouseButtonDown (0)) {
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100, movementLayer)) {
				motor.MoveToPoint (hit.point);
				RemoveFocus ();
			}
		}

		if (Input.GetMouseButtonDown (1)) {
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				_Interactable interactable = hit.collider.GetComponent<_Interactable> ();
				if(interactable != null)
					SetFoucus (interactable);
			}
		}
	}

	void SetFoucus(_Interactable newFocus)
	{
		if(newFocus != null){
			if (focus != null)
				focus.OnDefocused ();
			
			focus = newFocus;
			motor.FollowTarget (newFocus);
		}
		focus.OnFocused (transform);
	}

	void RemoveFocus()
	{
		if (focus != null)
			focus.OnDefocused ();
		focus = null;
		motor.StopFollowingTarget ();
	}
}
