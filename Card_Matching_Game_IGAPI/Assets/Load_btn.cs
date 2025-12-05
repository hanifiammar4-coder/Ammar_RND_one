using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_btn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject loading_UI;
    public GameObject panel;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        GameObject.Find("Canvas").transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        for (int i = 0; i < PlayerPrefs.GetInt("Save_number"); i++)
        {


          GameObject uii=(GameObject)Instantiate(loading_UI, loading_UI.transform.position,
                loading_UI.transform.rotation, panel.transform);

            uii.transform.GetComponent<Load_button>().Index = i;



        }

        Camera.main.transform.GetComponent<Animator>().SetBool("Load", true);
        transform.GetComponent<AudioSource>().Play();


    }
}
