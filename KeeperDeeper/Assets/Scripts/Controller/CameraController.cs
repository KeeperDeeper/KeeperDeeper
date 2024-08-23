using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cameraObj;
    Vector3 cameraPos;

    private void Start()
    {
        cameraPos = transform.position;
    }
    public void TranslateCamera()
    {
        cameraPos += new Vector3(0, -5f, 0);
        cameraObj.transform.Translate(cameraPos, Space.World);
    }
}
