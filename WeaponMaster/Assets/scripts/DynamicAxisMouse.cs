using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicAxisMouse : MonoBehaviour {
    public float m_fHorizontalSpeed = 2.0F;
    public float m_fVerticalSpeed = 2.0F;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void OnGUI()//값의 확인을 위해 OnGUI()에서 사용하였으나, Update에서 처리하는것이 정석이다.
    {
        float fVertical = Input.GetAxis("Mouse Y");
        float fHorizontal = Input.GetAxis("Mouse X");

        float fAbsV = Mathf.Abs(fVertical);
        float fAbSH = Mathf.Abs(fHorizontal);
        bool bCheck = true; //디버깅용

        if (Input.GetMouseButton(0))
        {
            //각 각도의 움직임 같이 일어나는 경우 회전이 혼란스러울수있으므로 한가지 값이 높을때만 적용한다.
            if (fAbsV < fAbSH)
                transform.Rotate(0, m_fHorizontalSpeed * fHorizontal, 0);
            else if (fAbsV > fAbSH)
                transform.Rotate(m_fVerticalSpeed * fVertical, 0, 0);
            else //필요없는 연산일 경우 굳이 처리하는것보다는 하지않는것이 효률적이다.
                bCheck = false;
        }
        GUI.Box(new Rect(0, 0, 300, 100),
                "Vertical:" + fVertical +
                "\nHorizontal:" + fHorizontal +
                "\nChekc:"+bCheck);
    }


}
