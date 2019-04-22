using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class page_loadgame : MonoBehaviour {
    public static GameObject loadgame_page;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static void Setactive()
    {
        loadgame_page.gameObject.SetActive(true);
    }
    public static void Offactive()
    {
        loadgame_page.gameObject.SetActive(false);
    }
}
