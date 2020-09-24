using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlyScript : MonoBehaviour {

    public GameManager gameManager;
    public float velocity = 1;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            // Jump
            rigidBody.velocity = Vector2.up * velocity;
            FindObjectOfType<AudioManager>().Play("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        FindObjectOfType<AudioManager>().Stop("Background");
        gameManager.GameOver();
    }
}
