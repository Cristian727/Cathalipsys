using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionMouse : MonoBehaviour
{
    public Camera cam;
    public float moveSpeed = 5f; 

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        
        transform.position = Vector2.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime);
    }
}