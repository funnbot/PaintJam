using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (RectTransform))]
public class EntityTrackerMapIcon : MonoBehaviour {
    [SerializeField]
    private Transform Tracking;

    private RectTransform rect;

    void Start () {
        rect = (RectTransform) transform;
    }

    void Update () {
        rect.localPosition = (Vector3) TerrainToMap (Tracking.position);
    }

    public static Vector2 TerrainToMap (Vector2 pos) {
        var terrainSize = new Vector2(8.7f, 8.7f) * 6;
        var mapSize = new Vector2 (300, 300); // in pixels
        
        //pos += terrainSize * 0.5f;
        var perc = pos /= terrainSize;

        pos = perc * mapSize;
        pos -= mapSize * 0.5f;

        return pos;
    }
}