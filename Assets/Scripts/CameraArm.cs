using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArm : MonoBehaviour
{
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
    }

    void LateUpdate()
    {
        this.transform.position = _player.transform.position;
    }
    
}
