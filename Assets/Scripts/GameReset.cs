using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameReset : MonoBehaviour {

	public Image AnotherResult;
	void Update () {
		if (Input.touchCount > 0||Input.GetMouseButton(0)) {
			Application.LoadLevel("Scene0");
			AnotherResult.enabled=false;
		}
	}
}
