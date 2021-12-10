using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{

	[SerializeField] float jumpForce = 10f;
	public float forwardForce = 1.5f;

	Rigidbody2D myBody;
	bool canJump;
	private float xPosition;

	public int coinScore;
	public TextMeshProUGUI coinScoreText;

	AudioSource _audioSource;		//define a variable for the audio-source
	public AudioClip jumpSound;		//make a variable for a jumpsound
	public AudioClip coinSound;		//make a variable for a coin-collection sound

	public ParticleSystem emitParticleSystem;		//

	// Use this for initialization
	void Start()
	{
		myBody = GetComponent<Rigidbody2D>();
		xPosition = transform.position.x;

		coinScore = 0;		//set coinscore to 0	
		coinScoreText.text = ("Coins: " + coinScore);		//set coinscore text to display 0

		_audioSource = GetComponent<AudioSource>();		//assign the players audiosource to the variable

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) {
			Jump();
			
		}
	}

	public void Jump()
	{
		// make sure player can only jump when touching ground
		// if player is behind x-axis starting point, let them catch up
		if (canJump)
		{	
			PlayOneShot(jumpSound);		//if jump is done, call jumpsoundeffect to be played
			canJump = false;
			if (transform.position.x <= xPosition) {
				myBody.velocity = new Vector2(forwardForce, jumpForce);
			} else {
				myBody.velocity = new Vector2(0, jumpForce);
			}
			
			
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		canJump = true;
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Coin")		//if coin is hit, add one point to the coinscore counter and display it on screen
		{
			coinScore ++;
			coinScoreText.text = ("Coins: " + coinScore);
			PlayOneShot(coinSound);		//call the soundplayer to play the coincollection soundeffect
			EmitParticles();
		}
	}

	    public void PlayOneShot(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip, 1.0f);		//play a sound if called
    }

	public void EmitParticles()
        {
            emitParticleSystem.Emit(10);
		}


}