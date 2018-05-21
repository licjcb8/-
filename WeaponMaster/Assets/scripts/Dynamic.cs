using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic : MonoBehaviour {
    public float m_fSpeed = 10.0f;

    float m_fMoveDist = -1; //이동할 거리
    float m_fMovedDist = 0; //이동할 위치까지 이동된 거리

    // Use this for initialization
    void Start () {

    }

    void InputProcess()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //마우스의 2D좌표를 이용하여 광선 생성(광선시작위치,광선방향)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo; //충돌이 성공했을때 충돌된 물체의 정보
            float fDistace = 100; //충돌체크용(광선길이)
            //광선의 길이 안에 물체가 있다면 hitInfo에 저장된다.
            if (Physics.Raycast(ray, out hitInfo, fDistace))
            {
                Vector3 vPos = this.transform.position;
                Vector3 vRayFickingPos = hitInfo.point;

                //이동할방향 = 이동할위치 - 현재위치 
                Vector3 vDir = vRayFickingPos - vPos;
                m_fMoveDist = vDir.magnitude; //이동할 위치와 거리를 구함.
                m_fMovedDist = 0; //이동한 거리를 0으로 초기화한다.

                //마우스를 찍은 위치 바라보기
                transform.LookAt(vRayFickingPos);
                ////오일러의 각을 이용하여 회전하기
                //vDir.Normalize();
                //Quaternion q = Quaternion.LookRotation(vDir);
                //transform.rotation = Quaternion.Euler(0, q.eulerAngles.y,0);
            }
        }
    }

    void MoveProcess(float time)
    {
        //이동할 거리가 0보다 클때까지 이동시킨다.
        if (m_fMoveDist >= 0)
        {
            //물체가 바라보는 방향으로 이동속도만큼 이동시킨다.
            Vector3 vMove = Vector3.forward * m_fSpeed * time;
            transform.Translate(vMove);
            //이동한 물체의 거리를 누적하여 저장한다.
            m_fMovedDist += vMove.magnitude;
            //이동한 거리가 이동할거리보다 커지면 이동을 중지시킨다.
            if (m_fMovedDist > m_fMoveDist)
                m_fMoveDist = -1; //-1을 이용하여 이동하지않도록한다.
        }
    }

	// Update is called once per frame
	void Update () {
        InputProcess();
        MoveProcess(Time.deltaTime);
    }
}
