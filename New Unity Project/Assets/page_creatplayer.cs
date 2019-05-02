using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class page_creatplayer : MonoBehaviour {
    public static GameObject creatplayer_page;
    // Use this for initialization
    void Start () {

    }
    void OnEnable()
    {
        GameObject obj = GameObject.Find("loadplayer");
        initpage.Setactive(0, obj);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
