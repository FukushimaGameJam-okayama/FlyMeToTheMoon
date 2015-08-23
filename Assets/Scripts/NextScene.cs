using UnityEngine;
using System.Collections;

public class NextScene : MonoBehaviour {


	private void PressButton () {
		Debug.Log ("HEllo");
		Application.LoadLevel("scene1");
	}

}
