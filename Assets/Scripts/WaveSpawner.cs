using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;
        
    public Transform spawnPoint;
    
    public float timeBetweenWaves = 5f;
    private float countDown = 2f;
    
    public TextMeshProUGUI waveCountDownText;

    public GameManager gameManager;
    
    private int waveindex = 0;
    void Start()
    {
        
    }

    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        
        if (waveindex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
        
        if (countDown <= 0f)
        {
            StartCoroutine(spawnWave());
            countDown = timeBetweenWaves;
            return;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{0:00.00}", countDown);
}

    IEnumerator spawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveindex];

        EnemiesAlive = wave.count;
        
        for (int i = 0; i < wave.count; i++)
        {
            spawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        
        waveindex++;
    }

    void spawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
