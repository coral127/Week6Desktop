using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.0f; //moveSpeed값 초기화
    [SerializeField] 
    private Vector3 moveDirection = Vector3.zero; //Vector3은 3d, Vector2sms 2D에 유용, 2D에선 상관없는듯
                                                  //Vector3 초기화 Vector3.zero = (0,0,0)  
    public float MoveSpeed => moveSpeed;        //moveSpeed 변수의 프로퍼티(property) (Get가능)  //자동 구현 속성 
                                                //moveSpeed는 private이지만 Get으로 가져올 수 있음. //MoveSpeed를 호출했을 때 moveSpeed의 값을 반환
    //moveSpeed와 MoveSpeed의 관계는 변수(Field)와 속성(Property)의 관계임. moveSpeed는 클래스 내부에서만 접근 가능한 실제 데이터 저장 변수
    //MoveSpeed: 외부에서 읽을 수 있게 만든 읽기 전용 속성(get), MoveSpeed는 moveSpeed의 읽기버전.
    private void Update() //Update를 사용해 
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;   //moveSpeed는 코드 내에서, MoveSpeed는 코드 밖에서 사용
                                                                            //MoveSpeed를 사용해도 되지만 구분을 위해서
    }

    //MoveTo함수를 호출하면 Vector3 타입의 매개변수 direction의 값을 moveDirection에 할당한다.
    public void MoveTo(Vector3 direction) //MoveTo는 Vector3타입의 direction을 매개변수로 받음.
    {                                                
        moveDirection = direction; // =의 왼쪽 변수가 값을 받는 쪽, 오른쪽에 있는 변수가 값을 주는 쪽
    }                              // Vector3타입의 direction값을 moveDirection에 할당함. 
}       

/*
 * File : Movement2D.cs
 * Desc
 *  : 이동이 가능한 모든 오브젝트에게 부착
 *  
 *  Functions
 *   : /MoveTo() - 외부에서 호출해 이동 방향을 설정
 *   
 */   