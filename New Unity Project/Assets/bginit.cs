using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bginit : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        GameObject camera = GameObject.Find("UICamera");

        Transform panel = camera.transform.Find("creatplayer");

        panel.gameObject.SetActive(false);
        panel = camera.transform.Find("loadplayer");

        panel.gameObject.SetActive(false);
    }

        // Update is called once per frame
        void Update() {

        }
    }