using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

	public class Item {
		public Image  itemImage;
		public string itemName;
	}

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
			items[i].itemImage.enabled = false;
			items[i].itemName = itemNames[i];
		}

		Initialize ();
	}

	public void Initialize () {
		rotateTimer = 1.0F;
		rotateSpeed = 1.0F;
		currentItemIndex = 0;

		// disable all of the item images
		foreach (Item it in items) {
			it.itemImage.enabled = false;
		}

		// enable the currently visible one
		items[currentItemIndex].itemImage.enabled = true;
	}

	void Update () {

		// increment the timer that displays which item will be chosen in the rotation
		rotateTimer -= Time.deltaTime /rotateSpeed;
		if (rotateTimer <= 0.0F) {

			ChangeItemImage ();

			// reset the timer
			rotateTimer = 1.0F;
		}
	}


	/// <summary>
	/// Increments to the next item in the item order
	/// </summary>
	public void ChangeItemImage () {

		int index = currentItemIndex;
		index++;

		if (currentItemIndex >= items.Count) {
			currentItemIndex = 0;
		}
	}

	public void ChangeItemImage (int newItemIndex) {

		// disable the current item image
		items[currentItemIndex].itemImage.enabled = false;

		//Change the current item
		currentItemIndex = newItemIndex;
		
		// enable the new image
		items[currentItemIndex].itemImage.enabled = true;
	}


}
