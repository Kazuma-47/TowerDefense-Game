using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavespawnerNobutton : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyprefabs;
    [SerializeField] private Vector2 MinMaxSpawnTime;

    public Tile _spawnTile;
    private float timer = 0f;
    private float nextSpawnTime;


    private void Update()
    {
        timer += Time.deltaTime;

        if(timer>= nextSpawnTime)
        {
            SpawnNextEnemy();
        }
    }

    private void SpawnNextEnemy()
    {
        int randomIndex = Random.Range(0, _enemyprefabs.Length);
        Vector3 spawnPosition = new Vector3(_spawnTile.transform.position.x, -1f, _spawnTile.transform.position.z);
        Instantiate(_enemyprefabs[randomIndex], spawnPosition, Quaternion.identity,transform);

        timer = 0;
        nextSpawnTime = Random.Range(MinMaxSpawnTime.x, MinMaxSpawnTime.y);
    }

}
