using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public static class Configinit
{
    public static Dictionary<int, Config_Roledata> Config_Roledata { get; set; }
    public static Dictionary<string, Roledata_type> Config_Roledata_type { get; set; }
    //public string Configtext { get; set; }
    static Configinit()
    {

        Config_Roledata = SD_Roledata.Gameinfo_dic(JsonReader.ReadJson<SD_Roledata>("config/roledata").roledata);
        Config_Roledata_type= SD_Roledata.Roledata_type_dic(JsonReader.ReadJson<SD_Roledata>("config/roledata").roledata_type);
        /*
        foreach (var info in Config_Roledata)
        {
            Debug.Log(info.Key + " " + info.Value.roledata_name);
        }
        */
        //的Debug.Log(Config_Roledata[103].roledata_name);
    }
}

