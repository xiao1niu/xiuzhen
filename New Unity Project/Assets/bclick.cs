using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bclick : MonoBehaviour
{
    public GameObject originObject;
    public Transform parentTransForm;

    /// <summary>
    /// 克隆一个GameObject
    /// </summary>
    public void InstantiateList()
    {
        GameObject.Instantiate(originObject, parentTransForm);
    }
    public void onclick()
    {
        InstantiateList();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
