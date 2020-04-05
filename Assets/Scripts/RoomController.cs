using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour {
    public PlayerController player;
    public AudioSource music;

    public GameObject[] rooms;
    public Transform[] tps;
    public int current = 0;

    public AudioClip explorClip;
    public AudioClip bossClip;

    public void NextRoom() {
        player.transform.position = tps[current].position;
        rooms[current].SetActive(false);
        current++;
        rooms[current].SetActive(true);
        player.gun.ClearBullets();

        if (current == 6) {
            music.clip = bossClip;
            music.Play();
        } else if (current == 7) {
            music.clip = explorClip;
            music.Play();
        }
    }
}