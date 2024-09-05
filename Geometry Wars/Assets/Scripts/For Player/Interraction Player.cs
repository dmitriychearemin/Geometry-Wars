using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterractionPlayer : MonoBehaviour
{

    PlayersCharacteristics playersCharacteristics;

    // Start is called before the first frame update
    void Start()
    {
        playersCharacteristics = GetComponent<PlayersCharacteristics>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        playersCharacteristics.setCurHp(playersCharacteristics.getHP() - 50);


    }


}
