using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamedata_Map
{
    public string mapname { get; set; }
    /// </summary>
    public Dictionary<string, Mapunit> map { get; set; }
    //list转为字典类型
}
public class Mapunit
{
    /// <summary>
    /// 
    /// </summary>
    public int[] pos { get; set; }
    public int mapid { get; set; }
    public int mapdetail { get; set; }

    //public int type { get; set; }
    /// <summary>
    /// 空地
    /// </summary>

    //public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    //public string pic { get; set; }
}