using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winclose : MonoBehaviour {
    public GameObject obj;
    // Use this for initialization
    void Start () {
		
	}
	public void onclick()
    {
        initpage.Setactive(0, obj);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
