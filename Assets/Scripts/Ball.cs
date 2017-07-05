using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Pressed left click.");
                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
                
            }
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if (hasStarted)
        {
            gameObject.GetComponent<AudioSource>().Play();

            tweak = GetComponent<Rigidbody2D>().velocity;
            tweak.x += (Random.Range(0f, 0.2f) * Mathf.Sign(tweak.x));
            tweak.y += (Random.Range(0f, 0.2f) * Mathf.Sign(tweak.y));
            GetComponent<Rigidbody2D>().velocity = tweak;
        
        }
    }
}
