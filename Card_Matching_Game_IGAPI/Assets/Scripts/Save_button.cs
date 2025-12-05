using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Save_button : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{

    private int current_cards_number;
    private GameObject card_parent;
    public void OnPointerDown(PointerEventData eventData)
    {
        card_parent = GameObject.Find("Cards_parent");
        int save_number =PlayerPrefs.GetInt("Save_number");
        PlayerPrefs.SetInt("Save_number", save_number+ 1);
        current_cards_number=card_parent.transform.childCount;
        PlayerPrefs.SetInt("card_numbers"+save_number.ToString(), current_cards_number);
        PlayerPrefs.SetInt("Current_Score"+ save_number.ToString(),Gameplay_manager.score);
        PlayerPrefs.SetInt("Turn" + save_number.ToString(), Gameplay_manager.Turn);
        PlayerPrefs.SetInt("Row" + save_number.ToString(), 
        GameObject.Find("Positions_Arranger").GetComponent<Positions_Arranger>().Rows);
        PlayerPrefs.SetInt("Column" + save_number.ToString(),
        GameObject.Find("Positions_Arranger").GetComponent<Positions_Arranger>().Columns);
        for (int i = 0; i < current_cards_number; i++)
        {

            if (card_parent.transform.GetChild(i).GetComponent<Card_Behaviour>().state 
                != Card_Behaviour.states.done)
            {


                PlayerPrefs.SetInt("card_index" + save_number.ToString() + i.ToString(),
                    card_parent.transform.GetChild(i).GetComponent<Card_Behaviour>().Card_index);

                PlayerPrefs.SetInt("card_pos" + save_number.ToString() + i.ToString(),
                   card_parent.transform.GetChild(i).GetComponent<Card_Behaviour>().pos_ind);


            }


        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {



    }

    // Start is called before the first frame update

    

    // Update is called once per frame
    
}
