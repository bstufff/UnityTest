using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;//Array contenant les prefabs des ennemis 
    [Header("Attributes")]

    [SerializeField]private List<Wave> waveList = new List<Wave>();//Liste contenant toutes les waves du jeu
    [System.Serializable]
    public class EnemyGroup
    {
        public int pathTaken;//Chemin pris par les ennemis
        public int amountOfEnemies;//Quantit� d'ennemis dans le groupe
        public int enemyType;//Type d'ennemi : entier correspondant � la position du prefab s�l�ctionn� dans enemyPrefabs
        public EnemyGroup(int _pathTaken, int _amountOfEnemies, int _enemyType)//Fonction pour initialisation
        {
            pathTaken = _pathTaken;
            amountOfEnemies = _amountOfEnemies;
            enemyType = _enemyType;
        }
    }
    [System.Serializable]
    public class EnemyFormation
    {

        public List<EnemyGroup> Formation;//Liste des groupes d'ennemis pr�sents dans la formation
        public int numberOfGroups;//no shit
        public int spacing;//spacing de 1 = 0.1s entre les spawn
        public int delay = 0;//d�lai avant le lancement de cette formation, si = 0 la formation commencera � spawn juste apr�s la fin de la pr�c�dente
        public EnemyFormation(List<EnemyGroup> _formation, int _numberOfGroups, int _spacing, int _delay)//Fonction pour initialisation
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
        public int amountOfFormations;//no shit
        public List<EnemyFormation> waveContents = new List<EnemyFormation>();//Liste des formations d'ennemis contenues dans la vague
        public Wave(int _amountOfFormations, List<EnemyFormation> _waveContents)//Fonction pour initialisation
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
        waveList.Add(wave1);//Ajout � wavelist */
        foreach (Wave CurrentWave in waveList) {
            StartCoroutine(StartWave(CurrentWave));//Commence une coroutine qui lance la vague (faire une coroutine permet d'ajouter du d�lai sans d�ranger le reste du programme)
        }
    }

    IEnumerator StartWave(Wave waveToSpawn)
    {
        for (int i = 0; i < waveToSpawn.amountOfFormations; i++)//Boucle des formations
        {
            EnemyFormation currentFormation = waveToSpawn.waveContents[i];//S�l�ctionne la formation
            yield return new WaitForSeconds(currentFormation.delay);//D�lai avant que la formation apparaisse
            for (int j = 0; j < currentFormation.numberOfGroups; j++)//Boucle des groupes
            {
                EnemyGroup currentGroup = currentFormation.Formation[j];//S�l�ctionne le groupe d'ennemis
                for (int k = 0; k < currentGroup.amountOfEnemies; k++)//Boucle des ennemis
                {
                    Instantiate(enemyPrefabs[currentGroup.enemyType], LevelManager.main.startPoint.position, Quaternion.identity);//Fait apparaitre un ennemi
                    yield return new WaitForSeconds(4);//D�lai entre les spawns
                }
            }
        }
        yield return new WaitForSeconds(15);//D�lai de 15 secondes apr�s la fin d'une vague
        //Maybe un moyen visuel d'indiquer ce d�lai entre les vagues ?
    }
}