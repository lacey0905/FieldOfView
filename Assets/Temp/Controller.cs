using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float moveSpeed = 6f;

    Rigidbody rigidbody;
    Camera viewCamera;
    Vector3 velocity;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 input = new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y);
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(input);
        transform.LookAt(mousePos + Vector3.up * transform.position.y);
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
    }
}
