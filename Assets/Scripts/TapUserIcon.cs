using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class TapUserIcon : MonoBehaviour {
    
    void Update() {
        TouchDown();
    }

    private void TouchDown() {
        //if (0 < Input.touchCount) {
        //    Touch t = Input.GetTouch(0);
        //    if (t.phase == TouchPhase.Began) {
        //        Ray ray = Camera.main.ScreenPointToRay(t.position);
        //        RaycastHit hit = new RaycastHit();
        //        if (Physics.Raycast(ray, out hit)) {
        //            if (hit.transform.gameObject.CompareTag("UserIcon")) {
        //                hit.transform.gameObject.GetComponent<UserIcon>().Hit();
        //            }
        //        }
        //    }
        //}

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                Debug.Log("ひや");
                hit.transform.gameObject.GetComponent<UserIcon>().Hit();
            }
        }

    }

}
