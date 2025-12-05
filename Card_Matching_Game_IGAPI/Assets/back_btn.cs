using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class back_btn : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update

    public void OnPointerDown(PointerEventData eventData)
    {
        Camera.main.transform.GetComponent<Animator>().SetBool("Load", false);
        GameObject.Find("Canvas").transform.GetChild(0).GetChild(1).gameObject.SetActive(false);

    }
}
