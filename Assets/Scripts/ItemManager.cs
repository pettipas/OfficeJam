using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

	public class Item {
		public Image  itemImage;
		public string itemName;
	}

	// GUI Interaction
	[SerializeField]
	protected Image itemSelectionImage;

	// list population
	[SerializeField]
	protected List<Image> itemImages;
	[SerializeField]
	protected List<string> itemNames;

	// climbing item rotation
	public List<Item> items;
	public float rotateSpeed;
	protected int currentItemIndex;
	protected float rotateTimer;

	// Use this for initialization
	void Start () {

		// initaialize the item list;
		items = new List<Item>();
		for (int i = 0; i < itemImages.Count; i++) {
			items[i].itemImage = itemImages[i];
			items[i].itemName = itemNames[i];
		}

		Initialize ();
	}

	public void Initialize () {
		rotateTimer = 1.0F;
		rotateSpeed = 1.0F;
		currentItemIndex = 0;
	}

	void Update () {

		// increment the timer that displays which item will be chosen in the rotation
		rotateTimer -= Time.deltaTime /rotateSpeed;
		if (rotateTimer <= 0.0F) {

			// The timer has reached zero. Change the current item
			currentItemIndex++;
			if (currentItemIndex >= items.Count) {
				currentItemIndex = 0;
			}

			// reset the timer
			rotateTimer = 1.0F;
		}
	}


}
