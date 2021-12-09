using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

	public float speed = 3f; //set public variable for platform movement-speed
	// Rigidbody2D myBody;
	public GameObject background;
	BGLooper backgroundScript;

	// Use this for initialization
	void Start()
	{
		background = GameObject.Find("Background");
		backgroundScript = background.GetComponent<BGLooper>();
	}

	// Update is called once per frame
	void Update()
	{
        // move continuously to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

		// destroy when out of vision
		// use x-scale of platform object to get actual size
        //if (transform.position.x + (transform.localScale.x * 2) < GameObject.Find("PlatformDestroy").transform.position.x) {
			if ((transform.position.x + transform.localScale.x) < (background.transform.position.x - backgroundScript.width)) {
            //gameObject.SetActive(false);
           Destroy(gameObject);
			
        }
	}
}