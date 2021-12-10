using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

	public float speed = 5f; //set public variable for platform movement-speed
	// Rigidbody2D myBody;
	public GameObject background;		//access the background-object to get infos about screensize
	BGLooper backgroundScript;

	public GameObject coin;		//link coin-prefab

	private Vector3 coinPosition;
	
	public float coinThreshold = 0.35f;			//make publicly accessible coingeneration threshhold variable for easier balancing


	// Use this for initialization
	void Start()
	{
		background = GameObject.Find("Background");
		backgroundScript = background.GetComponent<BGLooper>();

		float coinChance = Random.value;	//generate random value for coin-chance

		coinPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

		if(coinChance > coinThreshold && gameObject.tag != "First")		//check if coinchance is above threshold
		{
			Instantiate(coin, coinPosition, coin.transform.rotation, gameObject.transform);
			
		}

	}

	// Update is called once per frame
	void Update()
	{
        // move continuously to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

		if ((transform.position.x + transform.localScale.x) < (background.transform.position.x - backgroundScript.width)) //check if platforms right bound is out of view, if yes, destroy
		{
            
        Destroy(gameObject);
			
        }
	}
}