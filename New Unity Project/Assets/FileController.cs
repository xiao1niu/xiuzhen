using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		CSV.GetInstance().loadFile(Application.dataPath + "/Res", "myTest.csv");
        //Debug.Log("getString:" + CSV.GetInstance().getString(1, 1));
       // Debug.Log("getInt:" + CSV.GetInstance().getInt(1, 2));
        
        
 //       for(int i = 0; i < CSV.GetInstance().m_ArrayData.Count; i++)
 //       {
 //           Debug.Log(CSV.GetInstance().m_ArrayData[i]);
 //       }
	}

}
