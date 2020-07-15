using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class page_createworld : MonoBehaviour
{
    public GameObject table_worldset;
    public GameObject prefab_unit_worldset;
    void Start()
    {

    }
    void Awake()
    {
        addtoggle("set_worldsize", 1);
        addtoggle("set_resamount", 2);
        addtoggle("set_forestamount", 3);
        //Debug.Log("-----settoggle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void addtoggle (string title,int n)
    {
        GameObject unit_worldset = Instantiate(prefab_unit_worldset);
        //Instantiate(prefab_savetip) as GameObject;
        unit_worldset.transform.SetParent(table_worldset.transform);
        unit_worldset.transform.localScale = new Vector3(1, 1, 1);
        unit_worldset.transform.name = "set_"+n;
        string[] togglelist = setTogglelist(title);
        unit_worldset.transform.Find("unitname").GetComponent<Text>().text= togglelist[0];
        GameObject unit_toggle = unit_worldset.transform.Find("table_toggle/Toggle1").gameObject;
        GameObject ToggleX=new GameObject();
        //string[] togglelist = setTogglelist(title);
        //Debug.Log("{---" + togglelist.Length);
        for (int num = 1; num < togglelist.Length; num++)
            {
            try
            {
                ToggleX = unit_worldset.transform.parent.Find("Toggle" + num).gameObject;
                    //GetComponentInParent.().Find("set"+n+ "table_toggle/Toggle" + num).gameObject;

            } 
            catch
            {
                //Debug.Log("{0} First exception."+ e.Message);
                if (num != 1)
                {
                    ToggleX = Instantiate(unit_toggle);
                    ToggleX.transform.SetParent(unit_worldset.transform.Find("table_toggle"));
                    ToggleX.transform.name = "Toggle" + num;
                    ToggleX.transform.localScale = new Vector3(1,1,1);
                }
                else
                {
                    ToggleX = unit_toggle;
                }
            }
            finally
            {
                //Debug.Log("Toggle" + num + "/Label");
                //unit_toggle.GetComponent<Text>().text = togglelist[num];
                ToggleX.transform.Find("Label").gameObject.GetComponent<Text>().text = togglelist[num];
                Toggle tg = ToggleX.GetComponent<Toggle>(); 
                tg.onValueChanged.AddListener(delegate (bool isOn) {
                   // this.OnValueChanged(ToggleX, isOn);
                });


            }
        }
    }

    string[] setTogglelist(string title)
    {
        string[] toggle= { "1"};
        switch (title) { 
            case"set_worldsize":
                toggle = new string[] { "世界尺寸","小","中", "大" };
                break;
            case "set_resamount":
                toggle = new string[] { "资源数量","少量", "一般", "大量" };
                break;
            case "set_forestamount":
                toggle = new string[] { "森林范围", "少量", "一般", "大量" };
                break;
        }
        return toggle;
    }
    public int OnValueChanged( GameObject send, bool isOn)
    {
        int chose=0;
        IEnumerable<Toggle> toggleGroup = send.transform.GetComponentInParent< ToggleGroup>().ActiveToggles();
        string[] name = new string[3];
        int n = 0;
        if (isOn)
        { 
        foreach (var toggle in toggleGroup)
        {
            if (toggle.isOn == true)
            {
                name[n]= toggle.gameObject.name;
                n++;
            }
        }

        switch (name[0])
        {
            case "Toggle1":
                    chose=1;
                break;
            case "Toggle2":
                    chose = 2; 
                break;
            case "Toggle3":
                    chose = 3;
                    break;
            default:
                break;
        }
        }
        return chose;
    }
    public void rand_Onclick()
    {
        int worldsize;
        int resamount;
        int forestamount;

        worldsize = OnValueChanged(table_worldset.transform.FindChild("set_1").gameObject, true);
        resamount = OnValueChanged(table_worldset.transform.FindChild("set_2").gameObject, true);
        forestamount = OnValueChanged(table_worldset.transform.FindChild("set_3").gameObject, true);

    }
}
