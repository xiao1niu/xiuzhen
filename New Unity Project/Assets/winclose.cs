﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winclose : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void onclick()
    {
        GameObject camera = GameObject.Find("UICamera");

        Transform panel = camera.transform.Find("creatplayer");

        panel.gameObject.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
