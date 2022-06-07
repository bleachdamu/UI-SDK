using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class HttpClient
{

    private readonly ISerializeOption serializeOption;

    private StringBuilder _stringBuilder;

    public HttpClient(ISerializeOption serializeOption)
    {
        this.serializeOption = serializeOption;
        _stringBuilder = new StringBuilder();
    }

    [ContextMenu("GetRequest")]
    public async Task<TResultType> GetRequest<TResultType>(string url)
    {
        try
        {
            using (var www = UnityWebRequest.Get(url))
            {
                www.SetRequestHeader("api-key", "1q5x7BR7ABP9");
                www.SetRequestHeader("Authorization", "");

                var operation = www.SendWebRequest();

                while (!operation.isDone)
                    await Task.Yield();

                var JsonResponse = www.downloadHandler.text;

                if (www.result != UnityWebRequest.Result.Success)
                    Debug.Log($"Failed{www.error}");

                var result = serializeOption.DeserializeObject<TResultType>(JsonResponse);
                return result;
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"{nameof(GetRequest)} failed : {ex.Message}");
            return default;
        }
    }

    private string CreateURL(Dictionary<string, string> parameters , string url)
    {
        _stringBuilder.Clear();
        _stringBuilder.AppendFormat("{0}{1}", url);
        _stringBuilder.Append('?');
        var v_keys = parameters.Keys;
        foreach (var v_key in v_keys)
        {
            _stringBuilder.AppendFormat("{0}={1}&", v_key, parameters[v_key]);
        }

        return _stringBuilder.ToString();
    }


    IEnumerator Put()
    {
        byte[] myData = System.Text.Encoding.UTF8.GetBytes("This is some test data");
        using (UnityWebRequest www = UnityWebRequest.Put("https://www.my-server.com/upload", myData))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Upload complete!");
            }
        }
    }

    IEnumerator Post()
    {
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        using (UnityWebRequest www = UnityWebRequest.Post("https://www.my-server.com/myform", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
