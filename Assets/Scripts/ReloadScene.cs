using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(RestartScene);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("Reloaded Scene!");
            SceneManager.LoadScene("SaveTheCastle");
            Time.timeScale = 1;
        }
    }
    
    public void RestartScene()
	{
		Debug.Log("Game Restarted!");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
	}
}
