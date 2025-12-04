using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Positions_Arranger : MonoBehaviour
{
    // Start is called before the first frame update
    public int Rows;
    public int Columns;
    public static int total_numb;
    public Action Arrange_position;
    public GameObject position;
    private List<GameObject> inst_card_holders=new List<GameObject>();
    void Start()
    {
        Arrange_positions();
    }


    void Arrange_positions()
    {
        // This will arrange the positions for all the     
        
        float offset_X = ((Rows - 1) / 2.0f);
        float offset_y = ((Columns - 1) / 2.0f);
        Debug.Log((offset_X));
        Debug.Log(offset_X);
        
        // Loop to arrange the positions
        for (int i = 0; i < Rows; i++)
        {
            for (int j =0; j < Columns ; j++)
            {
               
                // Adjust the position this object
                Vector3 pos = new Vector3(i-(offset_X), transform.position.y,
                     j-(offset_y));
                // Create an object in the correct position 
                
               GameObject card_holder=(GameObject) Instantiate(position, pos, position.transform.rotation, transform);
               inst_card_holders.Add(card_holder);
            }
        }
        // Fixing the positions of the Card Holders based on the distance between one card holder and another
        if (inst_card_holders.Count > 0)
        {

            foreach(GameObject vr in inst_card_holders)
            {

                vr.transform.position+=((vr.transform.position - transform.position)) * 1.25f;




            }




        }


     }




}

    // Update is called once per frame
    

