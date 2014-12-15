using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

	public ItemManager itemManger;
	public Person selectedPerson;

	public void FixedUpdate(){

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit) && 
		   Input.GetMouseButtonUp(0))
		{

			Person p = hit.transform.GetComponent<Person>();
			if(p){
				selectedPerson = p;
			}


			if(selectedPerson != null && hit.transform.name == "background" && Input.GetMouseButtonUp(0)){
				Vector2 pp = new Vector2(selectedPerson.transform.position.x,selectedPerson.transform.position.y);

				Vector3 stmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Vector2 mp = new Vector2(stmp.x,stmp.y);
				Vector2 dir = (mp - pp).normalized;

				float distance = Vector2.Distance(mp,pp);
				GameObject go = (GameObject)Instantiate(itemManger.GetCurrentItem(),selectedPerson.transform.position,Quaternion.identity);
				go.rigidbody2D.AddForce(dir * 100 * distance);
				go.rigidbody2D.AddTorque(((Random.value+0.1f)* 100 * distance)/2.0f);
			}
		
		}





		
	}

}
