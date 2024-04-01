using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(GetRequest("https://joytas.net/php/man.jpg")); 
    }

    IEnumerator GetRequest(string uri){
        using(UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(uri)){
            yield return uwr.SendWebRequest();
            if(uwr.result != UnityWebRequest.Result.Success){
                Debug.Log(uwr.error);
            }else{
                Texture texture = DownloadHandlerTexture.GetContent(uwr);
                Sprite sp = Sprite.Create(
                    (Texture2D)texture,
                    new Rect(0,0,texture.width,texture.height),
                    new Vector2(0.5f,0.5f)
                );
                Image image = GetComponent<Image>();
                image.preserveAspect=true;

                image.rectTransform.sizeDelta =new Vector2(
                    sp.rect.width,
                    sp.rect.height
                );
                image.sprite=sp;
            }
                
        }
    }

}
