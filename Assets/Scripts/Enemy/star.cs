using UnityEngine;
using System.Collections;

/*
 *スタンダードな動作を行う障害物の動作を行います。
 *2015/08/21 P6 藤田 勇気
 */

public class star : MonoBehaviour
{

    //オブジェクトの移動速度
    public float speed = -0.1f;

    // Use this for initialization
    void Start()
    {

        //等しく平等に落下する
        this.transform.root.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);

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
