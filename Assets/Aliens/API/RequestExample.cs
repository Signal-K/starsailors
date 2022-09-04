using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RequestExample : MonoBehaviour {
    void Start() {
        StartCoroutine(GetRequest("http://localhost:5000/planets"));
    }

    IEnumerator GetRequest(string uri) {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri)) {
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError) {
                Debug.Log("Network error: " + webRequest.error);
            } else {
                Debug.Log(webRequest.downloadHandler.text);
            }
        }
    }

    IEnumerator PostCtrl() {
        WWWForm form = new WWWForm();
        //form.AddField("appKey", "ABC"); Header
        form.AddField("Content-Type", "application/json");

        using (UnityWebRequest www = UnityWebRequest.Post("www.link.com", form)) {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError) {
                Debug.Log(www.error);
            } else {
                Debug.Log("Post Request Complete!");
            }
        }
    }
}