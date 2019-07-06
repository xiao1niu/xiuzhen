using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class page_home : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        GameObject camera = GameObject.Find("home");
        Transform page_load = camera.transform.Find("loadplayer");
        Transform page_create = camera.transform.Find("createplayer");
        page_action.Setactive(0, page_load.gameObject);
        page_action.Setactive(0, page_create.gameObject);
    }

        void Update() {

        }
    }