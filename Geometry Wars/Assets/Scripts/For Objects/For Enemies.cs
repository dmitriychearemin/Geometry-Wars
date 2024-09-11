using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForEnemies : MonoBehaviour
{
    [SerializeField] int curLvl = 1;
    [SerializeField] float maxHP = 100;
    [SerializeField] float Damage;

    Color defaultMaterialColor;
    Color DamageMaterialColor =new Color (255,0,0);
    Color curMaterialColor;

    float currentHP;
    



    bool CanTakeDamage = true;
    float MaxInvicibleTime = 3;
    float InvicibleFrame = 1;


    // Start is called before the first frame update
    void Start()
    {
        maxHP += (maxHP / 100) * 10 * curLvl;
        Damage += (Damage / 100) * 5 * curLvl;
        currentHP = maxHP;


        defaultMaterialColor = GetComponent<MeshRenderer>().material.color;
        
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


        if (currentHP <=0) {
            DieEnemy();
        }

        GetComponent<MeshRenderer>().material.color = defaultMaterialColor;
    }


    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.tag == "Weapon")
        {
            
            ForWeapons weapon = collision.transform.GetComponent<ForWeapons>();
            
            if (weapon.canDamage() && CanTakeDamage)
            {
                if (!weapon.isMeleeWeapons())
                {
                    InvicibleFrame *= 2;
                }
                BlinkTakeDamage();
                CanTakeDamage = false;
                print("collision" + " " + currentHP);
                currentHP -= collision.gameObject.GetComponent<ForWeapons>().getDamageWeapon();
            }
            
        }
    }


    void DieEnemy()
    {
        DestroyObject(gameObject);
    }

    public float GetDamage()
    {
        return Damage;
    }

    void Attack()
    {

    }

    void MoveToPlayer()
    {

    }

    void BlinkTakeDamage()
    {
        GetComponent<MeshRenderer>().material.color = DamageMaterialColor;
        
    }

}
