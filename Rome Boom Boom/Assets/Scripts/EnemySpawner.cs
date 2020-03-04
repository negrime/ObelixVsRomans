using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemies;
    public Transform left;
    public Transform right;
    public float SpawnTime;
    
    void Start()
    {
        StartCoroutine(nameof(Spawn1));
    }

    private void Spawn()
    {
        Vector3 spawnPositon = GetSpawnPosition();
        GameObject go = Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPositon, Quaternion.identity);
        if (spawnPositon.Equals(left.position))
        {
            go.transform.localScale = new Vector3(go.transform.localScale.x * -1 ,go.transform.localScale.y, transform.localScale.z);
            go.GetComponent<IMovable>().Direction = Vector3.right;
        }
        else    
        {
            go.GetComponent<IMovable>().Direction = Vector3.left;
        }
    }

    private Vector3 GetSpawnPosition()
    {
        return Random.Range(0, 2) == 0 ? left.position : right.position;
    }


    IEnumerator Spawn1()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnTime);
            Spawn();
        }
    }
}
