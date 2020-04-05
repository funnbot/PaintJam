using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (Rigidbody2D), typeof (Animator), typeof (GunController))]
public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float MoveSpeed;
    [SerializeField]
    private HeartsController HeartsUI;

    private Rigidbody2D col;
    private Animator anim;
    public GunController gun;

    private Vector2 lastAxes = new Vector2(0, -1);

    public int health = 4;
    float invTime = 2;
    float healthCooldown = 0;

    void Start () {
        col = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
        gun = GetComponent<GunController> ();
    }

    void Update () {
        healthCooldown -= Time.deltaTime;

        Vector2 axes = InputManager.Axes ().normalized;

        Vector2 moveAmount = axes * 0.02f * MoveSpeed;
        col.MovePosition ((Vector2) transform.localPosition + moveAmount);

        anim.SetFloat ("X Axis", axes.x);
        anim.SetFloat ("Y Axis", axes.y);

        var size = Mathf.Abs (axes.x) + Mathf.Abs (axes.y);
        if (size > 0.25f) lastAxes = axes;
        if (InputManager.Shoot ()) gun.Shoot (lastAxes);

        gun.facing = lastAxes;

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(0);
        }
    }

    public void Pickup(int type) {
        if (type < 3) {
            gun.SetGun(type);
        } else {
            health += 1;
            if (health > 4) health = 4;
            HeartsUI.UpdateHealth(health);
        }
    }

    void Damage() {
        if (healthCooldown > 0) return;
        Debug.Log("Damaged");
        healthCooldown = invTime;
        health -= 1;
        HeartsUI.UpdateHealth(health);
        if (health <= 0) {
            SceneManager.LoadScene(1);
        }
    }

    void OnTriggerStay2D(Collider2D col) {
        if (col.CompareTag("enemy")) {
            Damage();
        } else if (col.CompareTag("enemybullet")) {
            Damage();
        }
    }
}