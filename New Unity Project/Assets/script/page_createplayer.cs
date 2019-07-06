using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class page_createplayer : MonoBehaviour {
    private GameObject gameObject;
    // Use this for initialization
    void Start () {
        setlabel();
        
    }
    void Awake()
    {
        setdata();
    }

    void OnEnable()
    {
        GameObject home = GameObject.Find("home");

        Transform page_load = home.transform.Find("loadplayer");
        page_action.Setactive(0, page_load.gameObject);
        //setlabel();
        setdata();

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
        newlabel.fontSize = 16;
        newlabel.alignment = TextAnchor.MiddleCenter;
    }
        public static void setdata()
    {
        GameObject home = GameObject.Find("Canvas/home");
    
        Transform page = home.transform.Find("createplayer");
        Transform shuxing = page.transform.Find("shuxing/shuxingtable");
        playerdata.Randshuxing();
        //GameObject.Find("creatplayer").SetActive(false)
        if (shuxing.childCount >0 ){
        shuxing.transform.Find("data_tipo").GetComponent<Text>().text = Convert.ToString(playerdata.p_shuxing[0]);
        shuxing.transform.Find("data_qili").GetComponent<Text>().text = Convert.ToString(playerdata.p_shuxing[1]);
        shuxing.transform.Find("data_shennian").GetComponent<Text>().text = Convert.ToString(playerdata.p_shuxing[2]);
        shuxing.transform.Find("data_zhihui").GetComponent<Text>().text = Convert.ToString(playerdata.p_shuxing[3]);
        shuxing.transform.Find("data_minjie").GetComponent<Text>().text = Convert.ToString(playerdata.p_shuxing[4]);
        shuxing.transform.Find("data_meili").GetComponent<Text>().text = Convert.ToString(playerdata.p_shuxing[5]);
        Transform wuxing = page.transform.Find("wuxing/wuxingtable");
            //GameObject.Find("creatplayer").SetActive(false);
            wuxing.transform.Find("data_jin").GetComponent<Text>().text =  Convert.ToString(playerdata.p_wuxing[0]);
        wuxing.transform.Find("data_mu").GetComponent<Text>().text =  Convert.ToString(playerdata.p_wuxing[1]);
        wuxing.transform.Find("data_shui").GetComponent<Text>().text =  Convert.ToString(playerdata.p_wuxing[2]);
        wuxing.transform.Find("data_huo").GetComponent<Text>().text =  Convert.ToString(playerdata.p_wuxing[3]);
        wuxing.transform.Find("data_tu").GetComponent<Text>().text = Convert.ToString(playerdata.p_wuxing[4]);
      }

    }
    public void setlabel()
    {
        GameObject camera = GameObject.Find("home");

        Transform panel = camera.transform.Find("createplayer");
        Transform shuxing = panel.transform.Find("shuxing/shuxingtable");
        Transform wuxing = panel.transform.Find("wuxing/wuxingtable");
        //GameObject.Find("creatplayer").SetActive(false);
        if (shuxing.childCount==0){ 
        addlabel("体魄", "label_tipo", shuxing);
        addlabel("气力", "label_qili", shuxing);
        addlabel("神念", "label_shennian", shuxing);
        addlabel("智慧", "label_zhihui", shuxing);
        addlabel("敏捷", "label_minjie", shuxing);
        addlabel("魅力", "label_meili", shuxing);
        addlabel("00", "data_tipo", shuxing);
        addlabel("00", "data_qili", shuxing);
        addlabel("00", "data_shennian", shuxing);
        addlabel("00", "data_zhihui", shuxing);
        addlabel("00", "data_minjie", shuxing);
        addlabel("00", "data_meili", shuxing);
        }
        if (wuxing.childCount == 0)
        {
            addlabel("金", "label_jin", wuxing);
            addlabel("木", "label_mu", wuxing);
            addlabel("水", "label_shui", wuxing);
            addlabel("火", "label_huo", wuxing);
            addlabel("土", "label_tu", wuxing);
            addlabel("00", "data_jin", wuxing);
            addlabel("00", "data_mu", wuxing);
            addlabel("00", "data_shui", wuxing);
            addlabel("00", "data_huo", wuxing);
            addlabel("00", "data_tu", wuxing);
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
        setdata();
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
