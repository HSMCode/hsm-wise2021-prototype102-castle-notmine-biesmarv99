using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;
    
    public void CompleteLevel ()
    {
        completeLevelUI.SetActive(true);
    }
}
