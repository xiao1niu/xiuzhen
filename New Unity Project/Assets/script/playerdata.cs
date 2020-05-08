using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using static playerdata;
using static Config_Roledata;
using Newtonsoft.Json;
using System.Web.Script.Serialization;  //引用序列化类库
//用于处理角色数据相关

public class playerdata : MonoBehaviour {
    public struct shuxing
    {
        public int STR;//力量
        public int DEX;//灵巧
        public int AGI; //敏捷
        public int VIT; //耐力
        public int WIS; //智力
        public int CON; //体质
        public int PER;//感知
        public int PSY;//精神
        public int WIL;//意志
        public int CHA;//魅力
        public int FUYUAN; //福缘 隐藏
        public int HUIGEN; //慧根 隐藏
        public int GENGU; //根骨 隐藏
    }
    public struct skill_work
    {
        public int gengzuo;//耕作
        public int chuyi;//厨艺
        public int tansuo;//探索
        public int shengcun;//生存 
        public int fengren;//缝纫 需要训练
        public int duanzao;//锻造 需要训练
        public int mugong;//木工 需要训练
        public int shigong;//石工 需要训练
        public int yiyao;//医药 需要训练
        public int jianzhu;//建筑 需要训练
        public int yuanyi;//园艺 需要训练

    }
    public struct skill_culture
    {
        public int danqing;//丹青 需要训练
        public int shishu;//诗书 需要训练
        public int yinlv;//音律 需要训练
        public int shushu;//术数 需要训练
        public int yiqi;//弈棋 需要训练
        public int daofa;//道法 需要训练
        public int fofa;//佛学 需要训练
        public int zaxue;//杂学 需要训练
        public int chayi;//茶艺 需要训练

    }
    public struct skill_fight
    {
        public int jianfa;//剑法 需要训练
        public int daofa;//刀法 需要训练
        public int anqi;//暗器 需要训练
        public int changbing;//长兵 需要训练
        public int duanbing;//短兵 需要训练
        public int roubo;//肉搏 需要训练
        public int jianshu;//箭术 需要训练
        public int shenfa;//身法 需要训练
        public int qimen;//奇门 需要训练
        public int qishu;//骑术 需要训练
        public int qinggong;//轻功 需要训练
        public int neigong;//内功 需要训练

    }
    public struct roledata
    {
        public float hp_cur;//当前生命
        public float ki_cur;//当前生命
        public float energy_cur;//当前生命
        public float hp_max;//最大生命
        public float ki_max;//最大生命
        public float energy_max;//最大生命
        public float hp_injured;//受伤生命
        public float[] shuxing_cur;
        public float[] shuxing_basis;
        public float[] skill_work_cur;
        public float[] skill_work_basis ;
        public float[] skill_culture_cur ;
        public float[] skill_culture_basis ;
        public float[] skill_fight_cur ;
        public float[] skill_fight_basis ;


        //public skill_culture skill_culture_cur;
        //public skill_culture skill_culture_basis;
        //public skill_fight skill_fight_cur;
        //public skill_fight skill_fight_basis;
    }
    //public static int[] p_shuxing = new int[6];
    //public static int[] p_wuxing = new int[5];
    public static string p_name ;
    public static string f_name ;
    public static roledata roledatainfo;
    // Use this for initialization
    void Start() {

    }

// Update is called once per frame
    void Update() {

    }
   
    public static roledata roledata_init(roledata roledatainfo)  
    {

        roledatainfo.hp_max = 100;//最大生命
        roledatainfo.ki_max = 100;//最大生命
        roledatainfo.energy_max=100;//最大生命
        roledatainfo.hp_injured=0;//受伤生命
        roledatainfo.hp_cur= roledatainfo.hp_max;//当前生命
        roledatainfo.ki_cur= roledatainfo.ki_max;//当前生命
        roledatainfo.energy_cur= roledatainfo.energy_max;//当前生命
        roledatainfo = data_init("shuxing", roledatainfo);
        roledatainfo.shuxing_cur=roledatainfo.shuxing_basis;
        roledatainfo = data_init("skill_work", roledatainfo);
        roledatainfo.skill_work_cur = roledatainfo.skill_work_basis;
        roledatainfo= data_init("skill_culture", roledatainfo);
        roledatainfo.skill_culture_cur = roledatainfo.skill_culture_basis;
        roledatainfo= data_init("skill_fight", roledatainfo);
        roledatainfo.skill_fight_cur = roledatainfo.skill_fight_basis;
        return roledatainfo;
    }
    public static roledata data_init(string type, roledata roledatainfo)
    {
        switch(type){
            case "shuxing":
                float[] shuxing = new float[13];
                //int[] attributie_hide = new int[5];
                //随机基础属性

                shuxing = GetNum(2, 1, 6, 10, shuxing);

                for (int i = 10; i < 13; i = i + 1)
                {
                    shuxing[i] = 0;
                }
                roledatainfo.shuxing_basis = shuxing;
                break;
            case "skill_work":
                float[] skill_work = new float[11];
                skill_work = GetNum(2, 1, 10, 4, skill_work);
                for (int i = 4; i < 11; i = i + 1)
                {
                    skill_work[i] = 0;
                }
                roledatainfo.skill_work_basis = skill_work;
                break;
            case "skill_culture":
                float[] skill_culture = new float[9];
                for (int i = 0; i < 9; i = i + 1)
                {
                    skill_culture[i] = 0;
                }
                roledatainfo.skill_culture_basis = skill_culture;
                break;
            case "skill_fight":
                float[] skill_fight = new float[12];

                for (int i = 0; i < 12; i = i + 1)
                {
                    skill_fight[i] = 0;
                }
                roledatainfo.skill_fight_basis = skill_fight;
                break;
                
        }
        Loadconfig();
        return roledatainfo;

    }


