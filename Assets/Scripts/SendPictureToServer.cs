using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class SendPictureToServer : MonoBehaviour {


    public GameObject selectedPicture;

    public void breakShit() {

        Texture2D texmex = selectedPicture.GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
        byte[] bytes = texmex.EncodeToPNG();
        string b64 = Convert.ToBase64String(bytes);

        string url = "http://scub3d.net:7788/addImage";
        WWWForm form = new WWWForm();
        form.AddField("b64", b64);
        WWW www = new WWW(url, form);
        Debug.Log(b64);
        StartCoroutine(WaitForRequest(www));
          
      }

    void Start()
    {

    }


    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.data);
        }
        else {
            Debug.Log("WWW Error: " + www.error);
        }
    }

}
