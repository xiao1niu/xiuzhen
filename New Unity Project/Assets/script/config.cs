using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class config 
{

}
public class SD_Roledata_d
{
    //静态保存表格数据的字典,填写当前表格的文件路径,格式如："Json/Document/Force"，无须带后缀。
    //public static Dictionary<string, Config_Roledata> Role_Dic = JsonReader.ReadJson<Config_Roledata>("config/roledata");
    public Dictionary<int, Config_Roledata> Config_Roledata { get; set; }
}