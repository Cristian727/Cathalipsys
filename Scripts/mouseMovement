using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMove : MonoBehaviour
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


        Vector2 targetPos = new Vector2(mousePos.x, transform.position.y);


        transform.position = Vector2.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
