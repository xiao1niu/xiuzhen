using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[Serializable]
public class BaseState
{
    public int _baseValue;
    public int _grown;
    public int _max_baseValue;
    public Attribute _name;




    public BaseState(int _baseValue, int _grown, Attribute _name, int _max_baseValue)
    {
        this._baseValue = _baseValue;
        this._grown = _grown;
        this._name = _name;
        this._max_baseValue = _max_baseValue;
    }
    //调整接口如下
}
public enum Attribute
{
    Might,
    Constitution
}

