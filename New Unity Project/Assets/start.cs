using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour {
    public GameObject obj1;
    // Use this for initialization
    void Start () {
		
	}
    public void OnClick()
    {
        initpage.Setactive(1, obj1);

        //GameObject.Find("creatplayer").SetActive(true);

    }

    // Update is called once per frame
    void Update () {
		
	}

}
