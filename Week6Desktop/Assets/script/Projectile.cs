using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Movement2D movement2D;
    private Transform target;

    public void Setup(Transform target)
    {
        movement2D = GetComponent<Movement2D>();
        this.target = target;
    }
    private void Update()
    {
        if (target != null) //target�� �����ϸ�
        {
            //�߻�ü�� target�� ��ġ�� �̵�
            Vector3 direction = (target.position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        else    //���� ������ target�� �������
        {
            //�߻�ü ������Ʈ ����
            Destroy(gameObject);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return; //���� �ƴ� ���� �ε�����
        if (collision.transform != target) return; //���� target�� ���� �ƴ� ��

        collision.GetComponent<Enemy>().OnDie(); //�� ��� �Լ� ȣ��
        Destroy(gameObject);
    }
}

/* File : Projectile.cs
 * Desc
 *  : Ÿ���� �߻��ϴ� �⺻ �߻�ü�� ����
 *  
 *  Functions
 *   : update() - Ÿ���� �����ϸ� Ÿ�� �������� �̵��ϰ�, Ÿ���� �������� ������ �߻�ü ����
 *   : OnTriggerEnter2D() - Ÿ������ ������ ���� �ε����� �� �Ѵ� ����
 *   
 */
