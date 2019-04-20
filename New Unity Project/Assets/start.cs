using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void OnClick()
    {

        GameObject camera = GameObject.Find("UICamera");

        Transform panel = camera.transform.Find("creatplayer");

        panel.gameObject.SetActive(true);

        //GameObject.Find("creatplayer").SetActive(true);

    }

    // Update is called once per frame
    void Update () {
		
	}

}
