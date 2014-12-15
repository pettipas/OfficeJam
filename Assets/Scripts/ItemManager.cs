using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

	public class Item {
		public Image  itemImage;
		public Image  displayedItemImage;
		public string itemName;
		public GameObject itemGameObject;
	}

	// list population
	[SerializeField]
	protected List<Image> itemImages;
	[SerializeField]
	protected List<string> itemNames;
	[SerializeField]
	protected List<GameObject> itemGameObjects;

	// climbing item rotation
	public List<Item> items;
	public List<Item> baseItems;
	public float rotateSpeed;
	protected int currentItemIndex;
	protected float rotateTimer;

	public static ItemManager Instance;

	// Use this for initialization
	void Start () {

		Instance = this;

		// create the item list
		baseItems = new List<Item>();
		for (int i = 0; i < itemImages.Count; i++) {
			Item it = new Item ();
			it.itemImage = itemImages[i];
			it.itemImage.enabled = false;
			it.itemName = itemNames[i];
			it.itemGameObject = itemGameObjects[i];
			
			// add it to the list
			baseItems.Add (it);
		}
		items = baseItems;

		// initialize the item list;
		Initialize ();
	}

	public void Initialize () {

		// initaialize the item list


		// reset the timer and item selection variables
		rotateTimer = 1.0F;
		rotateSpeed = 1.0F;
		currentItemIndex = 0;

		// disable all of the item images and reinitialize it to the default image
		foreach (Item it in items) {
			it.displayedItemImage = it.itemImage;
			it.displayedItemImage.enabled = false;
		}

		// enable the currently visible one
		items[currentItemIndex].displayedItemImage.enabled = true;
	}

	void Update () {

		// increment the timer that displays which item will be chosen in the rotation
		rotateTimer -= Time.deltaTime /rotateSpeed;

		// fade out the selected image
		Color newColor = Color.white;
		newColor.a = Mathf.Clamp01 (1.5F - (1.0F - rotateTimer));
		items[currentItemIndex].displayedItemImage.color = newColor;

		// check if the rotateTimer is 0
		if (rotateTimer <= 0.0F) {
			ChangeItemImageIndex ();

			// reset the timer
			rotateTimer = 1.0F;
		}
	}

	public void IncreaseSpeed () {
		rotateSpeed -= (0.01F);
	}
	
	/// <summary>
	/// Increments to the next item in the item order
	/// </summary>
	public void ChangeItemImageIndex () {

		int index = currentItemIndex;
		index++;

		if (index >= items.Count) {
			index = 0;
		}

		ChangeItemImageIndex (index);
	}

	/// <summary>
	/// Changes the item image index
	/// </summary>
	/// <param name="newItemIndex">New item index.</param>
	public void ChangeItemImageIndex (int newItemIndex) {

		// disable the current item image
		items[currentItemIndex].displayedItemImage.enabled = false;

		//Change the current item
		currentItemIndex = newItemIndex;
		
		// enable the new image
		items[currentItemIndex].displayedItemImage.enabled = true;
	}

	/// <summary>
	/// Returns a game object of the current item selected.
	/// </summary>
	/// <returns>The current item.</returns>
	public GameObject GetCurrentItem () {
		return items[currentItemIndex].itemGameObject;
	}

}
