using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
//用于处理角色数据相关
public class playerdata : MonoBehaviour {
    public static int[] p_shuxing = new int[6];
    public static int[] p_wuxing = new int[5];
    public static string p_name = "";
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static void Randshuxing()
    {
        for (int i = 0; i < 6; i++)
        {
            p_shuxing[i] = GetNum(3, 0, 7, 1);
        }
        for (int i = 0; i < 5; i++)
        {
            p_wuxing[i] = GetNum(3, 0, 7, 5);
        }
  
    }
    public static int GetNum(int num, int minValue, int maxValue, int mul)
    {
        int n = 0;
        int tmp = 0;
        int randnum = 0;
        int tmp0;
        System.Random ra;
        while (n < num)
        {
            ra = new System.Random(unchecked((int)DateTime.Now.Ticks) * 7);
            randnum = ra.Next(minValue, maxValue);
            tmp = tmp + randnum;
            n = n + 1;
            Debug.Log(n + "-----tmp:" + tmp + ",randnum:" + randnum);
        }
        tmp0 = tmp * mul;
        Debug.Log("-----tmp0-----" + tmp0);
        return tmp0;
    }
    [System.Serializable]
    public class Save
    {
        public List<int> psave_shuxing = new List<int>();
        public List<int> psave_wuxing = new List<int>();

        public string name = "";
    }
    public static Save Palyerdata_save()
    {
        Save save = new Save();
        save.name = p_name;
        save.psave_shuxing = p_shuxing.ToList();
        save.psave_wuxing = p_wuxing.ToList();
        return save;
    }
    public static void Savepalyer()
    {
        Save save = Palyerdata_save();

        // 2
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/save/"+save.name+ ".txt");
        string json=JsonUtility.ToJson(save);
        bf.Serialize(file, json);
        file.Close();
        Debug.Log("Saving as JSON: " + json);
       // Debug.Log("Game Saved "+ save.name);
    }

}
