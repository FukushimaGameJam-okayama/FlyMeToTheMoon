using UnityEngine;
using System.Collections;

/*
 *スタンダードな動作を行う障害物の動作を行います。
 *2015/08/21 P6 藤田 勇気
 */

public class pika : MonoBehaviour
{

    //オブジェクトの移動速度
    public float speed = -0.01f;

    // Use this for initialization
    void Start()
    {

        //自身の生成された座標に応じて左右どちらかに真っ直ぐ飛ぶ
        if (this.transform.position.x > 0)
        {

            //0より大きい(右側に居る)ので左に向かって飛ぶ
            this.transform.root.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, -speed);

        }
        else
        {
            //画像を反転する
            this.transform.root.transform.localScale = new Vector2(this.transform.root.transform.localScale.x * -1, this.transform.root.transform.localScale.y);

            //0より小さい(左側に居る)ので右に向かって飛ぶ
            this.transform.root.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, speed);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    //自身の持つ判定にプレイヤーが入った場合の処理
//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        //プレイヤータグの場合はゲームオーバー(仮で自身をDestroy)
//        if (other.tag == "Player")
//        {
//            Debug.Log("Hit");
//            Destroy(this.transform.root.gameObject);
//        }
//    }
}
