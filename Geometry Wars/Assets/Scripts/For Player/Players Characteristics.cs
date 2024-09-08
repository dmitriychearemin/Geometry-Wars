using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayersCharacteristics : MonoBehaviour
{
    int Level;
    float HitPoints = 100;
    float Stamina = 100;

    [SerializeField]float curHP;
    [SerializeField] float curStamina;

    float CurrentEXP = 0;
    float NeedExp;

    float DamageBody = 0; //� ���������
    float Defence = 0; //� ���������

    float maxPotencialHitpoints = 300;
    float maxPotencialStamina = 300;
    float maxPotencialDamageBody = 30; //� ���������
    float maxPotencialDefence = 40;
    int   maxPotencialLevel = 100;

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

    public float getCurHP()
    {
        return curHP;
    }

    public float getCurStamina()
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