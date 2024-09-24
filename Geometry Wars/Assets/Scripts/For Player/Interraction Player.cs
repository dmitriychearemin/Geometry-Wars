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

    bool CanTakeDamage = true;
    float MaxInvicibleTime = 3;
    float InvicibleFrame = 1;

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
        if (!CanTakeDamage && InvicibleFrame < MaxInvicibleTime)  // проверка на колчиство пройденных кадров неу€звимости
        {
            InvicibleFrame += InvicibleFrame * Time.deltaTime;
        }
        if (InvicibleFrame >= MaxInvicibleTime)
        {
            InvicibleFrame = 1;
            CanTakeDamage = true;
        }
    }

    public bool TakeDamage(float minus)
    {
        playersCharacteristics.setCurHp(playersCharacteristics.getCurHP() - minus);
        if(playersCharacteristics.getCurHP() <= 0)
        {
            playersCharacteristics.setCurHp(0);
            DyingPlayer();
        }
        return true;
        
        
        
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


    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.tag == "Enemy" && CanTakeDamage == true)
        {
            CanTakeDamage = false;
            ForEnemies enemy = collision.gameObject.GetComponent<ForEnemies>();
            TakeDamage(enemy.GetDamage());
        }

        else if(collision.transform.tag == "EnemyWeapon" && CanTakeDamage == true)
        {
            if (collision.transform.GetComponent<ForEnemyWeapon>().canDamage())
            {
                CanTakeDamage = false;
                ForEnemies enemy = collision.gameObject.GetComponentInParent<ForEnemies>();
                TakeDamage(enemy.GetDamage());
            }

            
        }
    }


    void DyingPlayer()
    {
        print("Die");
    }

}
