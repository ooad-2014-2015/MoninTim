using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
    private CircleCollider2D ccd;
	
    // Use this for initialization
	void Start () {
        ccd = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    // TODO: random kretanje, u sve strane za par unita, ili nesto slicno
	}

    // trigger umjesto collidera da se player ne odbije od Coin vec da nastavi svojom putanjom
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(ccd.gameObject);
        }
    }
}
