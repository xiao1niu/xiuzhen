using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class suijiclick : MonoBehaviour {
    void Start()
    {
        Debug.Log("Button Clicked. suiji");


    }
    public void OnClick()
    {
        GameObject.Find("Canvas/shuxing/prop_data_1").GetComponent<Text>().text = (Random.Range(1, 7)+ Random.Range(1, 7)+ Random.Range(1, 7)).ToString(); 
        GameObject.Find("Canvas/shuxing/prop_data_2").GetComponent<Text>().text = (Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7)).ToString();
        GameObject.Find("Canvas/shuxing/prop_data_3").GetComponent<Text>().text = (Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7)).ToString();
        GameObject.Find("Canvas/shuxing/prop_data_4").GetComponent<Text>().text = (Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7)).ToString();
        GameObject.Find("Canvas/shuxing/prop_data_5").GetComponent<Text>().text = (Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7)).ToString();
        GameObject.Find("Canvas/shuxing/prop_data_6").GetComponent<Text>().text = (Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7)).ToString();

        Debug.Log("随机属性");
        Debug.Log("Button Clicked. TestClick.01001");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
