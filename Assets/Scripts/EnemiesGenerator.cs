using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemiesGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] enemiesPrefab;

    [SerializeField] private Transform Player;

    [SerializeField] private float zPosition = 10f;
    [SerializeField] private float xPosition = 10f;


    [SerializeField] private float posX = 10f;
    [SerializeField] private float posZ = 10f;

    [SerializeField] private float generateInterval = 2f;
    void Start()
    {
        InvokeRepeating("GenerateEnemies", 0f, generateInterval);
    }

    
    void Update()
    {
        
    }

    void GenerateEnemies()
    {
        int indexRandom = Random.Range(0, enemiesPrefab.Length);
        float randomX = Random.Range(-posX, posX);
        float randomZ = Random.Range(-posZ, posZ);

        if (indexRandom == 0)
        {
            Vector3 generatorPosition = new Vector3(randomX, 1f, zPosition);

            GameObject enemy = Instantiate(enemiesPrefab[indexRandom], generatorPosition, Quaternion.identity);

            enemy.GetComponent<EnemyMov>().SetTarget(Player);
        }
        else if (indexRandom == 1)
        {
            Vector3 generatorPosition = new Vector3(randomX, 1f, -zPosition);

            GameObject enemy = Instantiate(enemiesPrefab[indexRandom], generatorPosition, Quaternion.identity);

            enemy.GetComponent<EnemyMov>().SetTarget(Player);
        } else if (indexRandom == 2)
        {
            Vector3 generatorPosition = new Vector3(xPosition, 1f, randomZ);

            GameObject enemy = Instantiate(enemiesPrefab[indexRandom], generatorPosition, Quaternion.identity);

            enemy.GetComponent<EnemyMov>().SetTarget(Player);
        }
        else
        {
            Vector3 generatorPosition = new Vector3(-xPosition, 1f, randomZ);

            GameObject enemy = Instantiate(enemiesPrefab[indexRandom], generatorPosition, Quaternion.identity);

            enemy.GetComponent<EnemyMov>().SetTarget(Player);
        }

    }

}
