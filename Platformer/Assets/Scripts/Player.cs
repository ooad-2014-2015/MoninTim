using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float force = 200f;
    public float speed = 3f;

    private bool grounded = false;
    private Rigidbody2D rbd;

    private int score = 0;
    public int lives = 3;

    // TODO
    // public int x;    // startne
    // public int y;    // pozicije 

	// Use this for initialization
	void Start () {
        rbd = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rbd.position += (-Vector2.right) * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rbd.position += Vector2.right * speed * Time.deltaTime;
        }

        if (grounded == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rbd.AddForce(Vector2.up * force);
        }
    }

    // Prvi collider koji registruje kolizije sa Coinom ili Lavom
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Coin")) {
            this.ActOnCollision("Coin");
        }
        
        if (col.gameObject.CompareTag("Lava")) {
            this.ActOnCollision("Lava");
        }
    }

    // Drugi collider koji služi kao trigger za skakanje (nalazi se na dnu Playera)
    void OnTriggerEnter2D(Collider2D col)
    {
        grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        grounded = false;
    }

    // Poziva odgovarajuce metode u slucaju collide-a
    void ActOnCollision(string tag)
    {
        if (tag == "Coin")
            this.CollectCoin();
        else if (tag == "Lava")
            this.Die(); 
    }

    private void CollectCoin()
    {
        score += 1;
    }

    private void Die()
    {
        lives -= 1;
        Destroy(rbd.gameObject);

        if (lives == -1)
        {    
            // TODO: kraj levela
        }
        else
        {
            // TODO
            // this.ResetNaStartnePozicije(); 
        }
    }

    private void ResetStats()
    {
        score = 0;
        lives = 3;
    }
}
