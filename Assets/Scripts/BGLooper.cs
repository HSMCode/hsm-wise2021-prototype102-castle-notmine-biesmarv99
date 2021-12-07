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
	}

	// Update is called once per frame
	void Update()
	{
		// offset backgroundTexture along x-axis by set time factor
		offset.x += speed * Time.deltaTime;
		mat.SetTextureOffset("_MainTex", offset);

	}
}