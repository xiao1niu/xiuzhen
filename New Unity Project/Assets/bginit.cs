using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class bginit : MonoBehaviour {
    public GameObject obj1;
    public GameObject obj2;
    // Use this for initialization
    void Start()
    {

        initpage.Setactive(0,obj1);
        initpage.Setactive(0, obj2);
        GameObject camera = GameObject.Find("UICamera");

        Transform panel = camera.transform.Find("creatplayer");

        panel.gameObject.SetActive(false);
        //panel = camera.transform.Find("loadplayer");

        //panel.gameObject.SetActive(false);
    }

        // Update is called once per frame
        void Update() {

        }
    }