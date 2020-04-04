using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    private Transform Tracking;

    void LateUpdate () {
        var newPos = Vector3.Lerp (transform.position, Tracking.position, 0.03f);
        newPos.z = transform.position.z;
        transform.position = newPos;
    }
}