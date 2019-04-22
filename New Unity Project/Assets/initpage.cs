using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initpage : MonoBehaviour {
    private Text label_tipo;
    private Text label_qili;
    private Text label_shennian;
    private Text label_zhihui;
    private Text label_minjie;
    private Text label_meili;
    private Text data_tipo;
    private Text data_qili;
    private Text data_shennian;
    private Text data_zhihui;
    private Text data_minjie;
    private Text data_meili;

    // Use this for initialization
    void Start () {
        setlabel();
        setdata();
    }
    void Awake()
    {

    }
    // Update is called once per frame
    void Update () {
     
    }


    public static void setdata()
    {
        GameObject camera = GameObject.Find("UICamera");
    
        Transform panel = camera.transform.Find("creatplayer");
        Transform shuxing = panel.transform.Find("shuxing");
        playerdata.Randshuxing();
        //GameObject.Find("creatplayer").SetActive(false)
        shuxing.transform.Find("data_tipo").GetComponent<Text>().text = Convert.ToString(playerdata.p_shuxing[0]);
        shuxing.transform.Find("data_qili").GetComponent<Text>().text = Convert.ToString(playerdata.p_shuxing[1]);
        shuxing.transform.Find("data_shennian").GetComponent<Text>().text = Convert.ToString(playerdata.p_shuxing[2]);
        shuxing.transform.Find("data_zhihui").GetComponent<Text>().text = Convert.ToString(playerdata.p_shuxing[3]);
        shuxing.transform.Find("data_minjie").GetComponent<Text>().text = Convert.ToString(playerdata.p_shuxing[4]);
        shuxing.transform.Find("data_meili").GetComponent<Text>().text = Convert.ToString(playerdata.p_shuxing[5]);
        Transform wuxing = panel.transform.Find("wuxing");
        //GameObject.Find("creatplayer").SetActive(false);
        wuxing.transform.Find("data_jin").GetComponent<Text>().text = "金："+ Convert.ToString(playerdata.p_wuxing[0]);
        wuxing.transform.Find("data_mu").GetComponent<Text>().text = "木：" + Convert.ToString(playerdata.p_wuxing[1]);
        wuxing.transform.Find("data_shui").GetComponent<Text>().text = "水：" + Convert.ToString(playerdata.p_wuxing[2]);
        wuxing.transform.Find("data_huo").GetComponent<Text>().text = "火：" + Convert.ToString(playerdata.p_wuxing[3]);
        wuxing.transform.Find("data_tu").GetComponent<Text>().text = "土：" + Convert.ToString(playerdata.p_wuxing[4]);
    }
    public void setlabel()
    {
        GameObject camera = GameObject.Find("UICamera");

        Transform panel = camera.transform.Find("creatplayer");
        Transform shuxing = panel.transform.Find("shuxing");
        //GameObject.Find("creatplayer").SetActive(false);
        shuxing.transform.Find("label_tipo").GetComponent<Text>().text = "体魄";
        shuxing.transform.Find("label_qili").GetComponent<Text>().text = "气力";
        shuxing.transform.Find("label_shennian").GetComponent<Text>().text = "神念";
        shuxing.transform.Find("label_zhihui").GetComponent<Text>().text = "智慧";
        shuxing.transform.Find("label_minjie").GetComponent<Text>().text = "敏捷";
        shuxing.transform.Find("label_meili").GetComponent<Text>().text = "魅力";

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
            Debug.Log(n+"-----tmp:"+tmp+",randnum:"+ randnum);
        }
        tmp0 = Convert.ToString(tmp*mul);
        Debug.Log("-----tmp0-----" + tmp0);
        return tmp0;
    }
    public static void Setactive(int act, GameObject obj)
    {
        switch (act){
            case 0:
                obj.gameObject.SetActive(false);
                break;
            case 1:
                obj.gameObject.SetActive(true);
                break;
        }

        
    }

}
