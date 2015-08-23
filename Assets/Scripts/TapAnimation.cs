using UnityEngine;
using System.Collections;

public class TapAnimation : MonoBehaviour {


	void Start () {
		iTween.MoveTo (gameObject,iTween.Hash ("y", 5, "time", 3f,"isLocal",true,"oncomplete","Endmove"));
	}

	public void Endmove(){
		Destroy (gameObject);
	}
}
