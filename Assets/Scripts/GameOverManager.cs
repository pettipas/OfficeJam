using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	[HideInInspector]
	public bool isGameOver = false;

	[SerializeField]
	protected Selector selector;

	[SerializeField]
	protected GameObject gameOverPanel;
	[SerializeField]
	protected Image background;
	[SerializeField]
	protected Text characterText;
	[SerializeField]
	protected Image characterImage;
	[SerializeField]
	protected Text ruinedText;
	[SerializeField]
	protected Text christmasText;

	void Start () {
		Initialize ();
	}

	public void Initialize () {
		isGameOver = false;
		gameOverPanel.SetActive (false);
	}

	public void EndGame () {
		if (!isGameOver) {
			isGameOver = true;
			StartCoroutine (endGame());
		}
	}

	protected IEnumerator endGame () {
		
		// enable the gameOver panel
		gameOverPanel.SetActive (true);

		// set the characters
		characterText.text = selector.selectedPerson.name;
		characterImage.sprite = selector.selectedPerson.GetComponent<SpriteRenderer>().sprite;

		// set all images to invisible
		Color newColor = Color.white;
		newColor.a = 0.0F;
		
		background.color = newColor;
		characterText.color = newColor;
		ruinedText.color = newColor;
		christmasText.color = newColor;
		characterImage.color = newColor;
		
		// fade in the background
		float timer = 0.0F;
		for (timer = 0.0F; timer < 1.0F; timer += Time.deltaTime) {
			newColor.a = timer;
			background.color = newColor;
			yield return null;
		}
		
		// fade in the character
		for (timer = 0.0F; timer < 1.0F; timer += Time.deltaTime) {
			newColor.a = timer;
			characterText.color = newColor;
			characterImage.color = newColor;
			yield return null;
		}
		
		// fade in the ruined
		for (timer = 0.0F; timer < 1.0F; timer += Time.deltaTime) {
			newColor.a = timer;
			ruinedText.color = newColor;
			yield return null;
		}
		
		// fade in the christmas
		for (timer = 0.0F; timer < 1.0F; timer += Time.deltaTime) {
			newColor.a = timer;
			christmasText.color = newColor;
			yield return null;
		}

		yield return null;
	}
}
