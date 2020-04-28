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
        shuxing_setlabel();
        skill_setlabel();
    }

    void OnEnable()
    {
        GameObject home = GameObject.Find("home");

        Transform page_load = home.transform.Find("loadplayer");
        page_action.Setactive(0, page_load.gameObject);
        //setlabel();
        shuxing_setlabel();
        skill_setlabel();

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
        public static void shuxing_setdata()
    {
        GameObject home = GameObject.Find("Canvas/home");
    
        Transform page = home.transform.Find("createplayer");
        Transform shuxing = page.transform.Find("shuxing/shuxingtable");
        
        if (shuxing.childCount > 0)
        {
            playerdata.roledatainfo=playerdata.roledata_init(playerdata.roledatainfo);
            Debug.Log("1:" + playerdata.roledatainfo.shuxing_basis.STR);
            //shuxing.transform.Find("data1").GetComponent<Text>().text = "体魄";
            shuxing.transform.Find("data1").GetComponent<Text>().text = "力量 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.STR);
            shuxing.transform.Find("data2").GetComponent<Text>().text = "体格 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.CON);
            shuxing.transform.Find("data3").GetComponent<Text>().text = "敏捷 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.AGI);
            shuxing.transform.Find("data4").GetComponent<Text>().text = "灵巧 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.DEX);
            shuxing.transform.Find("data5").GetComponent<Text>().text = "智力 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.WIS);
            shuxing.transform.Find("data6").GetComponent<Text>().text = "精神 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.PSY);
            shuxing.transform.Find("data7").GetComponent<Text>().text = "感知 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.PER);
            shuxing.transform.Find("data8").GetComponent<Text>().text = "意志 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.WIL);
            shuxing.transform.Find("data9").GetComponent<Text>().text = "魅力 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.CHA);
        }
        else
        {
            playerdata.roledatainfo = playerdata.roledata_init(playerdata.roledatainfo);
            Debug.Log("2:" + playerdata.roledatainfo.shuxing_basis.STR);
            addlabel("力量 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.STR), "data1", shuxing);
            addlabel("体格 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.CON), "data2", shuxing);
            addlabel("敏捷 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.AGI), "data3", shuxing);
            addlabel("灵巧 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.DEX), "data4", shuxing);
            addlabel("智力 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.WIS), "data5", shuxing);
            addlabel("精神 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.PSY), "data6", shuxing);
            addlabel("感知 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.PER), "data7", shuxing);
            addlabel("意志 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.WIL), "data8", shuxing);
            addlabel("魅力 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.CHA), "data9", shuxing);
        }
        //GameObject.Find("creatplayer").SetActive(false)


    }
    public void shuxing_setlabel()
    {
        GameObject camera = GameObject.Find("home");

        Transform panel = camera.transform.Find("createplayer");
        Transform shuxing = panel.transform.Find("shuxing/shuxingtable");

        //Transform wuxing = panel.transform.Find("wuxing/wuxingtable");
        //GameObject.Find("creatplayer").SetActive(false);
        if (shuxing.childCount ==0)
        {
            playerdata.roledatainfo = playerdata.roledata_init(playerdata.roledatainfo);
            Debug.Log("3:" + playerdata.roledatainfo.shuxing_basis.STR);
            addlabel("力量 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.STR), "data1", shuxing);
            addlabel("体格 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.CON), "data2", shuxing);
            addlabel("敏捷 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.AGI), "data3", shuxing);
            addlabel("灵巧 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.DEX), "data4", shuxing);
            addlabel("智力 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.WIS), "data5", shuxing);
            addlabel("精神 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.PSY), "data6", shuxing);
            addlabel("感知 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.PER), "data7", shuxing);
            addlabel("意志 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.WIL), "data8", shuxing);
            addlabel("魅力 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.CHA), "data9", shuxing);
        }
        // shuxing.transform.Find("label_tipo").GetComponent<Text>().text = "体魄";
        // shuxing.transform.Find("label_qili").GetComponent<Text>().text = "气力";
        //shuxing.transform.Find("label_shennian").GetComponent<Text>().text = "神念";
        //shuxing.transform.Find("label_zhihui").GetComponent<Text>().text = "智慧";
        //shuxing.transform.Find("label_minjie").GetComponent<Text>().text = "敏捷"; 
        //shuxing.transform.Find("label_meili").GetComponent<Text>().text = "魅力";

    }
    public static void skill_setdata()
    {
        GameObject home = GameObject.Find("Canvas/home");

        Transform page = home.transform.Find("createplayer");
        Transform shuxing = page.transform.Find("skill/skilltable");

        if (shuxing.childCount > 0)
        {
            playerdata.roledatainfo = playerdata.roledata_init(playerdata.roledatainfo);
            Debug.Log("1:" + playerdata.roledatainfo.shuxing_basis.STR);
            //shuxing.transform.Find("data1").GetComponent<Text>().text = "体魄";
            shuxing.transform.Find("data1").GetComponent<Text>().text = "耕作 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.STR);
            shuxing.transform.Find("data2").GetComponent<Text>().text = "厨艺 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.CON);
            shuxing.transform.Find("data3").GetComponent<Text>().text = "探索 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.AGI);
            shuxing.transform.Find("data4").GetComponent<Text>().text = "生存 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.DEX);
            shuxing.transform.Find("data5").GetComponent<Text>().text = "缝纫 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.WIS);
            shuxing.transform.Find("data6").GetComponent<Text>().text = "锻造 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.PSY);
            shuxing.transform.Find("data7").GetComponent<Text>().text = "木工 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.PER);
            shuxing.transform.Find("data8").GetComponent<Text>().text = "石工 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.WIL);
            shuxing.transform.Find("data9").GetComponent<Text>().text = "医药 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.CHA);
            shuxing.transform.Find("data9").GetComponent<Text>().text = "园艺 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.CHA);
            shuxing.transform.Find("data9").GetComponent<Text>().text = "建筑 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.CHA);
        }
        else
        {
            playerdata.roledatainfo = playerdata.roledata_init(playerdata.roledatainfo);
            Debug.Log("2:" + playerdata.roledatainfo.shuxing_basis.STR);
            addlabel("力量 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.STR), "data1", shuxing);
            addlabel("体格 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.CON), "data2", shuxing);
            addlabel("敏捷 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.AGI), "data3", shuxing);
            addlabel("灵巧 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.DEX), "data4", shuxing);
            addlabel("智力 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.WIS), "data5", shuxing);
            addlabel("精神 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.PSY), "data6", shuxing);
            addlabel("感知 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.PER), "data7", shuxing);
            addlabel("意志 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.WIL), "data8", shuxing);
            addlabel("魅力 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.CHA), "data9", shuxing);
        }
        //GameObject.Find("creatplayer").SetActive(false)


    }
    public void skill_setlabel()
    {
        GameObject camera = GameObject.Find("home");

        Transform panel = camera.transform.Find("createplayer");
        Transform shuxing = panel.transform.Find("skill/skilltable");

        //Transform wuxing = panel.transform.Find("wuxing/wuxingtable");
        //GameObject.Find("creatplayer").SetActive(false);
        if (shuxing.childCount == 0)
        {
            playerdata.roledatainfo = playerdata.roledata_init(playerdata.roledatainfo);
            Debug.Log("3:" + playerdata.roledatainfo.shuxing_basis.STR);
            addlabel("力量 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.STR), "data1", shuxing);
            addlabel("体格 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.CON), "data2", shuxing);
            addlabel("敏捷 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.AGI), "data3", shuxing);
            addlabel("灵巧 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.DEX), "data4", shuxing);
            addlabel("智力 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.WIS), "data5", shuxing);
            addlabel("精神 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.PSY), "data6", shuxing);
            addlabel("感知 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.PER), "data7", shuxing);
            addlabel("意志 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.WIL), "data8", shuxing);
            addlabel("魅力 " + Convert.ToString(playerdata.roledatainfo.shuxing_basis.CHA), "data9", shuxing);
        }
        // shuxing.transform.Find("label_tipo").GetComponent<Text>().text = "体魄";
        // shuxing.transform.Find("label_qili").GetComponent<Text>().text = "气力";
        //shuxing.transform.Find("label_shennian").GetComponent<Text>().text = "神念";
        //shuxing.transform.Find("label_zhihui").GetComponent<Text>().text = "智慧";
        //shuxing.transform.Find("label_minjie").GetComponent<Text>().text = "敏捷"; 
        //shuxing.transform.Find("label_meili").GetComponent<Text>().text = "魅力";

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
