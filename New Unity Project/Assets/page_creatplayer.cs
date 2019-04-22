using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class page_creatplayer : MonoBehaviour {
    public static GameObject creatplayer_page;
    // Use this for initialization
    void Start () {
		
	} 
	
	// Update is called once per frame
	void Update () {
		
	}
    public static void Setactive(){
        creatplayer_page.gameObject.SetActive(true);
    }
    public static void Offactive(){
        creatplayer_page.gameObject.SetActive(false);
    }
}
