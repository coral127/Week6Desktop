using UnityEngine;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEditor;

public class enemy : MonoBehaviour
{
    private int wayPointCount; // 이동 경로 개수
    private Transform[] wayPoints; //이동 경로 정보 //배열형태의 Transform 속성을 갖는 wayPoints 지정.
    private int currentIndex = 0; //현재 목표지점 인덱스
    private Movement2D movement2D; //오브젝트 이동 제어 //Movement2D타입의 movement2D만들기. 이름이 movement2D, Movement2D는 앞서 만든 코드 가져옴.

    public void Setup(Transform[] wayPoints) //함수를 호출하는 쪽에서 Transform[]타입의 데이터를 wayPoints라는 이름의 매개변수를 통해 함수 내부로 전달해주는 것
                                             //이미 Transform[]타입으로 wayPoints를 저장한거 아닌가? 왜 또 쓰는가?
    {                                        //   
        movement2D = GetComponent<Movement2D>(); //movement2D는 Movement2D 스크립트의 성분을 가져온것과 같음.
                                                 //movemebt2D는 이미 위에서 성분을 가져온게 아닌가? Getcomponent를 써야한다면 위에서 작성한 것은 무슨 기능을 하는가?
                                                 //위에 Movement2D movement2D는 변수 지정, GetComponent는 지정한 변수에 Movement2D 성분을 컴포넌트해서 movement2D에 넣음.
                                                 //적 이동 경로 WayPoints 정보 설정
        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        //적의 위치를 첫번째 wayPoint 위치로 설정
        transform.position = wayPoints[currentIndex].position; //transform.position은 절대좌표계

        //적 이동/목표지점 설정 코루틴 함수 시작
        StartCoroutine("OnMove");

    }

    private IEnumerator OnMove()
    {
        //다음이동 방향 설정
        NextMoveTo();

        while (true)
        {
            //적 오브젝트 회전
            transform.Rotate(Vector3.forward * 5);

            //적의 현재위치와 목표위치의 거리가0.02*movement2D.MoveSpeed보다 작을 때 if 조건문 실행
            //Tip. movement2D.MoveSpeed를 곱해주는 이유는 속도가 빠르면한 프레임에 0.02보다 크게 움직이기 때문
            //if 조건문에 걸리지 않고 경로를 탈주하는 오브젝트가 발생할 수 있다.
            if (Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * movement2D.MoveSpeed)
            {
                //다음 이동 방향 설정
                NextMoveTo();
            }

            yield return null;
        }
    }

    private void NextMoveTo()
    {
        //아직 이동할 waypoints가 남아있다면
        if (currentIndex < wayPointCount - 1)
        {
            //적의 위치를 정확하게 목표 위치로 설정
            transform.position = wayPoints[currentIndex].position;
            //이동 방향 설정 => 다음 목표지점(wayPoints)
            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        //현재 위치가 마지막 wayPoints이면
        else
        {
            //적 오브젝트 삭제
            Destroy(gameObject);
        }
    }
}
