using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireManager : MonoBehaviour {
	
	[SerializeField]
	protected ParticleSystem mainFire;
	[SerializeField]
	protected List<ParticleSystem> additionalFires;

	protected List<int> enabledFires;

	// Use this for initialization
	void Start () {
		enabledFires = new List<int>();
		Initialize ();
	}

	public void Initialize () {
		mainFire.enableEmission = true;
		foreach (ParticleSystem cps in mainFire.GetComponentsInChildren<ParticleSystem>()) {
			cps.enableEmission = true;
		}

		foreach (ParticleSystem ps in additionalFires) {
			ps.enableEmission = false;
			foreach (ParticleSystem cps in ps.GetComponentsInChildren<ParticleSystem>()) {
				cps.enableEmission = false;
			}
		}

		enabledFires.Clear ();
	}
	
	public void EnableFire () {

		if (enabledFires.Count < additionalFires.Count) {

			// choose a random fire
			int rnd = 0;
			do {
				rnd = Random.Range (0, additionalFires.Count);

			} while (enabledFires.Contains (rnd));

			// add it to the list of enabled fires
			additionalFires[rnd].enableEmission = true;
			foreach (ParticleSystem cps in additionalFires[rnd].GetComponentsInChildren<ParticleSystem>()) {
				cps.enableEmission = true;
			}
			enabledFires.Add (rnd);
		}
	}

	public void SmotherFire () {
		Initialize ();
		mainFire.enableEmission = false;
		foreach (ParticleSystem cps in mainFire.GetComponentsInChildren<ParticleSystem>()) {
			cps.enableEmission = false;
		}

	}
}
