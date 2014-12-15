using UnityEngine;
using System.Collections;

public class Present : MonoBehaviour {


	void Start () {
		StartCoroutine(WaitAndDestroy());
	}
	
	IEnumerator WaitAndDestroy(){
		yield return new WaitForSeconds(10.0f);
		Destroy(gameObject);
	}
}
