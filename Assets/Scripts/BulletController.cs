using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D), typeof(SpriteRenderer))]
public class BulletController : MonoBehaviour {
    Vector3 dir;
    float speed;
    float spread;
    float lifetime;
    bool dead = false;

    private Collider2D col;
    private SpriteRenderer rend;
    private Sprite splat;
    private Rigidbody2D rb;

    void Awake () {
        rb = GetComponent<Rigidbody2D> ();
        rend = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    public void Launch (Vector3 pos, Vector3 dir, float speed, float spread, float size, float lifetime, Sprite splat) {
        this.dir = dir;
        this.speed = speed;
        this.spread = spread;
        this.splat = splat;
        this.lifetime = lifetime;

        transform.position = pos;
        transform.localScale *= Vector2.one * size;

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

        var move = dir * speed + (Vector3) Random.insideUnitCircle * spread;
        rb.AddForce (move, ForceMode2D.Impulse);
    }
    
    private void Die() {
        dead = true;
        rb.simulated = false;
        col.enabled = false;
        rend.sprite = splat;
        transform.localScale *= 0.3f;
    }

    void Update () {
        lifetime -= Time.deltaTime;
        if (!dead && lifetime <= 0) {
            Die();
        }
    }

    void OnCollisionEnter2D (Collision2D other) {
        if (other.transform.CompareTag("playerbullet")) return;
        Die();
    }
}