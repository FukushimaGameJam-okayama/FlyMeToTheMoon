using UnityEngine;
using System.Collections;

public class AreaManager3 : MonoBehaviour {

    //フラグ
    public static bool isStar;

	// Use this for initialization
	void Start () {

        isStar = false;
	
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
            Debug.Log("3 IN");
            isStar = true;
        }
    }

    //自身の持つ判定からプレイヤーが離脱した場合の処理
    private void OnTriggerExit2D(Collider2D other)
    {
        //プレイヤータグの場合のみ処理
        if (other.tag == "Player")
        {
            isStar = false;
        }
    }
}
