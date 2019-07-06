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
        GameObject camera = GameObject.Find("home");
        Transform obj = camera.transform.Find("loadplayer");
        int n = 3;
        for (int i = 1; i <= n; i++)
        {
            //Transform saveinfo = loadgame_page.transform.Find("saveinfo0" + i);
            Transform saveinfo = obj.Find("save0" + i);
            Transform savetip = saveinfo.transform.Find("saveinfo"); //saveinfo01;
            Transform newtip = saveinfo.transform.Find("newplayer"); //saveinfo01;
            Transform datatable = savetip.transform.Find("datatable"); //saveinfo01;psave_shuxing
            Save save = playerdata.Loadplayer(i);
            if (save == null)
            {
                //Debug.Log("位置2" + i + " ");
                page_action.Setactive(0, savetip.gameObject);
                //Debug.Log("位置" + i + " 新角色");
            }
            else
            {
                //Debug.Log("位置2" + i + " ：" + save.name);
                page_action.Setactive(0, newtip.gameObject);
                page_action.Setactive(1, savetip.gameObject);
                savetip.transform.Find("name").GetComponent<Text>().text = Convert.ToString(save.name);
                int[] p_shuxing = save.psave_shuxing.ToArray();
                //Debug.Log("位置" + i + " ：" + Convert.ToString(p_shuxing[1]));
                if (datatable.childCount == 0)
                {
                    page_createplayer.addlabel("体魄 " + Convert.ToString(p_shuxing[0]), "data1", datatable);
                    page_createplayer.addlabel("气力 " + Convert.ToString(p_shuxing[1]), "data2", datatable);
                    page_createplayer.addlabel("神念 " + Convert.ToString(p_shuxing[2]), "data3", datatable);
                    page_createplayer.addlabel("智慧 " + Convert.ToString(p_shuxing[3]), "data4", datatable);
                    page_createplayer.addlabel("敏捷 " + Convert.ToString(p_shuxing[4]), "data5", datatable);
                    page_createplayer.addlabel("魅力 " + Convert.ToString(p_shuxing[5]), "data6", datatable);
                }
                //save.psave_shuxing;
                //save.name;
            }
        }
    }
    // Update is called once per frame

    void Update()
    {


    }
    public void jump_creat()
    {
        GameObject camera = GameObject.Find("home");
        Transform obj = camera.transform.Find("createplayer");
        page_action.Setactive(1, obj.gameObject);
        // initpage.Setactive(1, obj1);
        //Debug.Log("点击有效");
        //GameObject.Find("creatplayer").SetActive(true);

    }
}

