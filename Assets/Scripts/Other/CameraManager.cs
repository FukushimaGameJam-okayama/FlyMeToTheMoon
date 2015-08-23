using UnityEngine;
using System.Collections;
/*
 * メインカメラの動作を処理します
 * 2015/08/23 P6 藤田 勇気
 */
public class CameraManager : MonoBehaviour {

    //プレイヤーのオブジェクトと座標
	public GameObject p;

    public Vector2 pv;
	public float Maxhight=0;
	void Update () {

        //毎フレームプレイヤーの位置を取得する
        pv = p.transform.position;

        //カメラの座標をプレイヤーに合わせる
		if (Maxhight < pv.y)Maxhight = pv.y;
		this.transform.position = new Vector3(this.transform.position.x, Maxhight, this.transform.position.z);
	
	}
}
