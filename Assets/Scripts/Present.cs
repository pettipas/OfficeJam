using UnityEngine;
using System.Collections;

public class Present : MonoBehaviour {

	public bool good;

	void Start () {
		StartCoroutine(WaitAndDestroy());
	}
	
	IEnumerator WaitAndDestroy(){
		yield return new WaitForSeconds(10.0f);
		Destroy(gameObject);

		if(FireManager.Instance == null){
			yield break;
		}

		if(good){
			FireManager.Instance.EnableFire ();
		}else {
			FireManager.Instance.DisableFire();
		}
	}
}
