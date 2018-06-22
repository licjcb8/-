using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAttack : MonoBehaviour {
    public Transform m_Target;
    public float m_fMinDist = 5;
    NavMeshAgent m_cNavMeshAgent;
    float m_fDist = 0;

    public GameObject bullet;
    public Transform firePos;
    public float accumulator = 0.0f;
    public int cooltimedone = 0;
    public float cooltime = 0.5f;
    // Use this for initialization
    void Start()
    {
        m_cNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooltimedone == 0)
        {
            accumulator += Time.deltaTime;
            if (accumulator >= cooltime)
            {
                cooltimedone = 1;
                accumulator = 0.0f;
            }
        }
        TracingTarget();
      
       
    }

    void TracingTarget()
    {
        m_Target = GameManager.GetInstance().m_cPlayer.transform;
        Vector3 vTargetPos = m_Target.position; 
        Vector3 vPos = transform.position;

        m_fDist = Vector3.Distance(vTargetPos, vPos);

        if (m_fDist < m_fMinDist)
        {
            m_cNavMeshAgent.SetDestination(vTargetPos);
            if (cooltimedone == 1)
            {
                Fire();
            }
        }
 
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 20), "Dist:" + m_fDist);
    }

    public void Fire()
    {
        CreateBullet();
        cooltimedone = 0;
    }


    void CreateBullet()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }
}
