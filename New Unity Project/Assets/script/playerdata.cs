using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using static playerdata;
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
        public shuxing shuxing_cur;
        public shuxing shuxing_basis;
        public skill_work skill_work_cur;
        public skill_work skill_work_basis;
        public skill_culture skill_culture_cur;
        public skill_culture skill_culture_basis;
        public skill_fight skill_fight_cur;
        public skill_fight skill_fight_basis;
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
        roledatainfo.shuxing_basis = shuxing_init(roledatainfo.shuxing_basis);
        roledatainfo.shuxing_cur=roledatainfo.shuxing_basis;
        roledatainfo.skill_work_basis=skill_work_init(roledatainfo.skill_work_basis);
        roledatainfo.skill_work_cur = roledatainfo.skill_work_basis;
        roledatainfo.skill_culture_basis=skill_culture_init(roledatainfo.skill_culture_basis);
        roledatainfo.skill_culture_cur = roledatainfo.skill_culture_basis;
        roledatainfo.skill_fight_basis=skill_fight_init(roledatainfo.skill_fight_basis);
        roledatainfo.skill_fight_cur = roledatainfo.skill_fight_basis;
        return roledatainfo;
    }
    public static shuxing shuxing_init(shuxing roledata)
    {
        int[] attributie_basis = new int[10];
        int[] attributie_hide = new int[5];
        //随机基础属性

            attributie_basis= GetNum(2, 1,6, 10, attributie_basis);

        //随机隐藏属性

            attributie_hide = GetNum(2, 0, 3, 5, attributie_hide);
        
        Debug.Log(attributie_basis[0]+","+ attributie_basis[2]+ "," + attributie_basis[3]+ "," + attributie_basis[4]);
            roledata.STR = attributie_basis[0];//力量
            Debug.Log("力量："+ roledata.STR);
            roledata.DEX = attributie_basis[1];//灵巧
            Debug.Log("灵巧：" + roledata.DEX);
        roledata.AGI = attributie_basis[2]; //敏捷
            roledata.VIT = attributie_basis[3]; //耐力
            roledata.WIS = attributie_basis[4]; //智力
            roledata.CON = attributie_basis[5]; //体质
            roledata.PER = attributie_basis[6];//感知
            roledata.PSY = attributie_basis[7];//精神
            roledata.WIL = attributie_basis[8];//意志HUIGEN
            roledata.CHA = attributie_basis[9];//魅力
            roledata.FUYUAN = attributie_hide[0]; //福缘
            roledata.HUIGEN = attributie_hide[1]; //慧根
            roledata.GENGU = attributie_hide[2]; //根骨
        return (roledata);
    }
    public static skill_work skill_work_init(skill_work roledata)
    {
        int[] attributie_basis = new int[4];
        //随机基础属性

            attributie_basis = GetNum(2, 1, 10,4, attributie_basis);
   
        //随机隐藏属性
        roledata.gengzuo = attributie_basis[0]; ;//耕作
        roledata.chuyi = attributie_basis[0]; ;//厨艺
        roledata.tansuo= attributie_basis[0];//探索
        roledata.shengcun= attributie_basis[0];//生存 
        roledata.fengren= 0;//缝纫 需要训练
        roledata.duanzao= 0;//锻造 需要训练
        roledata.mugong= 0;//木工 需要训练
        roledata.shigong= 0;//石工 需要训练
        roledata.yiyao= 0;//医药 需要训练
        roledata.jianzhu= 0;//建筑 需要训练
        roledata.yuanyi= 0;//园艺 需要训练
        return (roledata);
    }
    public static skill_culture skill_culture_init(skill_culture roledata)
    {
        roledata.danqing= 0;//丹青 需要训练
        roledata.shishu= 0;//诗书 需要训练
        roledata.yinlv= 0;//音律 需要训练
        roledata.shushu= 0;//术数 需要训练
        roledata.yiqi= 0;//弈棋 需要训练
        roledata.daofa= 0;//道法 需要训练
        roledata.fofa= 0;//佛学 需要训练
        roledata.zaxue= 0;//杂学 需要训练
        roledata.chayi= 0;//茶艺 需要训练
        return (roledata);
    }
    public static skill_fight skill_fight_init(skill_fight roledata)
    {
        roledata.jianfa= 0;//剑法 需要训练
        roledata.daofa= 0;//刀法 需要训练
        roledata.anqi= 0;//暗器 需要训练
        roledata.changbing= 0;//长兵 需要训练
        roledata.duanbing= 0;//短兵 需要训练
        roledata.roubo= 0;//肉搏 需要训练
        roledata.jianshu= 0;//箭术 需要训练
        roledata.shenfa= 0;//身法 需要训练
        roledata.qimen= 0;//奇门 需要训练
        roledata.qishu= 0;//骑术 需要训练
        roledata.qinggong= 0;//轻功 需要训练
        roledata.neigong= 0;//内功 需要训练
        return (roledata);
    }
    //返回随机值，随机次数：num，随机范围： [minValue,maxValue]，放大系数
    public static int[] GetNum(int num, int minValue, int maxValue,int arrnum,int[] arr)
    {
        int n = 0;
        int i = 0;
        int tmp = 0;
        int randnum = 0;
        System.Random ra;
        System.Random rand;
        ra = new System.Random(unchecked((int)DateTime.Now.Ticks) * 7);
        while (i < arrnum)
        {
            rand = new System.Random(ra.Next(0, 100));
            while (n < num)
            {

                randnum = rand.Next(minValue - 1, maxValue + 1);
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
}

