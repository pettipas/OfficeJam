using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

	public void Update(){

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit) && 
		   Input.GetMouseButtonUp(0))
		{

			Debug.Log (hit.transform.name);
		}

		
	}

}
