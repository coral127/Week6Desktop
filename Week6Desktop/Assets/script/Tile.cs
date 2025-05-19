using UnityEngine;

public class Tile : MonoBehaviour
{
    //타일에 타워가 건설되어 있는지 검사하는 변수
    public bool IsBuildTower { set; get; } //자도 구현 프로퍼티

    private void Awake()
    {
        IsBuildTower = false;
    }

}

/*
 * File : Tile.cs
 * Desc
 * : 타워 배치가 가능한 TileWall 오브젝트에 부착
 * 
 */
    

