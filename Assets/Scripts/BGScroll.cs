using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    //Speed of the scrolling Background
    public float speed = 4f; 
    private Vector3 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
    }

    void Update()
    {
        //Scrolling Background 
        transform. Translate( translation: Vector3. left*speed*Time.deltaTime);
    }
}
