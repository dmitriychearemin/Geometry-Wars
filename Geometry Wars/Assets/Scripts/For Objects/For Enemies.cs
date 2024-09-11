using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.TimeZoneInfo;

public class ForEnemies : MonoBehaviour
{
    [SerializeField] int curLvl = 1;
    [SerializeField] float maxHP = 300;
    [SerializeField] float Damage;

    Color defaultMaterialColor;
    Color DamageMaterialColor =new Color (1.2f,0.8f,0.8f);
    Renderer renderer;

    bool isBlink = false;
    float transitionTime = 0.5f;
    float lerpTime = 1.0f;

    [SerializeField] float currentHP;
    

    bool CanTakeDamage = true;
    float MaxInvicibleTime = 3;
    float InvicibleFrame = 1;


    // Start is called before the first frame update
    void Start()
    {
        maxHP += (maxHP / 100) * 10 * curLvl;
        Damage += (Damage / 100) * 5 * curLvl;
        currentHP = maxHP;

        renderer = GetComponent<MeshRenderer>();
        defaultMaterialColor = renderer.material.color;
        print(renderer.material.color);
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


        BlinkTakeDamage();

        if (currentHP <=0) {
            DieEnemy();
        }
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

                isBlink = true; 
                lerpTime = 0.0f;

                CanTakeDamage = false;
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
        if (isBlink)
        {
            lerpTime += Time.deltaTime / transitionTime;
            renderer.material.color = Color.Lerp(defaultMaterialColor, DamageMaterialColor, lerpTime);

            if (lerpTime >= 1.0f)
            {
                isBlink = false; 
            }
        }
        else if (lerpTime > 0.0f)
        {
            lerpTime -= Time.deltaTime / transitionTime;
            renderer.material.color = Color.Lerp(defaultMaterialColor, DamageMaterialColor, lerpTime);
        }
    }

}
