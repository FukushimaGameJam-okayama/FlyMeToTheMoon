using UnityEngine;
using System.Collections;
/*
 * 気球を妨害するufoのみを生成するマネージャークラスです。
 * 2015/8/22 P6 藤田 勇気
 */
public class AreaManager1 : MonoBehaviour
{
    //フラグ
    public static bool isBird;

    // Use this for initialization
    void Start()
    {
        isBird = true;
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
            Debug.Log("1 IN");
            isBird = true;
        }
    }

    //自身の持つ判定からプレイヤーが離脱した場合の処理
    private void OnTriggerExit2D(Collider2D other)
    {
        //プレイヤータグの場合のみ処理
        if (other.tag == "Player")
        {
            isBird = false;
        }
    }
}
