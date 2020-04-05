using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public Transform player;
    public GunController gun;

    public float health;

    public SpriteRenderer rend;
    public Sprite[] EnemySprites;
    public enum EnemyType { Lizard, Beatle, Snake, Piet }
    public EnemyType type;

    void Start () {
        gun = player.GetComponent<GunController> ();
        rend.sprite = EnemySprites[(int) type];
    }

    void Damage (float amt) {
        health -= amt;
        if (health <= 0) {
            Destroy (gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        if (type == EnemyType.Piet) {
            transform.position += transform.right * Time.deltaTime;
            transform.rotation = LookAt2D (player.position, 0);
        } else {
            transform.position -= transform.up * Time.deltaTime;
            transform.rotation = LookAt2D (player.position, 90);
        }
    }

    Quaternion LookAt2D (Vector2 pos, float offsetDegree = 0) {
        var dir = (pos - (Vector2) transform.position).normalized;
        var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis (angle + offsetDegree, Vector3.forward);
    }

    void OnCollisionEnter2D (Collision2D other) {
        if (other.collider.CompareTag ("playerbullet")) {
            Damage (gun.gun.lifetime);
        }
    }
}