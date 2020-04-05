using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (RectTransform))]
public class EntityTrackerMapIcon : MonoBehaviour {
    [SerializeField]
    private Transform Tracking;

    public Vector2 mapScale;
    private RectTransform rect;

    void Start () {
        rect = (RectTransform) transform;
    }

    void Update () {
        rect.localPosition = (Vector3) TerrainToMap (Tracking.position);
    }

    public Vector2 TerrainToMap (Vector2 pos) {
        var terrainSize = new Vector2(8.7f * mapScale.x, 8.7f * mapScale.y);
        var mapSize = new Vector2 (300, 300); // in pixels
        
        //pos += terrainSize * 0.5f;
        var perc = pos /= terrainSize;

        pos = perc * mapSize;
        pos -= mapSize * 0.5f;

        return pos;
    }
}