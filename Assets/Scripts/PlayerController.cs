using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))  ]
public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float MoveSpeed;

    private Rigidbody2D col;
    private Animator anim;

    void Start() {
        col = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update () {
        Vector2 axes = InputManager.Axes().normalized;
        Vector2 moveAmount = axes * Time.deltaTime * MoveSpeed;
        col.MovePosition((Vector2)transform.localPosition + moveAmount);
        
        anim.SetFloat("X Axis", axes.x);
        anim.SetFloat("Y Axis", axes.y);
    }
}