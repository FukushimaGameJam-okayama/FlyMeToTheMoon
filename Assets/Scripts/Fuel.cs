using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class Fuel : MonoBehaviour {
	public GameObject FaildResult; 
	public Slider _sliderG,_sliderY;//green,yellow.
	public float Life = 1;
	float LifeMax = 1;
	public BalloonController BalloonCS;  
	
	public void DamageGet()
	{
	
		IsLock=true;
		Life=0;
		timeCount=1;
		LifeChange(-0.1f);
	}

	public void LifeChange(float dif){

		if(LifeMax+dif>1)LifeMax=1;//回復したとき.
		else if(LifeMax+dif<0){// ゲージが0になったとき
			LifeMax=0;
			FaildResult.SetActive(true);
		}
		else LifeMax=LifeMax+dif;
		_sliderY.value = LifeMax;
	}
	private float timeCount;
	public bool IsLock=false;//操作不能にする.
	void Update () {
		Debug.Log ("Maxlife:"+LifeMax);
		if(!IsLock){
			if (BalloonCS.IsFire) {
				Life -= Time.deltaTime/5;
			}else Life += Time.deltaTime/4.5f;
		}else {
			timeCount+=Time.deltaTime;
			if(timeCount>2){
				IsLock=false;//2秒経過すると回復はじめ.
			}
		}
		if (Life > LifeMax)Life = LifeMax;//エラー予防.
		else if (Life < 0)
		{
			Life = 0;
			IsLock=true;
			timeCount=0;
		}
		_sliderG.value = Life;
	}
}
