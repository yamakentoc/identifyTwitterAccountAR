using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetUser : MonoBehaviour {

    private string url = "http://localhost:8080";

    void Start() {
        //StartCoroutine(GetUserData());
    }
    
    void Update() {
        
    }

    private IEnumerator GetUserData() {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError) {
            Debug.Log("エラー: " + request.error);
        } else {
            Debug.Log("ステータスko-do: " + request.responseCode);
            var identifiedUsers = JsonUtility.FromJson<IdentifiedUsers>(request.downloadHandler.text);
            foreach(User user in identifiedUsers.users) {
                Debug.Log("userName: " + user.name + ", Relevance: " + user.relevance);
            }
        }
    }
}