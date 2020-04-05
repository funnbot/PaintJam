using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsController : MonoBehaviour {
    [SerializeField]
    private Image[] hearts;

    public void UpdateHealth(int amt) {
        amt = Mathf.Clamp(amt, 0, 4);
        for (int i = 0; i < 4; i++) {
            Color tint = hearts[i].color;
            tint.a = (i < (amt)) ? 1 : 0.26f;
            hearts[i].color = tint;
        }
    }
}