using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LookAtCam : MonoBehaviour
{
    private void Update()
    {
        transform.LookAt(Camera.main.transform.position, Vector3.up);
    }
}
