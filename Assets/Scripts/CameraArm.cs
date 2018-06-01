using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArm : MonoBehaviour
{
    private GameObject _player;
    private bool _backPedaling;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        _backPedaling = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
    }

    void LateUpdate()
    {
        if (!_backPedaling)
        {
            RotateCamera();
        }
        AdjustPosition();
    }

    private void RotateCamera()
    {
        if (!Input.GetMouseButton(1))
        {
            FollowPlayerRotation();
        }
        else
        {
            RotateCameraBasedOnMouseRotation();
        }
    }

    private void RotateCameraBasedOnMouseRotation()
    {
        var rotation = Input.GetAxis("Mouse X");
        this.transform.Rotate(0, rotation * 5, 0f);
    }

    private void FollowPlayerRotation()
    {
        this.transform.rotation = _player.transform.rotation;
    }

    private void AdjustPosition()
    {
        this.transform.position = _player.transform.position;
    }
}
