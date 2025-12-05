using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score_object : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] numbers_sprts;
    private AudioSource adsrc;
    void Start()
    {
        adsrc = GetComponent<AudioSource>();
        if (Gameplay_manager.combo <2)
        {
            transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            Gameplay_manager.score += 25;
        }
        else
        {

            transform.GetComponent<AudioSource>().pitch += Gameplay_manager.combo / 20;
            transform.GetChild(0).GetChild(1).GetChild(2).GetComponent<SpriteRenderer>().sprite =
                numbers_sprts[Gameplay_manager.combo-2];
            Gameplay_manager.score += 25* Gameplay_manager.combo;
            adsrc.Play();

        }

        
        
        
    }

    private IEnumerator destroy_after()
    {

        yield return new WaitForSeconds(4);
        Destroy(gameObject);

    }
   
}
