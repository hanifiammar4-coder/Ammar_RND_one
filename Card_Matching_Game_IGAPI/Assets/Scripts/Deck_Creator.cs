using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck_Creator : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D[] Textures;
    public List<int> Cards_indexes = new List<int>();
    public List<GameObject> Cards_objects=new List<GameObject>();
    public GameObject Positions_Arranger;
    public GameObject card_prefab;
    public GameObject Deck;
    void Start()
    {
        StartCoroutine(choose_Textures());
    }

    // Update is called once per frame
    private IEnumerator choose_Textures()
    {
        int i= 0;
        int rnd = 0;
        
        int half_Cards_number = (Positions_Arranger.GetComponent<Positions_Arranger>().Rows*
        Positions_Arranger.GetComponent<Positions_Arranger>().Columns)/2;
        while (i<half_Cards_number)
        {

            rnd = UnityEngine.Random.Range(0, Textures.Length);

            if (!Cards_indexes.Contains(rnd))
            {
                i++;
                // Add the number twice 
                Cards_indexes.AddRange(new int []{rnd, rnd});
               
            }


            yield return null;
        }

        StartCoroutine(Shuffle_numbers());

    }
    private IEnumerator Shuffle_numbers()
    {

        yield return new WaitForEndOfFrame() ;
        for (int i=0; i < Cards_indexes.Count; i++)
        {
            // Get a random number from a the cards indexer list and swap it with another
            int saver = 0;
            int rndm=Random.Range(0, Cards_indexes.Count);
            saver = Cards_indexes[i];
            Cards_indexes[i]=Cards_indexes[rndm];
            Cards_indexes[rndm]=saver;

            yield return null;  


        }


        StartCoroutine(Add_Cards());
    }
    private IEnumerator Add_Cards()
    {
        yield return new WaitForEndOfFrame();
        var children = Deck.transform.Cast<Transform>().ToList();
        int i = 0;
        // Use a lambda to filter and destroy a specified number of children
        children.ForEach(child => {
            if (i < Cards_indexes.Count)
            {
                child.GetChild(0).GetChild(0).GetComponent<Renderer>().material.mainTexture =
            Textures[Cards_indexes[i]];
                child.GetComponent<Card_Behaviour>().Card_index=Cards_indexes[i];
                child.GetComponent<Card_Behaviour>().pos_ind = i;
            }
            else
            {

                child.gameObject.SetActive(false);

            }

            i++;



        });
        GameObject.Find("Game_manager").GetComponent<Gameplay_manager>().state =
        Gameplay_manager.states.Distribute;
    }

    
}
