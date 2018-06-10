using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

	#region singleton
	public static PlayerManager instance;

	void Awake()
	{
		if (instance != null) {
			Debug.Log ("More than one instance of PlayerManager found!");
			return;
		}
		instance = this;
	}
	#endregion

	public GameObject player;

	public void KillPlayer()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
