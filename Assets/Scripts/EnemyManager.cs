using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private List<EnemyScript> enemies = new List<EnemyScript>();
    [SerializeField] private List<GameObject> _spawnPoints = new List<GameObject>();
    [SerializeField] private List<GameObject> _possibleEnemies = new List<GameObject>();
    
    private List<int> enemyIndexes;

    [Header("Main AI Loop - Settings")]
    private Coroutine AI_Loop_Coroutine;

    public int aliveEnemyCount;
    void Start()
    {
        StartCoroutine(StartSpawningEnemies());
    }

    IEnumerator StartSpawningEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            int spawnIndex = Random.Range(0, _spawnPoints.Count);
            int enemyIndex = Random.Range(0, _possibleEnemies.Count);
            GameObject newEnemy = Instantiate(_possibleEnemies[enemyIndex], _spawnPoints[spawnIndex].transform.position, _possibleEnemies[enemyIndex].transform.rotation);
            StartCoroutine(AI_Loop(newEnemy.GetComponent<EnemyScript>()));
        }
    }

    IEnumerator AI_Loop(EnemyScript enemy)
    {
        yield return new WaitForSeconds(Random.Range(.5f,1.5f));
        
            
        yield return new WaitUntil(()=>enemy.IsRetreating() == false);
        yield return new WaitUntil(() => enemy.IsLockedTarget() == false);
        yield return new WaitUntil(() => enemy.IsStunned() == false);

        enemy.SetAttack();

        yield return new WaitUntil(() => enemy.IsPreparingAttack() == false);

        enemy.SetRetreat();

        yield return new WaitForSeconds(Random.Range(0,.5f));

        StartCoroutine(AI_Loop(enemy));
    }
}

[System.Serializable]
public struct EnemyStruct
{
    public EnemyScript enemyScript;
    public bool enemyAvailability;
}
