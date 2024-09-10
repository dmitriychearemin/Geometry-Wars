using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InterractionPlayer : MonoBehaviour
{

    PlayersCharacteristics playersCharacteristics;
    Transform weaponObject;
    ForWeapons weaponParam;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playersCharacteristics = GetComponent<PlayersCharacteristics>();
        weaponObject = GameObject.FindWithTag("Weapon").transform;
        weaponParam = weaponObject.GetComponent<ForWeapons>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool TakeDamage(float minus)
    {
        if (playersCharacteristics.getCurHP()>= minus)
        {
            playersCharacteristics.setCurHp(playersCharacteristics.getCurHP() - minus);
            return true;
        }
        return false;
        
    }

    public bool DecreaseStamina(float minus)
    {
        if (playersCharacteristics.getCurStamina() >= minus)
        {
            playersCharacteristics.setCurStamina(playersCharacteristics.getCurStamina() - minus);
            return true;
        }
        return false;
    }

    public bool CheckOnFullStamina()
    {
        if(playersCharacteristics.getCurStamina() == playersCharacteristics.getMaxStamina())
        {
            return true;
        }
        return false;
    }

    public void RegeneratingStamina()
    {
               
        playersCharacteristics.setCurStamina(playersCharacteristics.getCurStamina() +
        playersCharacteristics.getMaxStamina() / 4 * Time.deltaTime);
        if (playersCharacteristics.getCurStamina() > playersCharacteristics.getMaxStamina())
            {
                playersCharacteristics.setCurStamina(playersCharacteristics.getMaxStamina());
            }   
    }
    

}
