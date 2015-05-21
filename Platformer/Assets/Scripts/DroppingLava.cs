using UnityEngine;
using System.Collections;

public class DroppingLava : MonoBehaviour {
    public float startPosX;
    public float startPosY;

    public float speed = 3f;

    private Rigidbody2D rbd;

    // Use this for initialization
	void Start () {
        GetRBD();
	}
	
	// Update is called once per frame
	void Update () {
        rbd.position -= Vector2.up * speed * Time.deltaTime;
	}

    // oba eventa su u slucaju sudara sa necim pa da prestane da pada, da se vrati na pocetak!
    void OnTriggerEnter2D(Collider2D col)
    {
        this.Reset();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        this.Reset();
    }

    private void Reset()
    {
        if (!rbd) GetRBD();
        rbd.position = new Vector2(startPosX, startPosY);
    }

    private void GetRBD()
    {
        rbd = GetComponent<Rigidbody2D>();

        startPosX = rbd.position.x;
        startPosY = rbd.position.y;
    }
}
