using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNetworkHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [ContextMenu("TestGet")]
    public async void TestGet()
    {
        HttpClient httpClient = new HttpClient(new JsonSerializationOption());
        var result = await httpClient.GetRequest<BaseResponseData>("https://api.pkplentertainment.com/api/users");
        Debug.Log(result.userId);
    }
}
