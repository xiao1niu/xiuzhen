using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pageinit_creatplayer : MonoBehaviour {
    public GameObject page_creat;
    // Use this for initialization
    void Start () {
		
	} 
	
	// Update is called once per frame
	void Update () {
		
	}
    void Setactive()
    {
        GameObject camera = GameObject.Find("UICamera");

        Transform panel = camera.transform.Find("creatplayer");

        panel.gameObject.SetActive(true);
    }
}
