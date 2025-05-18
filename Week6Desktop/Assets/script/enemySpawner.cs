using System.Collections;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab; //적 프리팹
    [SerializeField]
    private float spawnTime; //적 생성 주기
    [SerializeField]
    private Transform[] wayPoints; //현재 스테이지의 이동 경로

    private void Awake()
    {
        //적 생성 코루틴 함수 호출
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject clone = Instantiate(enemyPrefab); //적 오브젝트 생성
            enemy Enemy = clone.GetComponent<enemy>(); //방금 생성된 적의 enemy컴포넌트

            Enemy.Setup(wayPoints); //wayPoint정보를매개변수로 Setup() 호출

            yield return new WaitForSeconds(spawnTime); // spawnTime 시간 동안 대기
        }
    }
}