    //返回随机值，随机次数：num，随机范围： [minValue,maxValue]，放大系数
    public static float[] GetNum(int num, int minValue, int maxValue,int arrnum,float[] arr)
    {
        int n = 0;
        int i = 0;
        float tmp = 0;
        float randnum = 0;
        System.Random ra;
        System.Random rand;
        ra = new System.Random(unchecked((int)DateTime.Now.Ticks) * 7);
        while (i < arrnum)
        {
            tmp = 0;
            n = 0;
            rand = new System.Random(ra.Next(0, 100));
            while (n < num)
            {

                randnum = rand.Next(minValue, maxValue + 1);
                Debug.Log("rand：" + randnum);
                tmp = tmp + randnum;
                n = n + 1;
            }
            arr[i] = tmp;
            i = i + 1;
        }
        return arr;
    }
    [System.Serializable]
    public class Save
    {
        public List<int> psave_shuxing = new List<int>();
        public List<int> psave_wuxing = new List<int>();
        public List<string> roledatainfo = new List<string>();

        public string name = "";
        public string filename = "";
        public string savetime = "";
         
    }
    //玩家人物数据结构

    public static Save Palyerdata_save()
    {
        Save save = new Save();
        save.name = p_name;
        save.filename = f_name;
        //save.psave_shuxing = p_shuxing.ToList();
        //save.psave_wuxing = p_wuxing.ToList();
        
        return save;
    }

    public static void Savepalyer()
    {
        Save save = Palyerdata_save();

        // 2
        BinaryFormatter bf = new BinaryFormatter();
        for (int n = 1; n < 4; n++)
        {
            if (!File.Exists(Application.dataPath + "/save/save0" + n + ".txt"))
            {
                save.filename = "save0" + n + ".txt";
                //Debug.Log(Application.dataPath + "文件名1: " + save.filename);
        FileStream file = File.Create(Application.dataPath + "/save/"+save.filename);
        string json=JsonUtility.ToJson(save);
        bf.Serialize(file, json);
        file.Close();
        //Debug.Log("Saving as JSON: " + json);
                // Debug.Log("Game Saved "+ save.name);
                break;
            }
        }
    }
    public static Save Loadplayer(string filePath)
    {

            if (File.Exists(filePath))
        {
            //Debug.Log(Application.dataPath + "读取存档: save0" +n);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);
            string json = (string)bf.Deserialize(file);
            file.Close();
            Save save = JsonUtility.FromJson<Save>(json);
            save.savetime = File.GetLastWriteTime(filePath).ToString();
            
            return save;
        }
        else
        {
            Debug.Log("存档:" + filePath + " 不存在");
            return null;
        }

    }
    public static void Loadconfig()
    {
        string filePath = Application.dataPath + "/config/roledata.json";
        var serializer = new JavaScriptSerializer();

        if (File.Exists(filePath))
        {
            //Debug.Log(Application.dataPath + "读取存档: save0" +n);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);
            string json = (string)bf.Deserialize(file);
            file.Close();
            string jsonline = serializer.Deserialize<string>(json);
            //Dictionary<int, Config_Roledata> dic2 = JsonConvert.DeserializeObject<Dictionary<int, Config_Roledata>>(json);

            /**
            foreach (var item in dic2)
            {
                Console.WriteLine($"{item.Key}---->{item.Value}");
            }
    */
            //Config_Roledata config_roledata = JsonUtility.FromJson<Config_Roledata>(json);
            Debug.Log(jsonline);
            //return config_roledata;

        }
        else
        {
            Debug.Log( filePath + " 不存在");
            //return null;
        }

    }

    public static string SerializeDictionaryToJsonString<TKey, TValue>(Dictionary<TKey, TValue> dict)
    {
        if (dict.Count == 0)
            return "";

        string jsonStr = JsonConvert.SerializeObject(dict);
        return jsonStr;
    }
    public static Dictionary<TKey, TValue> DeserializeStringToDictionary<TKey, TValue>(string jsonStr)
    {
        if (string.IsNullOrEmpty(jsonStr))
            return new Dictionary<TKey, TValue>();

        Dictionary<TKey, TValue> jsonDict = JsonConvert.DeserializeObject<Dictionary<TKey, TValue>>(jsonStr);

        return jsonDict;

    }
}

