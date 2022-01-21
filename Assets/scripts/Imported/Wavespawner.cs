using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wavespawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyprefabs;
    [SerializeField] private Vector2 MinMaxSpawnTime;
    public TextMeshProUGUI wavenumer;

    public Tile _spawnTile;
    private float timer = 0f;
    private float nextSpawnTime;
    public int Wavelength =10;
    public int WaveNumber = 1;
    public bool WaveActive;
    public bool Wavefinished = true;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    private void Start()
    {
        EnableWaveSpawner(false);
    }

    private void Update()
    {
        wavenumer.text = WaveNumber.ToString();
        timer += Time.deltaTime;
        if (spawnedEnemies.Count >= Wavelength)
        {
            
            EnableWaveSpawner(false);
            WaveActive = false;
            Wavelength = Wavelength + 5;
            FindObjectOfType<TurretHealth>().TakeDamage(1);
            Wavefinished = true;
            return;
        }
        else if(timer>= nextSpawnTime && WaveActive == true)
        {
            SpawnNextEnemy();
        }
    }

    //spawn enemy
    private void SpawnNextEnemy()
    {
        int randomIndex = Random.Range(0, _enemyprefabs.Length);
        Vector3 spawnPosition = new Vector3(_spawnTile.transform.position.x, _spawnTile.transform.position.y + 1, _spawnTile.transform.position.z);
        GameObject newEnemy = Instantiate(_enemyprefabs[randomIndex], spawnPosition, Quaternion.identity);

        spawnedEnemies.Add(newEnemy);
        timer = 0;
        nextSpawnTime = Random.Range(MinMaxSpawnTime.x, MinMaxSpawnTime.y);
    }

    //start wave
    public void WaveStartButton()
    {
        if (Wavefinished == true)
        {

            
            EnableWaveSpawner(true);
            Wavefinished = false;
            WaveNumber++;
        }
        else
        {
            return;
        }
        
    }

    public void EnableWaveSpawner(bool state)
    {
        
        print(WaveActive);
        WaveActive = state;
    
        if (WaveActive)
        {
            print("its working");
            spawnedEnemies.Clear();
            timer = 0;
            nextSpawnTime = Random.Range(MinMaxSpawnTime.x, MinMaxSpawnTime.y);
        }
    }

}
