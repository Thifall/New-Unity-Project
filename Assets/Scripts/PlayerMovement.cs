using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float MovementSpeed = 1;
    [SerializeField]
    float RotationSpeed = 1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        var forwardMove = Input.GetAxis("Vertical") * (MovementSpeed / 10);
        var rotation = Input.GetAxis("Horizontal") * (RotationSpeed);
        MovePlayer(forwardMove);
        RotatePlayer(rotation);
    }

    private void RotatePlayer(float rotation)
    {
        this.transform.Rotate(0, rotation, 0);
    }

    private void MovePlayer(float forwardMove)
    {
        this.transform.Translate(0, 0, forwardMove, Space.Self);
    }
}
