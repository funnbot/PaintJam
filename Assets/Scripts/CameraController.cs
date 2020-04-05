using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    private Transform Target;
    [SerializeField]
    private float damp;

    private Vector3 velocity;
    

    void Update () {
        if (Target) {
            Vector3 dest = new Vector3(Target.position.x, Target.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp (transform.position, dest, ref velocity, damp);
        }
    }
}