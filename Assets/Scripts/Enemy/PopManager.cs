using UnityEngine;
using System.Collections;

/*
 * 気球を妨害する障害物達をエリアに応じて一括して判別、生成するマネージャークラスです。
 * 2015/8/22 P6 藤田 勇気
 */
public class PopManager : MonoBehaviour {

    //呼び出すであろうオブジェクト達
    GameObject bird;

    GameObject pika;

    GameObject star;

	// Use this for initialization
	void Start () {

        //オブジェクトを読み込んでおく
        bird = (GameObject)Resources.Load("bird");

        pika = (GameObject)Resources.Load("pika");

        star = (GameObject)Resources.Load("star");

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //自身の持つ判定にプレイヤーが入った場合の処理
    private void OnTriggerEnter2D(Collider2D other)
    {
        //プレイヤータグの場合のみ処理
        if (other.tag == "Player")
        {
            //Debug.Log("Hit");

            if (AreaManager1.isBird)
            {
                //新しいオブジェクトを生成後、判定を消す
                Instantiate(bird, transform.position, transform.rotation);
              
            }
            else if(AreaManager2.isPika)
            {
                //新しいオブジェクトを生成後、判定を消す
                Instantiate(pika, transform.position, transform.rotation);

            }
            else if (AreaManager3.isStar)
            {
                //新しいオブジェクトを生成後、判定を消す
                Instantiate(star, transform.position, transform.rotation);

            }
            
            
        }
    }

}
