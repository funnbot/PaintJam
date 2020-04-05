using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (SpriteRenderer))]
public class PickupController : MonoBehaviour {
    public PlayerController player;

    public Sprite[] pickupSprites;
    public enum PickupType { Normal, Shotgun, Big, Heart }
    public PickupType type;

    private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start () {
        rend = GetComponent<SpriteRenderer> ();
        rend.sprite = pickupSprites[(int) type];
    }

    void Update() {
        transform.position += new Vector3(0, Mathf.Sin(Time.deltaTime*2), 0);
    }
}