using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab; //�� ������
    [SerializeField]
    private GameObject enemyHPSliderPrefab;
    [SerializeField]
    private Transform canvasTransform;
    [SerializeField]
    private float spawnTime; //�� ���� �ֱ�
    [SerializeField]
    private Transform[] wayPoints; //���� ���������� �̵� ���
    [SerializeField]
    private PlayerHP playerHP;
    private List<Enemy> enemyList; //���� �ʿ� �����ϴ� ��� ���� ����

    //���� ������ ������ EnemySpawner���� �ϱ� ������ Set�� �ʿ����.
    public List<Enemy> EnemyList => enemyList;

    private void Awake()
    {   
        //�� ����Ʈ �޸� �Ҵ�
        enemyList = new List<Enemy>();
        //�� ���� �ڷ�ƾ �Լ� ȣ��
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject clone = Instantiate(enemyPrefab); //�� ������Ʈ ����
            Enemy enemy = clone.GetComponent<Enemy>(); //��� ������ ���� enemy������Ʈ

            enemy.Setup(this,wayPoints); //wayPoint������ �Ű������� Setup() ȣ��
            enemyList.Add(enemy); //����Ʈ�� ��� ������ �� ���� ����

            SpawnEnemyHPSlider(clone);

            yield return new WaitForSeconds(spawnTime); // spawnTime �ð� ���� ���
        }
    }

    public void DestroyEnemy(EnemyDestroyType type, Enemy enemy)
    {

        if (type == EnemyDestroyType.Arrive)
        {
            playerHP.TakeDamage(1);
        }
        //����Ʈ���� ����ϴ� �� ���� ����
        enemyList.Remove(enemy);
        //�� ������Ʈ ����
        Destroy(enemy.gameObject);
    }
    private void SpawnEnemyHPSlider(GameObject enemy)
    {
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);
        sliderClone.transform.SetParent(canvasTransform);
        sliderClone.transform.localScale = Vector3.one;

        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
        sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHP>());
    }
}
