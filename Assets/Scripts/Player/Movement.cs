using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float movement_Speed;

    float movement = 0f;

    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * movement_Speed);
    }
}
