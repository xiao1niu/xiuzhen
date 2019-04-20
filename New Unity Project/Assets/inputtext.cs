using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputtext : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Savename()
    {
        GameObject camera = GameObject.Find("UICamera");

        Transform panel = camera.transform.Find("creatplayer");
        playerdata.p_name = panel.transform.Find("Inputname").GetComponent<InputField>().text;
        //GameObject.Find("creatplayer").SetActive(false);
        Debug.Log("name="+playerdata.p_name);
    }
}
