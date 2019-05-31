using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Circlecontroller : MonoBehaviour {

    [Header("分布")]
    [SerializeField] Transform CenterPosition;  // 中心オブジェクト
    private float ArrangementMaxRedius;         // 配置位置の最大半径
    private float ArrangementMinRedius;         // 配置位置の最小半径
    private float ArrangementHeight = 3.0f;     // 配置位置の高さ

    [Header("個数")]
    [SerializeField] GameObject userIconPrefab;   // 配置するオブジェクト
    //private int userLength = 1300;                 // 配置位置の最大

    private double maxR;
    private double minR;
    private GameObject[] userIconRange;

    private void Start() {
       
    }

    public void ShowIcon(IdentifiedUsers identifiedUsers) {
        identifiedUsers.users.Sort((a, b) => (int)(b.relevance - a.relevance));

        //デバッグ
        //User user = new User { name = "hoge", id = 1, profile_image_url = "url", relevance = 100 };
        //userIconRange = new GameObject[userLength];
        //for (int i = 0; i < userIconRange.Length; i++) {
        //    if (i >= 210 & i < 420) { user.relevance = 80; }
        //    if (i >= 420 & i < 630) { user.relevance = 60; }
        //    if (i >= 630 & i < 840) { user.relevance = 40; }
        //    if (i >= 840 & i < 1050) { user.relevance = 20; }
        //    if (i >= 1050) { user.relevance = 12; }
        //    StartCoroutine(ShowIconCoroutine(userIconRange[i], user));
        //}

        userIconRange = new GameObject[identifiedUsers.users.Count];
        for (int i = 0; i < userIconRange.Length; i++) {
            ShowIconCoroutine(userIconRange[i], identifiedUsers.users[i]);
        }
    }

    private void ShowIconCoroutine(GameObject userIconObject, User user) {
        /*
         * Relavance(関連度)が100%なら、ArrangementMinRedius(配置位置の最小半径)が1m。
         * 99%以下80%以上なら2m
         * 79%以下60%以上なら3m...        
         */       
        ArrangementMinRedius = 6 - ((int)user.relevance / 20);
        ArrangementMaxRedius = ArrangementMinRedius + 1;
        maxR = Math.Pow(ArrangementMaxRedius, 2);
        minR = Math.Pow(ArrangementMinRedius, 2);

        while (userIconObject == null) {
            float x = UnityEngine.Random.Range(-ArrangementMaxRedius, ArrangementMaxRedius);
            float z = UnityEngine.Random.Range(-ArrangementMaxRedius, ArrangementMaxRedius);
            double xAbs = Math.Abs(Math.Pow(x, 2));
            double zAbs = Math.Abs(Math.Pow(z, 2));

            // 特定の範囲内か確認
            if (maxR > xAbs + zAbs && xAbs + zAbs > minR) {
                float y = UnityEngine.Random.Range(-ArrangementHeight, ArrangementHeight);
                GameObject userIcon = Instantiate(userIconPrefab, // 個体のオブジェクト
                                                   (new Vector3(x, y, z)) + CenterPosition.position, // 初期座標
                                                   Quaternion.identity); // 回転位置
                userIcon.transform.LookAt(this.CenterPosition.position);
                userIcon.GetComponent<UserIcon>().SetUser(user);
                userIconObject = userIcon;
            }
        }
    }
}
