using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Dimension_adjuster : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject related_text;
    public int adjuster_factor;
    public GameObject position_arranger;
    public enum states {Rows,Columns};
    public states state;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        
        switch (state) {

            case states.Rows:
            if (position_arranger.GetComponent<Positions_Arranger>().Rows > 0&&
                    adjuster_factor<1|| position_arranger.GetComponent<Positions_Arranger>().Rows < 5 &&
                    adjuster_factor > 0)
             {

                    position_arranger.GetComponent<Positions_Arranger>().Rows += adjuster_factor;
                    related_text.GetComponent<TextMeshPro>().text=
                        position_arranger.GetComponent<Positions_Arranger>().Rows.ToString();
                    transform.GetComponent<AudioSource>().Play();
                }

                Positions_Arranger.total_numb = position_arranger.GetComponent<Positions_Arranger>().Columns *
                      position_arranger.GetComponent<Positions_Arranger>().Rows;
                break;


        case states.Columns:

                if (position_arranger.GetComponent<Positions_Arranger>().Columns > 0 &&
                   adjuster_factor < 1 || position_arranger.GetComponent<Positions_Arranger>().Columns < 10 &&
                   adjuster_factor > 0)
                {

                    position_arranger.GetComponent<Positions_Arranger>().Columns += adjuster_factor;

                    related_text.GetComponent<TextMeshPro>().text =
                       position_arranger.GetComponent<Positions_Arranger>().Columns.ToString();
                    transform.GetComponent<AudioSource>().Play();
                }

                Positions_Arranger.total_numb = position_arranger.GetComponent<Positions_Arranger>().Columns *
                   position_arranger.GetComponent<Positions_Arranger>().Rows;

                break;


               



    }
        //related_text.GetComponent<TextMeshProUGUI>().text=
          //  Positions_Arranger
    }
    private void OnMouseUp()
    {
            
    }
    
}
