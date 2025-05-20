using UnityEngine;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEditor;

public enum EnemyDestroyType { Kill = 0, Arrive}

public class Enemy : MonoBehaviour
{
    private int wayPointCount; // �̵� ��� ����
    private Transform[] wayPoints; //�̵� ��� ���� //�迭������ Transform �Ӽ��� ���� wayPoints ����.
    private int currentIndex = 0; //���� ��ǥ���� �ε���
    private Movement2D movement2D; //������Ʈ �̵� ���� //Movement2DŸ���� movement2D�����. �̸��� movement2D, Movement2D�� �ռ� ���� �ڵ� ������.
    private EnemySpawner enemyspawner; // ���� ������ ������ ���� �ʰ� EnemySpawner�� �˷��� ����

    public void Setup(EnemySpawner enemySpawner, Transform[] wayPoints) //�Լ��� ȣ���ϴ� �ʿ��� Transform[]Ÿ���� �����͸� wayPoints��� �̸��� �Ű������� ���� �Լ� ���η� �������ִ� ��
                                             //�̹� Transform[]Ÿ������ wayPoints�� �����Ѱ� �ƴѰ�? �� �� ���°�?
    {                                        //   
        movement2D = GetComponent<Movement2D>(); //movement2D�� Movement2D ��ũ��Ʈ�� ������ �����°Ͱ� ����.
        this.enemyspawner = enemySpawner;                                         //movemebt2D�� �̹� ������ ������ �����°� �ƴѰ�? Getcomponent�� ����Ѵٸ� ������ �ۼ��� ���� ���� ����� �ϴ°�?
                                                 //���� Movement2D movement2D�� ���� ����, GetComponent�� ������ ������ Movement2D ������ ������Ʈ�ؼ� movement2D�� ����.
                                                 //�� �̵� ��� WayPoints ���� ����
        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        //���� ��ġ�� ù��° wayPoint ��ġ�� ����
        transform.position = wayPoints[currentIndex].position; //transform.position�� ������ǥ��

        //�� �̵�/��ǥ���� ���� �ڷ�ƾ �Լ� ����
        StartCoroutine("OnMove");

    }

    private IEnumerator OnMove()
    {
        //�����̵� ���� ����
        NextMoveTo();

        while (true)
        {
            //�� ������Ʈ ȸ��
            transform.Rotate(Vector3.forward * 5);

            //���� ������ġ�� ��ǥ��ġ�� �Ÿ���0.02*movement2D.MoveSpeed���� ���� �� if ���ǹ� ����
            //Tip. movement2D.MoveSpeed�� �����ִ� ������ �ӵ��� �������� �����ӿ� 0.02���� ũ�� �����̱� ����
            //if ���ǹ��� �ɸ��� �ʰ� ��θ� Ż���ϴ� ������Ʈ�� �߻��� �� �ִ�.
            if (Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * movement2D.MoveSpeed)
            {
                //���� �̵� ���� ����
                NextMoveTo();
            }

            yield return null;
        }
    }

    private void NextMoveTo()
    {
        //���� �̵��� waypoints�� �����ִٸ�
        if (currentIndex < wayPointCount - 1)
        {
            //���� ��ġ�� ��Ȯ�ϰ� ��ǥ ��ġ�� ����
            transform.position = wayPoints[currentIndex].position;
            //�̵� ���� ���� => ���� ��ǥ����(wayPoints)
            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        //���� ��ġ�� ������ wayPoints�̸�
        else
        {
            //�� ������Ʈ ����
            //Destroy(gameObject);
            Destroy(gameObject);
            OnDie(EnemyDestroyType.Arrive);
        }
    }

    public void OnDie(EnemyDestroyType type)
    {
        //EnemySpawner���� ����Ʈ���� ������ �����ϱ� ������ Destory()�� �������� �ʰ�
        //EnemySpawner���� ������ ������ �� �ʿ��� ó���� �ϵ��� DestoryEnemy()�Լ� ȣ��
        enemyspawner.DestroyEnemy(type,this);
    }
}
