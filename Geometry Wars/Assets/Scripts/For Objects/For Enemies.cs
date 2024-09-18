using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.TimeZoneInfo;

public class ForEnemies : MonoBehaviour
{
    [SerializeField] int curLvl = 1;
    [SerializeField] float maxHP = 300;
    [SerializeField] float Damage;
    [SerializeField] ParticleSystem bloodSplash;

    float EnemySpeed;

    List<ParticleSystem> bloodSplashes = new List<ParticleSystem>();

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

    GameObject player;
    float Y;
    [SerializeField] bool EnemyIsMelee = true;
    Quaternion defaultRotation;

    
    bool isAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        maxHP += (maxHP / 100) * 10 * curLvl;
        Damage += (Damage / 100) * 5 * curLvl;
        currentHP = maxHP;

        renderer = GetComponent<MeshRenderer>();
        defaultMaterialColor = renderer.material.color;
        defaultRotation = transform.rotation;

        player = GameObject.Find("Player");

        if (EnemyIsMelee)
        {
            EnemySpeed = 3.1f;
        }
        else
        {
            EnemySpeed = 2.5f;
        }

        Y = transform.position.y;
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
            foreach (var splashes in bloodSplashes)
            {
                if (splashes)
                    Destroy(splashes.gameObject);
            }
        }

        BlinkTakeDamage();

        MoveToPlayer();
        //print(transform.position);

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
                ContactPoint contactPoint = collision.contacts[0];
                Quaternion rot = Quaternion.FromToRotation(Vector3.up, -contactPoint.normal);
                ParticleSystem bloodsplash = Instantiate(bloodSplash, contactPoint.point, rot);
                bloodSplashes.Add(bloodsplash); 
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
        isAttack  = true;


    }

    void MoveToPlayer()
    {
        if (Distance2dXZ(transform.position.x, transform.position.z, player.transform.position.x, player.transform.position.z) > 2)
        {
            //print(Distance2dXZ(transform.position.x, transform.position.z, player.transform.position.x, player.transform.position.z));
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, EnemySpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, Y, transform.position.z);
        }
        
        else if(Distance2dXZ(transform.position.x, transform.position.z, player.transform.position.x, player.transform.position.z)<= 1.8) {
            //print(Distance2dXZ(transform.position.x, transform.position.z, player.transform.position.x, player.transform.position.z));
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, -EnemySpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, Y, transform.position.z);
        }

        else
        {
            Attack();
        }

        Vector3 playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(playerPos);
        
    }

    void BlinkTakeDamage()
    {
        if (isBlink)
        {
            lerpTime += 2* Time.deltaTime / transitionTime;
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


    float Distance2dXZ(float x1,float z1, float x2, float z2)
    {
        float distance;

        distance =(float)Math.Sqrt( ((x2-x1)*(x2-x1)) + ((z2-z1)*(z2-z1)) );
        return distance;
    }
    



}
