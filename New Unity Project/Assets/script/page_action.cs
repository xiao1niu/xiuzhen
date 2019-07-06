using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class page_action : MonoBehaviour {
    public GameObject obj;

    // Use this for initialization
    public static void Setactive(int act, GameObject obj)
    {
        switch (act)
        {
            case 0:
                obj.gameObject.SetActive(false);
                //Debug.Log("关闭页面" + obj.name);
                break;
            case 1:
                obj.gameObject.SetActive(true);
                //Debug.Log("打开页面" + obj.name);
                break;
        }


    }
    public void jump()
    {
        //Debug.Log("打开页面" + obj.name);
        page_action.Setactive(1, obj);
        //Debug.Log("点击有效");
        //GameObject.Find("creatplayer").SetActive(true);

    }
    public void exitgame()
    {
        Application.Quit();
    }
    public void closewin()
    {
        //GameObject win = this.gameObject;
        Transform win = this.transform.parent;
        //parent.gameObject
        Setactive(0, win.gameObject);
    }
}
