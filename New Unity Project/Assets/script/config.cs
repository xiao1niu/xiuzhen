using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public static class Configinit
{
    public static Dictionary<string, Config_Roledata> Config_Roledata { get; set; }
    public static Dictionary<string, Roledata_type> Config_Roledata_type { get; set; }
    public static Dictionary<string, Config_Map> Config_Map { get; set; }
    //public string Configtext { get; set; }
    static Configinit()
    {
        //object obj= JsonReader.ReadJson<SD_Roledata>("config/roledata");
        Config_Roledata = SD_Roledata.Roledata_dic(JsonReader.ReadJson<SD_Roledata>("config/roledata").roledata);
        Config_Roledata_type= SD_Roledata.Roledata_type_dic(JsonReader.ReadJson<SD_Roledata>("config/roledata").roledata_type);
        Config_Map = SD_Map.Map_dic(JsonReader.ReadJson<SD_Map>("config/map").map);
        /*
        foreach (var info in Config_Map)
        {
            Debug.Log(info.Key + " " + info.Value.name);
        }
        
       */
        //的Debug.Log(Config_Roledata[103].roledata_name);
    }
}

