using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/**
public class SD_Roledata
{
    //静态保存表格数据的字典,填写当前表格的文件路径,格式如："Json/Document/Force"，无须带后缀。
    //public static Dictionary<string, Config_Roledata> Role_Dic = JsonReader.ReadJson<Config_Roledata>("config/roledata");
    public List<Config_Roledata> gameinfo { get; set; }
}
    */

public class SD_Roledata
{
    //静态保存表格数据的字典,填写当前表格的文件路径,格式如："Json/Document/Force"，无须带后缀。
    //public static Dictionary<string, Config_Roledata> Role_Dic = JsonReader.ReadJson<Config_Roledata>("config/roledata");
    public List<Config_Roledata> gameinfo { get; set; }
    public Dictionary<int, Config_Roledata> gameinfo_dic { get; set; }


    public static Dictionary<int,Config_Roledata> Gameinfo_dic(List<Config_Roledata> gameinfo)
    {
        Dictionary<int, Config_Roledata> dic;
        dic= gameinfo.ToDictionary(key => key.roledata_id, value => value);
        return dic;
    }
}
/**
public class SD_Roledata_d
{
    //静态保存表格数据的字典,填写当前表格的文件路径,格式如："Json/Document/Force"，无须带后缀。
    //public static Dictionary<string, Config_Roledata> Role_Dic = JsonReader.ReadJson<Config_Roledata>("config/roledata");
    public Dictionary<int, Config_Roledata> Config_Roledata_d { get; set; }
}
*/
public class Config_Roledata 
{
    /// <summary>
    /// 
    /// </summary>
    public int roledata_id{ get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string roledata_type{ get; set; }
    /// <summary>
    /// 敏捷
    /// </summary>
    public string roledata_name{ get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string inittype{ get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int ishide{ get; set; }

    
}

