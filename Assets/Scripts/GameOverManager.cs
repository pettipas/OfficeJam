using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {



	[HideInInspector]
	public bool isGameOver = false;

	void Start () {
		Initialize ();
	}

	public void Initialize () {
		isGameOver = false;
	}

	public void EndGame () {
		isGameOver = true;
		StartCoroutine (endGame());
	}

	protected IEnumerator endGame () {
		yield return null;
	}
}
