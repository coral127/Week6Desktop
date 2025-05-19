using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;
    [SerializeField]
    private EnemySpawner enemySpawner; //���� �ʿ� �����ϴ� �� ����Ʈ ������ ��� ����..
    public void SpawnTower(Transform tileTransform)
    {
        Tile tile = tileTransform.GetComponent<Tile>();
        
        //Ÿ�� �Ǽ� ���� ���� Ȯ��
        //1. ���� Ÿ���� ��ġ���̹� Ÿ���� �Ǽ��Ǿ� ������ Ÿ�� �Ǽ�x
        if (tile.IsBuildTower == true)
        {
            return;
        }

        //Ÿ���� �Ǽ��Ǿ� �������� ����
        tile.IsBuildTower = true;
        

        //������ Ÿ���� ��ġ�� Ÿ�� �Ǽ�
        GameObject clone = Instantiate(towerPrefab, tileTransform.position, Quaternion.identity); //Quaternion.identity�� ȸ�������� �ǹ�,���ʹϾ� ȸ��, ������x
                                                                                                  //Instantiate()�Լ��� ������ �����ϴ� �߿� ���ӿ�����Ʈ�� ������ �� �ִ�.
        //Ÿ�� ���⿡ enemySpawner ���� ����
        clone.GetComponent<TowerWeapon>().Setup(enemySpawner);
    }

}
/*
 * File : TowerSpawner.cs
 * Desc
 *  : Ÿ�� ���� ����
 *  
 *  Functions
 *  : SpawnTower() - �Ű����� ��ġ�� Ÿ�� ����
 *  
 */