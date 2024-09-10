using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForEnemies : MonoBehaviour
{

    float currentHP;
    float maxHP= 100;

    //bool CanTakeDamage = true;
    //float MaxInvicibleTime = 3;
    //float InvicibleFrame = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!CanTakeDamage && InvicibleFrame < MaxInvicibleTime)  // проверка на колчиство пройденных кадров неу€звимости
        {
            InvicibleFrame += InvicibleFrame * Time.deltaTime;
        }
        if (InvicibleFrame >= MaxInvicibleTime)
        {
            InvicibleFrame = 1;
            CanTakeDamage = true;
        }*/


        if (currentHP <=0) {
            DieEnemy();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Weapon")
        {
            
            ForWeapons weapon = collision.transform.GetComponent<ForWeapons>();
            
            if (weapon.canDamage())
            {
                //CanTakeDamage = false;
                print("collision" + " " + currentHP);
                currentHP -= collision.gameObject.GetComponent<ForWeapons>().getDamageWeapon();
            }
            
        }
    }


    void DieEnemy()
    {
        
        DestroyObject(gameObject);
    }


}
