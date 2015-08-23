using UnityEngine;
using System.Collections;

/*
 *スタンダードな動作を行う障害物の動作を行います。
 *2015/08/21 P6 藤田 勇気
 */

public class ufo : MonoBehaviour
{

    //オブジェクトの移動速度
    public float speed = 1.0f;

    //初期位置の判定を保持
    bool isright;

    //現在何フレーム進んだか
    int frame;

    // Use this for initialization
    void Start()
    {

        //フレーム数を初期化
        frame = 0;

        //自身の生成された座標に応じて左右どちらかに真っ直ぐ飛ぶ
        if (this.transform.position.x > 0)
        {

            //0より大きい(右側に居る)
            isright = true;

        }
        else
        {
            //画像を反転する
            this.transform.root.transform.localScale = new Vector2(this.transform.root.transform.localScale.x * -1, this.transform.root.transform.localScale.y);

            //0より小さい(左側に居る)
            isright = false;
            

        }

    }

    // Update is called once per frame
    void Update()
    {
        //初期位置が右かどうか
        if (isright)
        {
            //60フレームまではx方向
            if (frame < 60)
            {
                this.transform.root.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
            }
            //120フレームまではy方向
            else if (frame < 120)
            {
                this.transform.root.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            }
            else
            {
                //フレームカウントを初期化
                frame = 0;
            }
        }
        else
        {
            //60フレームまではx方向
            if (frame < 60)
            {
                this.transform.root.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
            }
            //120フレームまではy方向
            else if (frame < 120)
            {
                this.transform.root.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            }
            else
            {
                //フレームカウントを初期化
                frame = 0;
            }
        }

        //フレームカウントを増加
        frame++;

    }

    //自身の持つ判定にプレイヤーが入った場合の処理
    private void OnTriggerEnter2D(Collider2D other)
    {
        //プレイヤータグの場合はゲームオーバー(仮で自身をDestroy)
        if (other.tag == "Player")
        {
            Debug.Log("Hit");
            Destroy(this.transform.root.gameObject);
        }
    }
}
