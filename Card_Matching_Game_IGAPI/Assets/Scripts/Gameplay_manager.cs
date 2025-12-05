using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Gameplay_manager : MonoBehaviour
{
    // Start is called before the first frame update
    public enum states {Menu_State,Prepare_state,Shuffle, Distribute,reveal_cards,Play};
    public states state;
    private delegate void deg();
    private deg mydeg;
    private float timer;
    public GameObject Deck,Deck_creator;
    public GameObject Position_Arranger;
    public static GameObject card_1, card_2;
    public static int score,combo,Turn;
    public static bool load;
    private AudioSource adsrce;
    public GameObject combo_parent;
    public AudioClip[] clips;
    void Start()
    {
        load = false;
        timer=Mathf.Infinity;
        adsrce=transform.GetComponent<AudioSource>();
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
            case states.Menu_State:

                //Delete All the objects on the table
                if (GameObject.Find("Back_Ground_music").GetComponent<AudioSource>().isPlaying) GameObject.Find("Back_Ground_music").GetComponent<AudioSource>().Stop();
                GameObject.Find("Canvas").transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
                if (Position_Arranger.transform.childCount > 0)
                {

                    for(int i = 0; i <Position_Arranger.transform.childCount; i++)
                    {

                       Destroy(Position_Arranger.
                           transform.GetChild(i).gameObject);

                    }


                }
                if (GameObject.Find("Cards_parent").transform.childCount > 0)
                {

                    for (int i = 0; i < GameObject.Find("Cards_parent").transform.childCount; i++)
                    {

                        Destroy(transform.GetChild(i).gameObject);

                    }


                }




            break;

            //The First state of the gameplay
            case states.Prepare_state:

                if (timer == Mathf.Infinity)
                {
                    Camera.main.GetComponent<Animator>().SetBool("to_table", true);
                    Position_Arranger.GetComponent<Positions_Arranger>().Arrange_position();
                    timer = 3;
                    mydeg = () =>
                    {

                        timer = 1;
                        mydeg = () =>
                        {
                            if (load != true)
                            {

                                Deck_creator.GetComponent<Deck_Creator>().start_new();
                            }
                            else
                            {


                                Deck_creator.GetComponent<Deck_Creator>().Load();

                            }
                            timer = Mathf.Infinity;
                            state=states.Shuffle;
                            return;
                        };





                    };



                }


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
                    if (Deck.transform.childCount > 0)
                    {
                        if (Deck.transform.GetChild(0).gameObject.activeSelf == true)
                        {

                            Deck.transform.GetChild(0).GetComponent<Card_Behaviour>().Act_();
                            timer = 0.15f;


                        }
                        else
                        {



                            timer = Mathf.Infinity;
                            state = states.reveal_cards;


                        }
                    }
                    else
                    {

                        timer = Mathf.Infinity;
                        state = states.reveal_cards;
                    }


                };



                break;
            // Reveal the cards for few seconds
            case states.reveal_cards:
                if (timer == Mathf.Infinity)
                {

                    timer = 0.5f;
                    mydeg = () =>
                    {
                        timer = 5;

                        for(int i = 0; i < GameObject.Find("Cards_parent").transform.childCount; i++)
                        {

                            GameObject.Find("Cards_parent").transform.GetChild(i).GetComponent<Animator>().SetBool("Flip", true);

                        }
                        mydeg = () =>
                        {

                            for (int i = 0; i < GameObject.Find("Cards_parent").transform.childCount; i++)
                            {

                                GameObject.Find("Cards_parent").transform.GetChild(i).GetComponent<Animator>().SetBool("Flip",false);

                            }


                            timer = Mathf.Infinity;
                            state = states.Play;


                        };





                    };



                }








            break;


                // the state of playing the Game
            case states.Play:
                GameObject.Find("Canvas").transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
               
                GameObject.Find("Canvas").transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0)
                .GetComponent<TextMeshProUGUI>().text=score.ToString();
                if (!GameObject.Find("Back_Ground_music").GetComponent<AudioSource>().isPlaying) GameObject.Find("Back_Ground_music").GetComponent<AudioSource>().Play();
                    if (card_1 != null && card_2 != null)
                {
                    int indd =card_1.GetComponent<Card_Behaviour>().Card_index;
                    int indd_2 = card_2.GetComponent<Card_Behaviour>().Card_index;
                    
                    if (indd == indd_2)
                    {
                        combo++;
                        Play_audio_clip(0);
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
                        StartCoroutine(destroy_cards(card_1, card_2));
                        card_1 = null;
                        card_2 = null;

                    }
                    else
                    {

                        combo = 0;
                        Play_audio_clip(1);
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
    private IEnumerator destroy_cards(GameObject crd_1,GameObject crd_2)
    {
        yield return new WaitForSeconds(1);
        Instantiate(combo_parent, crd_1.transform.position, combo_parent.transform.rotation);
        Instantiate(combo_parent, crd_2.transform.position, combo_parent.transform.rotation);
        Destroy(crd_1);
        Destroy(crd_2);
        yield return new WaitForSeconds(2);
        if (GameObject.Find("Cards_parent").transform.childCount == 0)
        {


            state=states.Menu_State;
            Camera.main.GetComponent<Animator>().SetBool("to_table", false);

            Camera.main.GetComponent<Animator>().SetBool("Load", false);
        }

    }

    private void Play_audio_clip(int clip)
    {
        adsrce.pitch=UnityEngine.Random.Range(1,1.5f);
        transform.GetComponent<AudioSource>().clip = clips[clip];
        transform.GetComponent<AudioSource>().Play();


    }


}
