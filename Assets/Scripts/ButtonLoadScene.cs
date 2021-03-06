﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonLoadScene : MonoBehaviour {
    void Start () {
        Button btn = GetComponent<Button> ();
        btn.onClick.AddListener (TaskOnClick);
    }

    void TaskOnClick () {
        SceneManager.LoadScene(1);
    }
}