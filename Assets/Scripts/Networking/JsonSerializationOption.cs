using System;
using Newtonsoft.Json;
using UnityEngine;

public class JsonSerializationOption : ISerializeOption
{
    public T DeserializeObject<T>(string text)
    {
        try
        {
            T res = JsonConvert.DeserializeObject<T>(text);
            return res;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed in deserializing the object to json { ex.Message }");
            return default;
        }
    }
}
