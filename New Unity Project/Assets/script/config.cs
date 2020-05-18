using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
/*
public class Configfile 
{
    public Dictionary<int, Config_Roledata> Config_Roledata { get; set; }
    public string Configtext { get; set; }

}
*/
public class Configinit
{
    public Dictionary<int, Config_Roledata> Config_Roledata { get; set; }
    public string Configtext { get; set; }
    public Configinit()
    {
        //Configfile configdir = new Configfile();
        //configdir.Config_Roledata 
        //SD_Roledata SD_Roledata_obj = JsonReader.ReadJson<SD_Roledata>("config/roledata");
        Config_Roledata = SD_Roledata.Gameinfo_dic(JsonReader.ReadJson<SD_Roledata>("config/roledata").gameinfo);
        foreach (var info in Config_Roledata)
        {
            //Debug.Log(info.Key + " " + info.Value.roledata_name);
        }
        //Debug.Log(Config_Roledata[103].roledata_name);
    }
    /*
    public void init() {
        Configfile configdir = new Configfile();
        //configdir.Config_Roledata 
        //SD_Roledata SD_Roledata_obj = JsonReader.ReadJson<SD_Roledata>("config/roledata");
        configdir.Config_Roledata = SD_Roledata.Gameinfo_dic(JsonReader.ReadJson<SD_Roledata>("config/roledata").gameinfo);
        foreach (var info in configdir.Config_Roledata)
        {
            //Debug.Log(info.Key + " " + info.Value.roledata_name);
        }
        Debug.Log(configdir.Config_Roledata[103].roledata_name);
    }
    */


}