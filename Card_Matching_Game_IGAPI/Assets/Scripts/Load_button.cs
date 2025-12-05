using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Load_button : MonoBehaviour,IPointerDownHandler,IPointerExitHandler
{
    public int Index;

    public void OnPointerDown(PointerEventData eventData)
    {

        int card_numbers = PlayerPrefs.GetInt("card_numbers" +Index.ToString());
        GameObject the_deck = GameObject.Find("The_Deck");
       GameObject Deck_Creator= GameObject.Find("Deck_Creator");
        Deck_Creator.GetComponent<Deck_Creator>().Cards_indexes.Clear();
        GameObject.Find("Positions_Arranger").GetComponent<Positions_Arranger>().Rows=
        PlayerPrefs.GetInt("Row" + Index.ToString());
        GameObject.Find("Texts_parent").transform.GetChild(0).GetComponent<TextMeshPro>().text=
             GameObject.Find("Positions_Arranger").GetComponent<Positions_Arranger>().Rows.ToString();

        GameObject.Find("Texts_parent").transform.GetChild(0).GetComponent<TextMeshPro>().text =
             GameObject.Find("Positions_Arranger").GetComponent<Positions_Arranger>().Columns.ToString();
        GameObject.Find("Positions_Arranger").GetComponent<Positions_Arranger>().Columns=
        PlayerPrefs.GetInt("Column" + Index.ToString());
        for (int i = 0; i < the_deck.transform.childCount; i++)
        {
            if (i<card_numbers) {
                the_deck.transform.GetChild(i).GetComponent<Card_Behaviour>().Card_index =
                     PlayerPrefs.GetInt("card_index" +Index.ToString() + i.ToString());
                Deck_Creator.GetComponent<Deck_Creator>().Cards_indexes.Add(PlayerPrefs.GetInt("card_index" + Index.ToString() + i.ToString()));
                the_deck.transform.GetChild(i).GetComponent<Card_Behaviour>().pos_ind =
                     PlayerPrefs.GetInt("card_pos" + Index.ToString() + i.ToString());
            }
            else
            {

                the_deck.transform.GetChild(i).gameObject.SetActive(false);

            }

        }
        Gameplay_manager.load=true;
        GameObject.Find("Game_manager").GetComponent<Gameplay_manager>().state =
            Gameplay_manager.states.Prepare_state;
        GameObject.Find("Canvas").transform.GetChild(0).GetChild(1).gameObject.SetActive(false);


    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {

        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Save "+Index.ToString();


    }

    // Update is called once per frame
   
}
