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


    // Update is called once per frame
    void Update()
    {
        
    }
    void addtoggle (string title,int n)
    {
        GameObject table_worldset = Instantiate(prefab_unit_worldset);
        //Instantiate(prefab_savetip) as GameObject;
        table_worldset.transform.SetParent(table_worldset.transform);
        table_worldset.transform.localScale = new Vector3(1, 1, 1);
        table_worldset.transform.name = "set_"+n;
        table_worldset.transform.Find("unitname").GetComponent<Text>().text= title;
        GameObject unit_toggle = table_worldset.transform.Find("table_toggle/Toggle0").gameObject;
        string[] togglelist = setTogglelist("世界尺寸");
        foreach (var info in togglelist)
            {
            
        }
    }
    string[] setTogglelist(string title)
    {
        string[] toggle= { "1"};
        switch (title) { 
            case"世界尺寸":
                toggle = new string[] {"小","中", "大" };
                break;
            case "资源数量":
                toggle = new string[] { "少量", "一般", "大量" };
                break;
            case "森林范围":
                toggle = new string[] { "少量", "一般", "大量" };
                break;
        }
        return toggle;
    }
}
