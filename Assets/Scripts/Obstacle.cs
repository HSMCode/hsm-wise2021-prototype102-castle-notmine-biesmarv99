using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

	public float speed = 3f;
	// Rigidbody2D myBody;

	// Use this for initialization
	void Start()
	{
		// myBody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
        // move continuously to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

		// destroy when out of vision
		// use x-scale of platform object to get actual size
        if (transform.position.x + (transform.localScale.x * 2) < GameObject.Find("PlatformDestroy").transform.position.x) {
            gameObject.SetActive(false);
            Destroy(gameObject, 0.3f);
        }
	}
}