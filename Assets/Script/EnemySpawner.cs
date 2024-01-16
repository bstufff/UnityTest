using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]

    //[SerializeField] private float timeBetweenWaves = 5f;

    private int waveIndex = 0;
    //private bool isSpawing = false;

    private List<Wave> waveList = new List<Wave>();
    private Wave waveToSpawn;
    [System.Serializable]
    public class EnemyGroup
    {
        public int pathTaken;
        public int amountOfEnemies;
        public int enemyType;
        public EnemyGroup(int _pathTaken, int _amountOfEnemies, int _enemyType)
        {
            pathTaken = _pathTaken;
            amountOfEnemies = _amountOfEnemies;
            enemyType = _enemyType;
        }
    }
    public class EnemyFormation
    {

        public List<EnemyGroup> Formation;
        public int numberOfGroups;
        public int spacing;//spacing de 1 = 0.1s entre les spawn
        public int delay = 0;
        public EnemyFormation(List<EnemyGroup> _formation, int _numberOfGroups, int _spacing, int _delay)
        {
            numberOfGroups = _numberOfGroups;
            Formation = _formation;
            spacing = _spacing;
            delay = _delay;
        }
    }
    public class Wave
    {
        public int amountOfFormations;
        public List<EnemyFormation> waveContents = new List<EnemyFormation>();
        public Wave(int _amountOfFormations, List<EnemyFormation> _waveContents)
        {
            amountOfFormations = _amountOfFormations;
            waveContents = _waveContents;
        }
    }





    private void Start()
    {
        Wave wave1 = new Wave(1,new List<EnemyFormation>{ new EnemyFormation(new List<EnemyGroup> {new EnemyGroup(0,10,0)},1, 10, 0) });
        
        waveList.Add(wave1);
        StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        waveToSpawn = waveList[waveIndex];

        for (int i = 0; i < waveToSpawn.amountOfFormations; i++)
        {
            EnemyFormation currentFormation = waveToSpawn.waveContents[i];
            for (int j = 0; j < currentFormation.numberOfGroups; j++)
            {
                EnemyGroup currentGroup = currentFormation.Formation[j];
                for (int k = 0; k < currentGroup.amountOfEnemies; k++)
                {
                    Instantiate(enemyPrefabs[currentGroup.enemyType], LevelManager.main.startPoint.position, Quaternion.identity);
                    yield return new WaitForSeconds(4);
                }
            }
        }
    }
}