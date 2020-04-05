using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChangeTrigger : MonoBehaviour {

    public RoomController rc;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag ("character")) {
            rc.NextRoom();
        }
    }
}