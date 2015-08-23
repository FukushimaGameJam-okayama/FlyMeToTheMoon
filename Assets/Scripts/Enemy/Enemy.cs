using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
            Debug.Log("Hit");
            Destroy(this.transform.root.gameObject);
        }
    }
}
