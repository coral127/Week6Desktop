using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;
    [SerializeField]
    private EnemySpawner enemySpawner; //현재 맵에 존재하는 적 리스트 정보를 얻기 위해..
    public void SpawnTower(Transform tileTransform)
    {
        Tile tile = tileTransform.GetComponent<Tile>();
        
        //타워 건설 가능 여부 확인
        //1. 현재 타일의 위치에이미 타워가 건설되어 있으면 타워 건설x
        if (tile.IsBuildTower == true)
        {
            return;
        }

        //타워가 건설되어 있음으로 설정
        tile.IsBuildTower = true;
        

        //선택한 타일의 위치에 타워 건설
        GameObject clone = Instantiate(towerPrefab, tileTransform.position, Quaternion.identity); //Quaternion.identity는 회전없음을 의미,쿼터니언 회전, 짐벌락x
                                                                                                  //Instantiate()함수는 게임을 실행하는 중에 게임오브젝트를 생성할 수 있다.
        //타워 무기에 enemySpawner 정보 전달
        clone.GetComponent<TowerWeapon>().Setup(enemySpawner);
    }

}
/*
 * File : TowerSpawner.cs
 * Desc
 *  : 타워 생성 제어
 *  
 *  Functions
 *  : SpawnTower() - 매개변수 위치에 타워 생성
 *  
 */