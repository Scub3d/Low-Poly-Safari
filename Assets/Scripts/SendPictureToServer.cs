using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net;
using System.Text;

public class SendPictureToServer : MonoBehaviour {


    public GameObject selectedPicture;

    public void breakShit() {
        if(selectedPicture != null)
        {
            Texture2D texmex = selectedPicture.GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
            byte[] bytes = texmex.EncodeToPNG();
            string b64 = Convert.ToBase64String(bytes);

            string url = "http://scub3d.net:7788/addImage";
      
            WebClient myWebClient = new WebClient();

            myWebClient.Encoding = Encoding.UTF8;
            myWebClient.Headers.Add("Content-Type", "text/json");
            string responsebody = myWebClient.UploadString(url, "POST", "{\"base64\":\"" + b64 + "\"}");

            hideAll();

        }

    }

    void Start()
    {

    }

    public void hideAll()
    {
        GameObject.Find("PictureHolder").active = false;
        GameObject.Find("thankyoutext").GetComponent<MeshRenderer>().enabled = true;
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
