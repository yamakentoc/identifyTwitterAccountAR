using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

public class GetUser : MonoBehaviour {
    //PCのwifiとスマホのwifiを同じにする
    //PCのwifiのIPv4アドレスをhttp://      :8080に入れる
    //IPAddress.Parse(Network.player.ipAddress);
    private string url = "http://localhost:8080/はこだて未来";
    [SerializeField] GameObject circleController;

    void Start() {
        //string ipv4 = IPManager.GetIP(ADDRESSFAM.IPv4);
        //url = "http://" + ipv4 + ":8080";
        //Debug.Log(url);
        url = "http://192.168.10.114:8080/はこだて未来";
        StartCoroutine(GetUserData());


        //デバッぐ
        //IdentifiedUsers identifiedUsers = new IdentifiedUsers();
        //circleController.GetComponent<Circlecontroller>().ShowIcon();
        //デバッグ
    }

    private IEnumerator GetUserData() {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError) {
            Debug.Log("エラー: " + request.error);
        } else {
            Debug.Log("ステータスコード: " + request.responseCode);
            var identifiedUsers = JsonUtility.FromJson<IdentifiedUsers>(request.downloadHandler.text);
            //foreach(User user in identifiedUsers.users) {
            //    Debug.Log("userName: " + user.name + ", Relevance: " + user.relevance + ", URL: " + user.profile_image_url);
            //}
            circleController.GetComponent<Circlecontroller>().ShowIcon(identifiedUsers);
        }
    }
}