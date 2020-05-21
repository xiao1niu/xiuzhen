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
    public List<Config_Roledata> roledata { get; set; }
    public List<Roledata_type> roledata_type { get; set; }

    //public Dictionary<string, Config_Roledata> roledata { get; set; }
    //public Dictionary<string, Roledata_type> roledata_type { get; set; }


    public static Dictionary<string,Config_Roledata> Roledata_dic(List<Config_Roledata> list)
    {
        Dictionary<string, Config_Roledata> dic;
        dic= list.ToDictionary(key => key.roledata_id.ToString(), value => value);
        return dic;
    }
    public static Dictionary<string, Roledata_type> Roledata_type_dic(List<Roledata_type> list)
    {
        Dictionary<string, Roledata_type> dic;
        dic = list.ToDictionary(key => key.roledata_type, value => value);
        return dic;
    }
}
/**
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
public class Roledata_type
{
    /// <summary>
    /// 
    /// </summary>
    public string roledata_type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int roledata_idrange { get; set; }
    public int roledata_idcount { get; set; }
}

