using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class SD_Map
{
    /// </summary>
    public List<Config_Map> map { get; set; }
    //list转为字典类型
    public static Dictionary<string, Config_Map> Map_dic(List<Config_Map> list)
    {
        Dictionary<string, Config_Map> dic;
        dic = list.ToDictionary(key => key.id.ToString(), value => value);
        return dic;
    }
}


public class Config_Map
{
    /// <summary>
    /// 
    /// </summary>
    public int id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int type { get; set; }
    /// <summary>
    /// 空地
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string pic { get; set; }

    public int weight { get; set; }
}

