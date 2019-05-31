using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UserIcon : MonoBehaviour {
    public User user;

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
}
