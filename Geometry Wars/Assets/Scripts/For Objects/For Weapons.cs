using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForWeapons : MonoBehaviour
{

    [SerializeField] float damage = 60;
    float distance;
    [SerializeField] bool isMeleeWeapon=true;
    bool isPlayAnimation =false;
    int NumCurrentAnimation;
    Animator animator;

    private List<string> attackAnimation = new List<string>(); //����� ������� ����� �������� ���

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        attackAnimation.Add("AttackType1");
        attackAnimation.Add("AttackType2");
        
        if (isMeleeWeapon)
        {
            attackAnimation.Add("AttackType3");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    public float getDamageWeapon()
    {
        return damage;
    }

    public float getDistanceWeapon()
    {
        return distance;
    }

    public bool canDamage()
    {
        return isPlayAnimation;
    }

    public bool isMeleeWeapons()
    {
        return isMeleeWeapon;
    }

    public void Attack()
    {
        
        if (Input.GetButtonDown("Fire1") && isPlayAnimation == false)
        {
            NumCurrentAnimation = Random.Range(0, attackAnimation.Count);
            animator.SetBool(attackAnimation[NumCurrentAnimation], true);
            isPlayAnimation = true;
        }

      

    }


    void ChangingAnimationPlay()
    {
        
        isPlayAnimation = false;
        animator.SetBool(attackAnimation[NumCurrentAnimation], false);
         
    }
    

}
