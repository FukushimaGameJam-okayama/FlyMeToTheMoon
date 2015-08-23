using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountCircleAnimation : MonoBehaviour {

	private int Count=3;
	public Sprite[] Numbers = new Sprite[2];//Inspectorから指定.
	public Image CountNumber;//Inspectorから指定.
	public GameObject Tapintro;
	public Rigidbody2D balloonRG;
	public void CircleCountUp () {
		Count--;
		if (Count == 0)	GameStart();
		else CountNumber.sprite = Numbers [Count - 1];
	}
	private void GameStart(){
		Tapintro.SetActive (true);
		balloonRG.gravityScale = 1;
		gameObject.SetActive (false);
	}
}
