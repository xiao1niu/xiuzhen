using UnityEngine;
using LitJson;
using System.Collections.Generic;

public static class JsonReader
{

    //读取json数据，根据id查找（表格里的第一行），返回id和类对象互相对应的字典。
    public static T ReadJson<T>(string fileName)
    {
        TextAsset jsonData = Resources.Load(fileName) as TextAsset;
        if (jsonData.text == null) {
            Debug.Log("根据路径未找到对应表格数据");
            // return null;
            return default ( T );
        }
        else{
            T obj = JsonMapper.ToObject<T>(jsonData.text);
            return obj;
        }

    }

    //写入json数据，传入类类型变量。
    public static void WriteJson(string path, object jsonData)
    {
        JsonMapper.ToJson(jsonData);
    }
}
/**
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
       */
