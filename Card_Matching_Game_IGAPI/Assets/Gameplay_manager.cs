using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay_manager : MonoBehaviour
{
    // Start is called before the first frame update
    public enum states {First_state,Shuffle, Distribute,Play};
    public states state;
    private delegate void deg();
    private deg mydeg;
    private float timer;
    public GameObject Deck;
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





                break;




                // the state of playing the Game
            case states.Play:




            break;
        }












    }
}
