using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSurvivalMode: MonoBehaviour
{
    [SerializeField]List<GameObject> TypesTerrains = new List<GameObject>();
    [SerializeField] List<GameObject> EnemyList = new List<GameObject>();
    [SerializeField]GameObject Player;
    GameObject location, enemyspawner, playerspawner;

    void Start()
    {
        int rand = Random.Range(0,TypesTerrains.Count);
        location = Instantiate(TypesTerrains[rand]);
        location.SetActive(true);
        print("Terrain create");
        playerspawner = location.transform.Find("PlayerSpawn").gameObject;
        var player = Instantiate(Player, playerspawner.transform);
        player.SetActive(true);
        player.name = Player.name;
        print("Player create");
        enemyspawner = location.transform.Find("EnemySpawners").gameObject;
        SpawnEnemy();
        print("Enemy create");
        
    }

    

    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        foreach (Transform enemyspawn in enemyspawner.transform)
        {
            int rand = Random.Range(0, EnemyList.Count);
            var ememy = Instantiate(EnemyList[rand],enemyspawn);
            ememy.name = EnemyList[rand].name;
            ememy.SetActive(true);
            

        }
    }

}
