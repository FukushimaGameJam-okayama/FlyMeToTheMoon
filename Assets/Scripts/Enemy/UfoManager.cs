using UnityEngine;
using System.Collections;
/*
 * 気球を妨害するufoのみを生成するマネージャークラスです。
 * 2015/8/22 P6 藤田 勇気
 */
public class UfoManager : MonoBehaviour
{

    //呼び出すであろうオブジェクト達
    GameObject ufo;

    // Use this for initialization
    void Start()
    {

        //オブジェクトを読み込んでおく
        ufo = (GameObject)Resources.Load("ufo");

    }

    // Update is called once per frame
    void Update()
    {

    }

    //自身の持つ判定にプレイヤーが入った場合の処理
    private void OnTriggerEnter2D(Collider2D other)
    {
        //プレイヤータグの場合のみ処理
        if (other.tag == "Player")
        {
            //新しいmob1オブジェクトを生成後、判定を消す
            Instantiate(ufo, transform.position, transform.rotation);

            transform.root.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    //自身の持つ判定からプレイヤーが離脱した場合の処理
    private void OnTriggerExit2D(Collider2D other)
    {
        //プレイヤータグの場合のみ処理
        if (other.tag == "Player")
        {
            //判定を元に戻す
            transform.root.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
