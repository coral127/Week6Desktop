using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.0f; //moveSpeed�� �ʱ�ȭ
    [SerializeField] 
    private Vector3 moveDirection = Vector3.zero; //Vector3�� 3d, Vector2sms 2D�� ����, 2D���� ������µ�
                                                  //Vector3 �ʱ�ȭ Vector3.zero = (0,0,0)  
    public float MoveSpeed => moveSpeed;        //moveSpeed ������ ������Ƽ(property) (Get����)  //�ڵ� ���� �Ӽ� 
                                                //moveSpeed�� private������ Get���� ������ �� ����. //MoveSpeed�� ȣ������ �� moveSpeed�� ���� ��ȯ
    //moveSpeed�� MoveSpeed�� ����� ����(Field)�� �Ӽ�(Property)�� ������. moveSpeed�� Ŭ���� ���ο����� ���� ������ ���� ������ ���� ����
    //MoveSpeed: �ܺο��� ���� �� �ְ� ���� �б� ���� �Ӽ�(get), MoveSpeed�� moveSpeed�� �б����.
    private void Update() //Update�� ����� 
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;   //moveSpeed�� �ڵ� ������, MoveSpeed�� �ڵ� �ۿ��� ���
                                                                            //MoveSpeed�� ����ص� ������ ������ ���ؼ�
    }

    //MoveTo�Լ��� ȣ���ϸ� Vector3 Ÿ���� �Ű����� direction�� ���� moveDirection�� �Ҵ��Ѵ�.
    public void MoveTo(Vector3 direction) //MoveTo�� Vector3Ÿ���� direction�� �Ű������� ����.
    {                                                
        moveDirection = direction; // =�� ���� ������ ���� �޴� ��, �����ʿ� �ִ� ������ ���� �ִ� ��
    }                              // Vector3Ÿ���� direction���� moveDirection�� �Ҵ���. 
}       

/*
 * File : Movement2D.cs
 * Desc
 *  : �̵��� ������ ��� ������Ʈ���� ����
 *  
 *  Functions
 *   : /MoveTo() - �ܺο��� ȣ���� �̵� ������ ����
 *   
 */   