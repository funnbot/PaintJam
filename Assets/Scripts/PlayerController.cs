using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D), typeof (Animator), typeof (GunController))]
public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float MoveSpeed;

    private Rigidbody2D col;
    private Animator anim;
    private GunController gun;

    private Vector2 lastAxes = new Vector2(0, -1);

    int health = 3;

    void Start () {
        col = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
        gun = GetComponent<GunController> ();
    }

    void Update () {
        Vector2 axes = InputManager.Axes ().normalized;

        Vector2 moveAmount = axes * Time.deltaTime * MoveSpeed;
        col.MovePosition ((Vector2) transform.localPosition + moveAmount);

        anim.SetFloat ("X Axis", axes.x);
        anim.SetFloat ("Y Axis", axes.y);

        var size = Mathf.Abs (axes.x) + Mathf.Abs (axes.y);
        if (size > 0.25f) lastAxes = axes;
        if (InputManager.Shoot ()) gun.Shoot (lastAxes);
        else if (Input.GetKeyDown(KeyCode.Alpha1)) gun.SetGun(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2)) gun.SetGun(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3)) gun.SetGun(2);

        gun.facing = lastAxes;
    }

    public void Pickup(int type) {
        if (type == 0) {
            gun.SetGun(0);
            UpdateUI();
        }
    }

    void Damage() {
        health -= 1;

    }

    void UpdateUI() {

    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("enemy")) {
            Damage();
        }
    }
}