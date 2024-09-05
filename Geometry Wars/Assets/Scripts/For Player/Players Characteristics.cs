using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayersCharacteristics : MonoBehaviour
{
    int Level;
    float HitPoints = 100;
    float Stamina = 100;

    float curHP;
    float curStamina;

    float CurrentEXP = 0;
    float NeedExp;

    float DamageBody = 0; //в процентах
    float Defence = 0; //в процентах

    float maxHitpoints = 300;
    float maxStamina = 300;
    float maxDamageBody = 30; //в процентах
    float maxDefence = 40;
    int   maxLevel = 100;

    // Start is called before the first frame update
    void Start()
    {
        curHP = HitPoints;
        curStamina = Stamina;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getHP()
    {
        return curHP;
    }

    public float getStamina()
    {
        return curStamina;
    }

    public float getMaxHP()
    {
        return HitPoints;
    }

    public float getMaxStamina()
    {
        return Stamina;

    }

    public void setCurHp(float hp)
    {
        curHP = hp;
    }

    public void setCurStamina(float stamina)
    {
        curStamina = stamina;
    }



}
