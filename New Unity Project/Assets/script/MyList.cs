using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyList : MonoBehaviour
{
    //public
    public GameObject originObject;
    public Transform parentTransForm;

    /// <summary>
    /// 克隆一个GameObject
    /// </summary>
    public void Click()
    {
        GameObject.Instantiate(originObject, parentTransForm);
    }
}