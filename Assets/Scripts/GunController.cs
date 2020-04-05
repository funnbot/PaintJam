using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class GunController : MonoBehaviour {
    int gunType;

    [SerializeField]
    private Transform BulletHolder;
    [SerializeField]
    private float GunDist;
    [SerializeField]
    private float BulletDist;
    [SerializeField]
    private GameObject BulletFab;
    [SerializeField]
    public GameObject BrushFab;
    private Rigidbody2D rb;

    [System.Serializable]
    public struct GunType {
        public float speed;
        public float spread;
        public float size;
        public float reload;
        public float lifetime;

        public Sprite brushSprite;
        public Sprite paintSprite;
        public Sprite splatSprite;
    }
    public GunType[] gunTypes;
    public GunType gun { get => gunTypes[gunType]; }
    public float shotgunSpread;

    public SpriteRenderer gunHolder;
    public Vector2 facing { get; set; }
    private Vector3 brushVelocity;
    public float brushDamp;

    float time = -1;

    void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }

    void Update () {
        time -= Time.deltaTime;
        var pos = facing * (GunDist) + new Vector2 (0, 0.6f);
        gunHolder.transform.localPosition = Vector3.SmoothDamp (gunHolder.transform.localPosition, pos, ref brushVelocity, brushDamp);
        var angle = Mathf.Atan2 (facing.y, facing.x) * Mathf.Rad2Deg;

        var axis = Quaternion.AngleAxis (angle - 90, Vector3.forward);
        gunHolder.transform.localRotation = Quaternion.Slerp (gunHolder.transform.localRotation, axis, 0.1f);
    }

    public void SetGun (int gt) {
        gunType = gt;
        gunHolder.sprite = gun.brushSprite;
        gunHolder.sortingOrder = -1;
    }

    public void ClearBullets () {
        foreach (Transform child in BulletHolder.transform) {
            GameObject.Destroy (child.gameObject);
        }
    }

    public void Shoot (Vector2 dir) {
        if (gunType == 0) {
            if (time > 0) return;
            time = gun.reload;
            var bullet = Instantiate (BulletFab).GetComponent<BulletController> ();
            bullet.Launch ((Vector2) transform.position + dir * BulletDist + new Vector2 (0, 0.6f),
                dir + rb.velocity, gun.speed, gun.spread, gun.size, gun.lifetime, gun.splatSprite);
            var rend = bullet.GetComponent<SpriteRenderer> ();
            rend.sprite = gun.paintSprite;
            bullet.transform.parent = BulletHolder;
        } else if (gunType == 1) {
            if (time > 0) return;
            time = gun.reload;
            for (int i = 0; i < 7; i++) {
                var bullet = Instantiate (BulletFab).GetComponent<BulletController> ();
                var pos = (Vector2) transform.position + dir * BulletDist + Random.insideUnitCircle * shotgunSpread + new Vector2 (0, 0.6f);
                bullet.Launch (pos, dir + rb.velocity, gun.speed, gun.spread, gun.size, gun.lifetime, gun.splatSprite);
                var rend = bullet.GetComponent<SpriteRenderer> ();
                rend.sprite = gun.paintSprite;
                bullet.transform.parent = BulletHolder;
            }
        } else if (gunType == 2) {
            if (time > 0) return;
            time = gun.reload;
            var bullet = Instantiate (BulletFab).GetComponent<BulletController> ();
            bullet.Launch ((Vector2) transform.position + dir * BulletDist + new Vector2 (0, 0.6f),
                dir + rb.velocity, gun.speed, gun.spread, gun.size, gun.lifetime, gun.splatSprite);
            var rend = bullet.GetComponent<SpriteRenderer> ();
            rend.sprite = gun.paintSprite;
            bullet.transform.parent = BulletHolder;
        }

    }
}