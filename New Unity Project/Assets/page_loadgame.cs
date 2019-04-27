using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static playerdata;

public class page_loadgame : MonoBehaviour
{
    public  GameObject loadgame_page;
    // Use this for initialization
    void Start()
    {


    }
   void OnEnable()
    {
        int n = 3;
        for (int i = 1; i <= n; i++)
        {
            //Transform saveinfo = loadgame_page.transform.Find("saveinfo0" + i);
            Transform saveinfo = loadgame_page.transform.Find("save0" + i);
            Transform savetip = saveinfo.transform.Find("saveinfo"); //saveinfo01;
             Save save = Loadpalyer(i);
            Debug.Log("位置：" + "saveinfo0" + i);
            if (save == null)
            {
                Debug.Log("位置2" + i + " ");
                initpage.Setactive(0, savetip.gameObject);
                Debug.Log("位置" + i + " 新角色");
            }
            else
            {
                initpage.Setactive(1, savetip.gameObject);
                saveinfo.transform.Find("name").GetComponent<Text>().text = Convert.ToString(save.name);
                //save.psave_shuxing;
                //save.name;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {


    }
}

