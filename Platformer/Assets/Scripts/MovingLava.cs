using UnityEngine;
using System.Collections;

public class MovingLava : MonoBehaviour {
    public float startPosX;
    public float startPosY;

    public float speed = 3f;
    public float lengthOfTrip = 10f;
    public int smjer = 1; // + u desno!     
    
    private Rigidbody2D rbd;

	// Use this for initialization
	void Start () {
        rbd = GetComponent<Rigidbody2D>();

        startPosX = rbd.position.x;
        startPosY = rbd.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        rbd.position += Vector2.right * speed * Time.deltaTime * smjer;
        rbd.transform.position = new Vector2(rbd.position.x, startPosY); // kad udari player u njega da ostane na istoj Y osi. možda ima bolji način umjesto ovog bruteforcea

        //if (rbd.position.x < startPosX || rbd.position.x >= startPosX + lengthOfTrip * 0.5f) 
         //   this.Reset();
	}

    // oba eventa su u slucaju sudara sa necim pa da prestane da se krece u tu stranu, da krene nazad na drugu
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
        smjer *= (-1); // da promijeni predznak!
    }
}
