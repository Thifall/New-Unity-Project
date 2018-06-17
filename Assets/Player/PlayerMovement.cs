using Assets.Scripts.Utility;
using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{
    ThirdPersonCharacter m_Character;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
    Vector3 currentClickTarget;

    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponentInParent<CameraRaycaster>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        ProcessRaycastingState();
        ProcessCharacterMovement();
    }

    private void ProcessRaycastingState()
    {
        if (Input.GetMouseButton(0))
        {
            switch (cameraRaycaster.layerHit)
            {
                case Layer.Walkable:
                    currentClickTarget = cameraRaycaster.hit.point;  // So not set in default case
                    break;
                case Layer.Enemy:
                    print("enemy hit");
                    break;
                case Layer.RaycastEndStop:
                default:
                    break;
            }
        }
    }

    private void ProcessCharacterMovement()
    {
        var toMove = currentClickTarget - transform.position;
        if (toMove.magnitude >= 0.5f)
        {
            print("moving");
            m_Character.Move(toMove, false, false);
        }
        else
        {
            m_Character.Move(Vector3.zero, false, false);
        }
    }
}

