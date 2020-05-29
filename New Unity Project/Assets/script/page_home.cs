using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class page_home : MonoBehaviour {
    public GameObject home;
    //public GameObject window_roleinfo;
    // Use this for initialization
    void Start()
    {
        //GameObject camera = GameObject.Find("home");
        Transform page_start = home.transform.Find("page_start");
        Transform page_load = home.transform.Find("loadplayer");
        Transform page_create = home.transform.Find("createplayer");
        //page_action.Setactive(1, page_gamehome);
        //page_action.Setactive(0, window_roleinfo);
        page_action.Setactive(1, page_start.gameObject);
       page_action.Setactive(0, page_load.gameObject);
        page_action.Setactive(0, page_create.gameObject);
    }

    void Update() {

        }
    }