using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour
{

	public float speed = 0.1f;
	private Vector2 offset = Vector2.zero;
	private Material mat;

	// Use this for initialization
	void Start()
	{
		// initialise material and backgroundTexture offset
		mat = GetComponent<Renderer>().material;
		offset = mat.GetTextureOffset("_MainTex");

				// set height of backgroundTexture to screenResolution
		float height = Camera.main.orthographicSize * 2f;
		float width = height * Screen.width / Screen.height;

		if (gameObject.name == "Background")
		{
			transform.localScale = new Vector3(width, height, 0);
		}
		else
		{
			transform.localScale = new Vector3(width + 3f, 2, 0);
		}
	}

	// Update is called once per frame
	void Update()
	{
		// offset backgroundTexture along x-axis by set time factor
		offset.x += speed * Time.deltaTime;
		mat.SetTextureOffset("_MainTex", offset);

	}
}