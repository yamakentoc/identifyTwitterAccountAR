using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circlecontroller : MonoBehaviour {

    [Header("分布")]
    [SerializeField] Transform CenterPosition;                 // 対象オブジェクト
    private int ArrangementMaxRedius = 1000;         // 配置位置の最大半径
    private int ArrangementMinRedius = 500;         // 配置位置の最小半径
    private int ArrangementHeight = 4;              // 配置位置の高さ

    [Header("個数")]
    [SerializeField] GameObject CreaturePrefab;                 // 対象オブジェクト
    [SerializeField] int CreatureLength = 100;                 // 配置位置の最大

    void Start() {
        GameObject[] CreatureRange = new GameObject[CreatureLength];
        double maxR = Math.Pow(ArrangementMaxRedius, 2);
        double minR = Math.Pow(ArrangementMinRedius, 2);
        for (int i = 0; i < CreatureRange.Length; i++) {
            while (CreatureRange[i] == null) {
                int x = UnityEngine.Random.Range(-ArrangementMaxRedius, ArrangementMaxRedius);
                int z = UnityEngine.Random.Range(-ArrangementMaxRedius, ArrangementMaxRedius);

                double xAbs = Math.Abs(Math.Pow(x, 2));
                double zAbs = Math.Abs(Math.Pow(z, 2));

                // 特定の範囲内化確認
                if (maxR > xAbs + zAbs && xAbs + zAbs > minR) {
                    int y = UnityEngine.Random.Range(-2, ArrangementHeight);
                    GameObject go = Instantiate(
                        CreaturePrefab, // 個体のオブジェクト
                        (new Vector3(x, y, z)) + CenterPosition.position, // 初期座標
                        Quaternion.identity // 回転位置
                    );
                    CreatureRange[i] = go;
                }
            }
        }
    }
}