using System.Collections;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab; //�� ������
    [SerializeField]
    private float spawnTime; //�� ���� �ֱ�
    [SerializeField]
    private Transform[] wayPoints; //���� ���������� �̵� ���

    private void Awake()
    {
        //�� ���� �ڷ�ƾ �Լ� ȣ��
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject clone = Instantiate(enemyPrefab); //�� ������Ʈ ����
            enemy Enemy = clone.GetComponent<enemy>(); //��� ������ ���� enemy������Ʈ

            Enemy.Setup(wayPoints); //wayPoint�������Ű������� Setup() ȣ��

            yield return new WaitForSeconds(spawnTime); // spawnTime �ð� ���� ���
        }
    }
}
