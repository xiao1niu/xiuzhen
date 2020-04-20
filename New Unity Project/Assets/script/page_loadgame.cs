using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static playerdata;

public class page_loadgame : MonoBehaviour
{
    public  GameObject loadgame_page;
    public GameObject area_saveinfo;
    public GameObject prefab_savetip;
    // Use this for initialization
    void Start()
    {


    }
   void OnEnable()
    {
        page_action.Setactive(1, loadgame_page.gameObject);
        GameObject camera = GameObject.Find("home");
        Transform obj = camera.transform.Find("loadplayer");
        if (!Directory.Exists(Application.dataPath + "/save"))
        {
            Debug.Log("存档目录：/save 不存在");
            Directory.CreateDirectory(Application.dataPath + "/save");
        }
        else
        {
            DirectoryInfo di = new DirectoryInfo(Application.dataPath + "/save");
            FileInfo[] afi = di.GetFiles("*.txt");
            foreach (var savefile in afi)
            {

                Debug.Log(savefile);
                Save save = playerdata.Loadplayer(Convert.ToString(savefile));
                if (area_saveinfo.transform.Find(save.name) == null)
                {
                    setinfo(save);
                }
                
            }
        }
        /*
            for (int i = 1; i <= n; i++)
        {
            //Transform saveinfo = loadgame_page.transform.Find("saveinfo0" + i);
            
        }
        */
    }
    // Update is called once per frame
    void setinfo(Save savedata)
    {
        
        GameObject savetip = Instantiate(prefab_savetip);
        //Instantiate(prefab_savetip) as GameObject;
        savetip.transform.SetParent(area_saveinfo.transform);
        savetip.transform.localScale = new Vector3(1,1,1);
        savetip.transform.name = savedata.name;
       //parent(area_saveinfo.transform);

        //Transform saveinfo = obj.Find("save0" + i);
        //Transform saveinfo = savetip.transform.Find("saveinfo"); //saveinfo01;
        //Transform newtip = saveinfo.transform.Find("newstory"); //saveinfo01;
        Transform datatable = savetip.transform.Find("layout_info/datatable"); //saveinfo01;psave_shuxing
        //Save save = playerdata.Loadplayer();
        if (savedata == null)
        {
            //Debug.Log("位置2" + i + " ");
            //page_action.Setactive(0, saveinfo.gameObject);
            //Debug.Log("位置" + i + " 新角色");
        }
        else
        {
            //Debug.Log("位置2" + i + " ：" + save.name);
            //page_action.Setactive(0, newtip.gameObject);
            //page_action.Setactive(1, saveinfo.gameObject);
            savetip.transform.Find("layout_info/layout_top/name").GetComponent<Text>().text = Convert.ToString(savetip.transform.Find("layout_info/layout_top/name").GetComponent<Text>().text+":"+savedata.name);
            savetip.transform.Find("layout_info/layout_top/savetime").GetComponent<Text>().text = Convert.ToString(savetip.transform.Find("layout_info/layout_top/savetime").GetComponent<Text>().text + ":" + savedata.savetime);

            //saveinfo.transform.Find("savetime").GetComponent<Text>().text = Convert.ToString(saveinfo.transform.Find("savetime").GetComponent<Text>().text + savedata.name);

            int[] p_shuxing = savedata.psave_shuxing.ToArray();
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

