using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gameplay_manager : MonoBehaviour
{
    // Start is called before the first frame update
    public enum states {Menu_State,First_state,Shuffle, Distribute,reveal_cards,Play};
    public states state;
    private delegate void deg();
    private deg mydeg;
    private float timer;
    public GameObject Deck;
    public GameObject Position_Arranger;
    public static GameObject card_1, card_2;
    public static int score;
    void Start()
    {
        
        timer=Mathf.Infinity;


    }

    // Update is called once per frame
    void Update()
    {
        // Timer to run the code inside the delegate if needed
        if (timer > 0)
        {

            timer-=Time.deltaTime;

        }
        else
        {

            mydeg();

        }
        
        switch (state)
        {

            //The First state of the gameplay
            case states.First_state:




             break;
                // Shuffle the Deck
            case states.Shuffle:




            break;
            // Distribute the Cards
            case states.Distribute:
                if (timer == Mathf.Infinity)
                {
                    timer = 0.5f;
                }
                mydeg = () =>
                {
                    // Check if the card is active and send it to the assigned position
                    if(Deck.transform.GetChild(0).gameObject.activeSelf == true)
                    {

                        Deck.transform.GetChild(0).GetComponent<Card_Behaviour>().Act_();
                        timer = 0.15f;


                    }
                    else
                    {

                        timer = Mathf.Infinity;
                        state = states.Play;
                    }


                };



                break;
            // Reveal the cards for few seconds
            case states.reveal_cards:









            break;


                // the state of playing the Game
            case states.Play:

                if (card_1 != null && card_2 != null)
                {
                    int indd =card_1.GetComponent<Card_Behaviour>().Card_index;
                    int indd_2 = card_2.GetComponent<Card_Behaviour>().Card_index;
                    if (indd == indd_2)
                    {

                        card_1.GetComponent<Card_Behaviour>().state =
                        Card_Behaviour.states.done;

                        card_2.GetComponent<Card_Behaviour>().state =
                        Card_Behaviour.states.done;

                        int Card_holder_1_index= card_1.GetComponent<Card_Behaviour>().pos_ind;
                        Position_Arranger.transform.GetChild(Card_holder_1_index).GetComponent<Animator>().SetBool(
                            "Closed",true);

                        int Card_holder_2_index = card_2.GetComponent<Card_Behaviour>().pos_ind;
                        Position_Arranger.transform.GetChild(Card_holder_2_index).GetComponent<Animator>().SetBool(
                        "Closed", true);
                        card_1 = null;
                        card_2 = null;

                    }
                    else
                    {
                        

                        StartCoroutine(reset(card_1, card_2));
                        card_1 = null;
                        card_2 = null;



                    }


                }


            break;
        }












    }



    private IEnumerator reset(GameObject crd1,GameObject crd2 )
    {


        yield return new WaitForSeconds(1);


        crd1.GetComponent<Animator>().SetBool("Flip", false);
        
        crd2.GetComponent<Animator>().SetBool("Flip", false);

        yield return new WaitForSeconds(0.5f);
        crd2.GetComponent<Card_Behaviour>().state =
        Card_Behaviour.states.Facce_down;

        crd1.GetComponent<Card_Behaviour>().state =
        Card_Behaviour.states.Facce_down;




    }
}
