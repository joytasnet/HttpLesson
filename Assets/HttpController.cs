using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HttpController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(GetRequest("https://joytas.net/php/hello.php")); 
    }

    IEnumerator GetRequest(string uri){
        using(UnityWebRequest uwr = UnityWebRequest.Get(uri)){
            yield return uwr.SendWebRequest();
            if(uwr.result != UnityWebRequest.Result.Success){
                Debug.Log(uwr.error);
            }else{
                Debug.Log(uwr.downloadHandler.text);
            }

        }
    }

}
