//#define PC
#define Phone

using UnityEngine;
using System.Collections;

public class BalloonController : MonoBehaviour {

	public Rigidbody2D Balloon;
	private float Speed=3.8f;
	public float MaxSpeed,MinSpeed;
	public GameObject FaildResult;//Faild.
	public bool IsFire=false;
	public Camera MainCamera;
	public Fuel FuelS;
	private Animator thisAnimator;
	void Start(){
		thisAnimator = gameObject.GetComponent<Animator> ();
	}
	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Enemy") {
			Destroy(collision.gameObject);
			FuelS.DamageGet();
			thisAnimator.enabled=false;
			thisAnimator.enabled=true;
		}
	}
	public void BlinkEnd(){//Animatortから呼ばれる.
		thisAnimator.enabled=false;
	}
	public void  SpeedChange(float difSpeed) {
		Speed=Speed+difSpeed;
		if(Speed+difSpeed>MaxSpeed)Speed=MaxSpeed;
		else if(Speed+difSpeed<MinSpeed)Speed=MinSpeed;
	} 
	public void GameSuccess(){
		iTween.MoveTo(gameObject,iTween.Hash ("x",0,"y", 123, "time", 6f,"isLocal",true));
		iTween.ScaleTo (gameObject, iTween.Hash ("x", 0.1f, "y", 0.1f, "time", 3f, "isLocal", true));
		Balloon.isKinematic = true;
	}
	private bool GameEnd;
	private Vector3 de;//画面外かの判定.
	void Update () {
		de = MainCamera.WorldToViewportPoint(gameObject.transform.position);
		#if PC

		if ((de.x>0.15f && Input.GetKey (KeyCode.LeftArrow))||(de.x<0.89f && Input.GetKey (KeyCode.RightArrow))){
			if((de.x>0.15f && Input.GetKey (KeyCode.LeftArrow))&&(de.x<0.89f && Input.GetKey (KeyCode.RightArrow)))Balloon.velocity=Vector2.zero;
			else if(de.x>0.15f && Input.GetKey (KeyCode.LeftArrow))Balloon.velocity=Vector2.left; 
			else if(de.x<0.89f && Input.GetKey (KeyCode.RightArrow))Balloon.velocity=Vector2.right;
		}
		else Balloon.velocity=Vector2.zero;

		if (!FuelS.IsLock && Input.GetKey (KeyCode.UpArrow)&&!GameEnd){
			Balloon.AddForce (new Vector2 (0, 70.0f));
			IsFire=true;
		}else IsFire=false;
		#endif

		#if Phone

		if((de.x<0.89f&&Input.acceleration.x>0.01f)||(de.x>0.15f && Input.acceleration.x<-0.01f))Balloon.velocity=new Vector2((Input.acceleration.x)*Speed,0);
		else Balloon.velocity=new Vector2(0,0);

		if (!FuelS.IsLock && Input.touchCount > 0&&!GameEnd){
			Balloon.AddForce (new Vector2 (0, 30.0f));
			IsFire=true;
		}else IsFire=false;
		#endif
		if (de.y < 0 && !GameEnd) {
			GameEnd = true;
			FaildResult.SetActive(true);
		}
	}
//	void OnGUI(){
//		GUI.Label(new Rect(0,0,100,100),"x:"+de.x);//Input.acceleration.x);
//	}

}
