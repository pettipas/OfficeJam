using UnityEngine;
using System.Collections;

public class Present : MonoBehaviour {

	public bool good;
	protected bool isOnFire = false;

	void Start () {
		StartCoroutine(WaitAndDestroy());
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!isOnFire && other.name == "FireBox") {

			isOnFire = true;

			if(FireManager.Instance == null){
				return;
			}
			
			if(good){
				FireManager.Instance.EnableFire ();
				ItemManager.Instance.IncreaseSpeed ();
			}else {
				FireManager.Instance.DisableFire();
			}

			StartCoroutine (WaitAndDestroy());
		}
	}
	
	IEnumerator WaitAndDestroy(){
		yield return new WaitForSeconds(10.0f);
		Destroy(gameObject);
	}
}
