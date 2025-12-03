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
    public Action Arrange_position;
    public GameObject position;
    void Start()
    {
        Arrange_positions();
    }


    void Arrange_positions()
    {
        // This will arrange the positions for all the     
        
        float offset_X = (Rows - 1) / 2.0f;
        float offset_y = (Columns - 1) / 2.0f;
        Debug.Log((Rows/2));
        Debug.Log(offset_y);
        // Loop to arrange the positions
        for (int i = 0; i < Rows; i++)
        {
            for (int j =0; j < Columns ; j++)
            {
               
                // Adjust the position this object
                Vector3 pos = new Vector3((i-offset_X), transform.position.y,
                     (j-offset_y));
                // Create an object in the correct position 
                
                Instantiate(position, pos, position.transform.rotation, transform);
            }
        }
        }




    }

    // Update is called once per frame
    

