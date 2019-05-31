using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UserIcon : MonoBehaviour {
    [HideInInspector]public User user;

    public void SetUser(User user) {
        this.user = user;
        StartCoroutine(GetIconTexture());
    }

    private IEnumerator GetIconTexture() {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(user.profile_image_url);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError) {
            Debug.Log("エラー: " + www.error);
        } else {
            Texture texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            GetComponent<Renderer>().material.mainTexture = texture;
        }
    }

    public void Hit() {
        Debug.Log("名前 :" + user.name);
        Text canvasText = GameObject.Find("Text").GetComponent<Text>();
        canvasText.text = "名前: " + user.name + "(@" + user.screen_name + ")" + "\n" + user.description + "\n関連度" + (int)user.relevance + "%";
    }
}
