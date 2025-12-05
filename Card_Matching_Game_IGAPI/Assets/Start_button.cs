using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Start_button : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject related_text;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        int ttl = Positions_Arranger.total_numb;

        if (ttl < 40&&
             GameObject.Find("Game_manager").GetComponent<Gameplay_manager>().state ==
                Gameplay_manager.states.Menu_State&&ttl%2==0)
        {

            transform.GetComponent<AudioSource>().Play();
            Gameplay_manager.load=false;
            GameObject.Find("Game_manager").GetComponent<Gameplay_manager>().state =
                Gameplay_manager.states.Prepare_state;


        }
        else
        {
            if (ttl > 40)
            {

                related_text.GetComponent<TextMeshPro>().text = "The total number is too large";
            }
            if (ttl % 2 != 0)
            {
                related_text.GetComponent<TextMeshPro>().text = "The total number must be even";
            }



        }


    }
}
