using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour {
    public GameObject obj1;
    // Use this for initialization
    void Start () {
		
	}
    void OnClick()
    {
        Debug.Log("打开页面" + obj1.name);
        initpage.Setactive(1, obj1);
        //Debug.Log("点击有效");
        //GameObject.Find("creatplayer").SetActive(true);

    }
    public void OnClick0()
    {
        initpage.Setactive(1, obj1);
        //Debug.Log("点击有效");
        //GameObject.Find("creatplayer").SetActive(true);

    }
    public void OnClick_creat()
    {
        GameObject camera = GameObject.Find("UICamera");
        Transform obj = camera.transform.Find("creatplayer");
        initpage.Setactive(1, obj.gameObject);
        // initpage.Setactive(1, obj1);
        //Debug.Log("点击有效");
        //GameObject.Find("creatplayer").SetActive(true);

    }

    // Update is called once per frame
    void Update () {
		
	}

}
