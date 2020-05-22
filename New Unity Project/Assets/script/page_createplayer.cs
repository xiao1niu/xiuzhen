using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static playerdata;

public class page_createplayer : MonoBehaviour {
    private GameObject gameObject;
    // Use this for initialization
    void Start () {
        
        
    }
    void Awake()
    {
        playerdata.roledatainfo = playerdata.roledata_init(playerdata.roledatainfo);
        shuxing_setlabel();
        skill_setlabel();
    }

    void OnEnable()
    {
        GameObject home = GameObject.Find("home");

        Transform page_load = home.transform.Find("loadplayer");
        page_action.Setactive(0, page_load.gameObject);
        //setlabel();
        //shuxing_setlabel();
        //skill_setlabel();

    }
    // Update is called once per frame
    void Update () {
     
    }
    public static void addlabel(string labeltext, string labelname, Transform parentname)
    {
        //Transform mTransform = GetComponent<Transform>();
        //创建新物体
        GameObject gameObject = new GameObject(labelname);
        //获取新物体的Transform;
        Transform spriteTransform = gameObject.GetComponent<Transform>();
        //给该物体设置父节点
        spriteTransform.SetParent(parentname);
        spriteTransform.localScale = Vector2.one;
        //给该物体设置内容
        Text newlabel = spriteTransform.gameObject.AddComponent<Text>();
        //spriteTransform.GetComponent<Text>().text = labeltext;
        //Text newlabel = spriteTransform.GetComponent<Text>();
        newlabel.text = labeltext;
        //Color: 文本颜色;
        newlabel.color = new Color32(0, 0, 0, 255);
        newlabel.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        newlabel.fontSize = 25;
        newlabel.alignment = TextAnchor.MiddleLeft;
    }
    public static void setdata(string type, Transform lableobj,float[] arr)
    {
        for (int i = 0; i < Configinit.Config_Roledata_type[type].roledata_idcount; i ++)
        {
            if (Configinit.Config_Roledata[roledata_getid(type, i).ToString()].ishide == 1)
            {
                continue;
            }
            else
            {
                lableobj.transform.Find("data" + i).GetComponent<Text>().text = playerdata.playerinfo_text(type, i) + Convert.ToString(arr[i]);
            }
        }
    }
    public static void adddata(string type, Transform lableobj, float[] arr)
    {
        for (int i = 0; i < Configinit.Config_Roledata_type[type].roledata_idcount; i++)
        {
            if(Configinit.Config_Roledata[roledata_getid(type, i).ToString()].ishide==1)
            {
                continue;
            }
            else { 
            //lableobj.transform.Find("data" + i).GetComponent<Text>().text = playerdata.playerinfo_text(type, i) + Convert.ToString(arr[i]);
            addlabel(playerdata.playerinfo_text(type, i) + Convert.ToString(arr[i]), "data" + i, lableobj);
            }
        }
    }
    public static void shuxing_setdata()
    {
        GameObject home = GameObject.Find("Canvas/home");
    
        Transform page = home.transform.Find("createplayer");
        Transform shuxing = page.transform.Find("shuxing/shuxingtable");
        string type = "shuxing";
        if (shuxing.childCount > 0)
        {
            setdata(type, shuxing, playerdata.roledatainfo.shuxing_basis);
            //playerdata.roledatainfo.shuxing_basis=playerdata.shuxing_init(playerdata.roledatainfo);
            //Debug.Log("1:" + playerdata.roledatainfo.shuxing_basis.STR);
            //shuxing.transform.Find("data1").GetComponent<Text>().text = "体魄";
            /*
            for (int i = 0; i < 11; i = i + 1)
            {
                shuxing.transform.Find("data"+i).GetComponent<Text>().text = playerdata.playerinfo_text("shuxing", i) + Convert.ToString(playerdata.roledatainfo.shuxing_basis[i]);
            }
            */
        }
        else
        {
            adddata(type, shuxing, playerdata.roledatainfo.shuxing_basis);
            //playerdata.roledatainfo = playerdata.roledata_init();
            /*
            for (int i = 0; i < 11; i = i + 1)
            {
                addlabel(playerdata.playerinfo_text("shuxing", i) + Convert.ToString(playerdata.roledatainfo.shuxing_basis[i]), "data"+i, shuxing);

            }
            */
        }
        //GameObject.Find("creatplayer").SetActive(false)


    }
    public void shuxing_setlabel()
    {
        GameObject camera = GameObject.Find("home");

        Transform panel = camera.transform.Find("createplayer");
        Transform shuxing = panel.transform.Find("shuxing/shuxingtable");
        //Configinit config = new Configinit();
        //Transform wuxing = panel.transform.Find("wuxing/wuxingtable");
        //GameObject.Find("creatplayer").SetActive(false);
        if (shuxing.childCount ==0)
        {
            adddata("shuxing", shuxing, playerdata.roledatainfo.shuxing_basis);
            //playerdata.roledatainfo = playerdata.roledata_init();
            /*
            for (int i = 0; i < 11; i = i + 1)
            {
                //Debug.Log(101 + i);
                //Debug.Log(Configinit.Config_Roledata[102].roledata_name);
                addlabel(playerdata.playerinfo_text("shuxing",i) + Convert.ToString(playerdata.roledatainfo.shuxing_basis[i]), "data" + i, shuxing);
                //addlabel(Configinit.Config_Roledata[103].roledata_name + Convert.ToString(playerdata.roledatainfo.shuxing_basis[i]), "data" + i, shuxing);

                //addlabel("力量" + Convert.ToString(playerdata.roledatainfo.shuxing_basis[i]), "data" + i, shuxing);

            }
            */
        }
    }
    public static void skill_setdata()
    {
        GameObject home = GameObject.Find("Canvas/home");

        Transform page = home.transform.Find("createplayer");
        Transform skill = page.transform.Find("skill/skilltable");

        if (skill.childCount > 0)
        {
            //playerdata.roledatainfo = playerdata.roledata_init();
            //Debug.Log("1:" + playerdata.roledatainfo.shuxing_basis.STR);
            //shuxing.transform.Find("data1").GetComponent<Text>().text = "体魄";
            for (int i = 0; i < 11; i = i + 1)
            {
                skill.transform.Find("data"+i).GetComponent<Text>().text = playerdata.playerinfo_text("skill_work", i) + Convert.ToString(playerdata.roledatainfo.skill_work_basis[i]);

            }
        }
        else
        {
            //playerdata.roledatainfo = playerdata.roledata_init();
            for (int i = 0; i < 11; i = i + 1)
            {
                addlabel(playerdata.playerinfo_text("skill_work", i) + Convert.ToString(playerdata.roledatainfo.skill_work_basis[i]), "data"+i, skill);

            }
           
        }
        //GameObject.Find("creatplayer").SetActive(false)


    }
    public void skill_setlabel()
    {
        GameObject camera = GameObject.Find("home");

        Transform panel = camera.transform.Find("createplayer");
        Transform skill = panel.transform.Find("skill/skilltable");

        //Transform wuxing = panel.transform.Find("wuxing/wuxingtable");
        //GameObject.Find("creatplayer").SetActive(false);
        if (skill.childCount == 0)
        {
            //playerdata.roledatainfo = playerdata.roledata_init();
            //Debug.Log("3:" + playerdata.roledatainfo.skill_work_basis.STR);
            for (int i = 0; i < 11; i = i + 1)
            {
                addlabel(playerdata.playerinfo_text("skill_work", i) + Convert.ToString(playerdata.roledatainfo.skill_work_basis[i]), "data" + i, skill);

            }
        }

    }
    private String GetNum(int num,int minValue, int maxValue, int mul)
    {
        int n = 0;
        int tmp = 0;
        int randnum = 0;
        string tmp0;
        System.Random ra;
        while (n < num){
            ra = new System.Random(unchecked((int)DateTime.Now.Ticks)*7);
            randnum = ra.Next(minValue, maxValue);
            tmp = tmp + randnum ;
            n = n + 1;
            //Debug.Log(n+"-----tmp:"+tmp+",randnum:"+ randnum);
        }
        tmp0 = Convert.ToString(tmp*mul);
        //Debug.Log("-----tmp0-----" + tmp0);
        return tmp0;
    }
    public void suiji()
    {
        playerdata.roledatainfo = playerdata.roledata_init(playerdata.roledatainfo);
        shuxing_setdata();
        skill_setdata();
    }
    public void save()
    {
        playerdata.Savepalyer();
    }
    public void Savename()
    {
        GameObject camera = GameObject.Find("home");

        Transform panel = camera.transform.Find("createplayer");
        playerdata.p_name = panel.transform.Find("Inputname").GetComponent<InputField>().text;
        //GameObject.Find("creatplayer").SetActive(false);
        //Debug.Log("name=" + playerdata.p_name);
    }
}
