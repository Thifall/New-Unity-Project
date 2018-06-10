using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAffordance : MonoBehaviour
{

    CameraRaycaster _rayCaster;
    [SerializeField] Texture2D WalkableCursor = null;
    [SerializeField] Texture2D HostileTargetCursor = null;
    [SerializeField] Texture2D UnknownCursor = null;
    [SerializeField] float XOffset;
    [SerializeField] float Yoffset;
    // Use this for initialization
    void Start()
    {
        _rayCaster = GetComponent<CameraRaycaster>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_rayCaster.layerHit)
        {
            case Assets.Scripts.Utility.Layer.Walkable:
                Cursor.SetCursor(WalkableCursor, new Vector2(XOffset, Yoffset), CursorMode.Auto);
                break;
            case Assets.Scripts.Utility.Layer.Enemy:
                Cursor.SetCursor(HostileTargetCursor, new Vector2(XOffset, Yoffset), CursorMode.Auto);
                break;
            case Assets.Scripts.Utility.Layer.RaycastEndStop:
                Cursor.SetCursor(UnknownCursor, new Vector2(XOffset, Yoffset), CursorMode.Auto);
                break;
            default:
                print("Error: Unspecified object/layer. Matching cursor icon not found");
                break;
        }

    }
}
