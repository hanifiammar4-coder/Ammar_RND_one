using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Card_Behaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Action Act_;
    public int pos_ind;
    private Vector3 my_position;
    private Quaternion nxt_Rot;
    public int Card_index;
    public AudioClip[] clips;
    private AudioSource Audiosrce;
    public enum states {moving,Facce_down,Face_up,done,busy};
    public states state;
    private GameObject manager;
    void Start()
    {
        Audiosrce=GetComponent<AudioSource>();
        Act_ = () =>
        {

            go_to_pos();

        };



    }
    void go_to_pos()
    {
        play_aud(2);
        transform.GetComponent<Animator>().SetBool("Lift", true);
        my_position = GameObject.Find("Positions_Arranger").transform.GetChild(pos_ind).transform.position;
        nxt_Rot= GameObject.Find("Positions_Arranger").transform.GetChild(pos_ind).transform.rotation;
        transform.SetParent(GameObject.Find("Cards_parent").transform);
        StartCoroutine(move_to());
    }
    private void play_aud(int clip_ind)
    {
        Audiosrce.pitch = UnityEngine.Random.Range(1f, 1.5f);
        Audiosrce.clip = clips[clip_ind];
        Audiosrce.Play();


    }
    IEnumerator move_to()
    {

        while (Mathf.Abs((transform.position - my_position).magnitude)>0.1f)
        {

            transform.position=Vector3.MoveTowards(transform.position, my_position,20*Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, nxt_Rot,(10/Mathf.Abs((transform.position-my_position).magnitude)));
            yield return null;
        }

        transform.GetComponent<Animator>().SetBool("Lift", false);
        manager = GameObject.Find("Game_manager");
        state=states.Facce_down;
        play_aud(1);

    }
    private void OnMouseEnter()
    {
        


    }
    private void OnMouseDown()
    {
        
       if(manager.GetComponent<Gameplay_manager>().state==Gameplay_manager.states.Play&&
            state == states.Facce_down)
        {
            play_aud(0);
            transform.GetComponent<Animator>().SetBool("Flip", true);
            state=states.Face_up;

            if (Gameplay_manager.card_1 == null)
            {
                Gameplay_manager.card_1 = gameObject;

            }
            else
            {


                Gameplay_manager.card_2 = gameObject;

            }



        }


    }
    private void OnMouseUp()
    {
        




    }
}
