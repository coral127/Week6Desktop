using UnityEngine;

public class Tile : MonoBehaviour
{
    //Ÿ�Ͽ� Ÿ���� �Ǽ��Ǿ� �ִ��� �˻��ϴ� ����
    public bool IsBuildTower { set; get; } //�ڵ� ���� ������Ƽ

    private void Awake()
    {
        IsBuildTower = false;
    }

}

/*
 * File : Tile.cs
 * Desc
 * : Ÿ�� ��ġ�� ������ TileWall ������Ʈ�� ����
 * 
 */
    

