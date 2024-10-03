using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForEnemyWeapon : MonoBehaviour
{
    // [SerializeField] float damage = 60;
    //float distance;
    [SerializeField] bool isMeleeWeapon = true;
    bool isPlayAnimation = false;
    int NumCurrentAnimation;
    Animator animator;

    private List<string> attackAnimation = new List<string>(); //через запятую можно добавить ещё

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        attackAnimation.Add("AttackType1");
        attackAnimation.Add("AttackType2");

        //if (isMeleeWeapon)
        //{
        //    attackAnimation.Add("AttackType3");
        //}


    }

    // Update is called once per frame
    void Update()
    {
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

        if ( isPlayAnimation == false)
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
