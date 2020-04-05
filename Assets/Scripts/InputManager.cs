using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager {

    public static Vector2 Axes() {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public static bool Shoot() {
        return Input.GetKey(KeyCode.Space);
    }
}