using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using UnityEngine.EventSystems;

public class TapUserIcon : MonoBehaviour {

    private User showingUser;

    void Update() {
        TouchDown();
    }

    private void TouchDown() {
        //if (0 < Input.touchCount) {
        //    Touch t = Input.GetTouch(0);
        //    if (EventSystem.current.IsPointerOverGameObject(t.fingerId)) {
        //        return;
        //    }
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
            if (EventSystem.current.IsPointerOverGameObject()) {
                return;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                Debug.Log("ひや");
                hit.transform.gameObject.GetComponent<UserIcon>().Hit();
                showingUser = hit.transform.gameObject.GetComponent<UserIcon>().user;
            }
        }
    }

    public void TapButton() {
        string url = "https://twitter.com/" + showingUser.screen_name;
        Application.OpenURL(url);
    }

}
