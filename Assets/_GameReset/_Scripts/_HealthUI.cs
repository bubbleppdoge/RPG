﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _HealthUI : MonoBehaviour {

	public GameObject uiPrefab;
	public Transform target;

	private float visibleTime = 5f;
	private Transform ui;
	private Transform cam;
	private Image healthSlider;
	private float lastMadeVisibleTime;

	void Start()
	{
		cam = Camera.main.transform;
		foreach (Canvas c in FindObjectsOfType<Canvas>()) {
			if (c.renderMode == RenderMode.WorldSpace) {
				ui = Instantiate (uiPrefab, c.transform).transform;
				healthSlider = ui.GetChild (0).GetComponent<Image> ();
				ui.gameObject.SetActive (false);
				break;
			}
		}
		GetComponent<_CharacterStat> ().OnHealthChanged += OnHealthChanged;
	}

	void OnHealthChanged(int maxHealth, int currentHealth)
	{
		if (ui != null) {
			ui.gameObject.SetActive (true);
			lastMadeVisibleTime = Time.time;

			float healthPercent = (float)currentHealth / maxHealth;
			healthSlider.fillAmount = healthPercent;
			if (currentHealth <= 0)
				Destroy(ui.gameObject);

		}
	}

	void LateUpdate()
	{
		if (ui != null) {
			ui.position = target.position;
			ui.forward = -cam.forward;

			if (Time.time - lastMadeVisibleTime > visibleTime)
				ui.gameObject.SetActive (false);
		}
	}
}
