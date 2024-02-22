using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;//Array contenant les prefabs des ennemis 
    [Header("Attributes")]

    [SerializeField] private List<Wave> waveList = new List<Wave>();//Liste contenant toutes les waves du jeu
    [SerializeField] private List<Path> pathList = new List<Path>();
    [System.Serializable]
    public class Path
    {
        public int pathNumber;
        public Transform startPoint;
        public Transform[] PathContents;
    }
    [System.Serializable]
    public class EnemyGroup
    {
        public Path pathTaken;//Chemin pris par les ennemis
        public int pathNumber;
        public int amountOfEnemies;//Quantité d'ennemis dans le groupe
        public int enemyType;//Type d'ennemi : entier correspondant à la position du prefab séléctionné dans enemyPrefabs
        public EnemyGroup(Path _pathTaken, int _amountOfEnemies, int _enemyType)//constructeur
        {
            pathNumber = _pathTaken.pathNumber;
            pathTaken = _pathTaken;
            amountOfEnemies = _amountOfEnemies;
            enemyType = _enemyType;
        }
    }
    [System.Serializable]
    public class EnemyFormation
    {

        public List<EnemyGroup> Formation;//Liste des groupes d'ennemis pr sents dans la formation
        public int numberOfGroups;//no shit
        public int spacing;//spacing de 1 = 0.1s entre les spawn
        public int delay = 0;//délai avant le lancement de cette formation, si = 0 la formation commencera à spawn juste apr s la fin de la précédente
        public EnemyFormation(List<EnemyGroup> _formation, int _numberOfGroups, int _spacing, int _delay)//Constructeur
        {
            numberOfGroups = _numberOfGroups;
            Formation = _formation;
            spacing = _spacing;
            delay = _delay;
        }
    }
    [System.Serializable]
    public class Wave
    {
        public int amountOfFormations;
        public List<EnemyFormation> waveContents = new List<EnemyFormation>();//Liste des formations d'ennemis contenues dans la vague
        public Wave(int _amountOfFormations, List<EnemyFormation> _waveContents)//Constructeur
        {
            amountOfFormations = _amountOfFormations;
            waveContents = _waveContents;
        }
    }


    private void Start()
    {
        /*Exemple de wave
        Wave wave1 = new Wave(1,new List<EnemyFormation>{ 
            new EnemyFormation(new List<EnemyGroup> {
                new EnemyGroup(0,10,0)
            },1, 10, 0) 
        
        });
        waveList.Add(wave1);//Ajout à wavelist */
        foreach (Wave CurrentWave in waveList)
        {
            StartCoroutine(StartWave(CurrentWave));//Commence une coroutine qui lance la vague (faire une coroutine permet d'ajouter du délai sans déranger le reste du programme)
        }
    }

    public Transform ParentGameObject;

    public List<GameObject> Enemy = new List<GameObject>();



    IEnumerator StartWave(Wave waveToSpawn)
    {
        for (int i = 0; i < waveToSpawn.amountOfFormations; i++)//Boucle des formations
        {
            EnemyFormation currentFormation = waveToSpawn.waveContents[i];//Séléctionne la formation
            yield return new WaitForSeconds(currentFormation.delay);//Délai avant que la formation apparaisse
            for (int j = 0; j < currentFormation.numberOfGroups; j++)//Boucle des groupes
            {
                EnemyGroup currentGroup = currentFormation.Formation[j];//Séléctionne le groupe d'ennemis
                for (int k = 0; k < currentGroup.amountOfEnemies; k++)//Boucle des ennemis
                {
                    StartCoroutine(SpawnGroup(currentGroup));
                }
            }
        }
        yield return new WaitForSeconds(15);//Délai de 15 secondes apr s la fin d'une vague
        //Maybe un moyen visuel d'indiquer ce délai entre les vagues ?
    }
    IEnumerator SpawnGroup(EnemyGroup currentGroup) 
    {
        GameObject InstancietedObj = Instantiate(enemyPrefabs[currentGroup.enemyType], pathList[currentGroup.pathNumber].startPoint.position, Quaternion.identity);//Fait apparaitre un ennemi
        InstancietedObj.GetComponent<EnemyMovement>().SetPath(pathList, currentGroup.pathNumber);
        InstancietedObj.transform.parent = ParentGameObject;
        Enemy.Add(InstancietedObj);

        yield return new WaitForSeconds(4);//Délai entre les spawns
    }

    public GameObject Index0A;


    public void Update()
    {/*
        SpriteRenderer spriterenderer;
        GameObject Index0B;
        if (Enemy.Count != 0)
        {
            Index0A = Enemy[0];
            Index0B = Enemy[0];
            spriterenderer = Enemy[0].GetComponent<SpriteRenderer>();
            Debug.Log("oui1");
            if (spriterenderer.enabled == false)
            {

                Enemy.RemoveAt(0);
                Index0B = Enemy[0];
                GameObject.Destroy(Index0A);
                Index0A = Index0B;
                Debug.Log("oui2");
            }
        }*/
    }
}