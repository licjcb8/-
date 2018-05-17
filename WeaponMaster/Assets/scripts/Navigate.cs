using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Navigate : MonoBehaviour {
    public Transform m_Target;
    public float m_fMinDist = 5;
    NavMeshAgent m_cNavMeshAgent;
    float m_fDist = 0;
	// Use this for initialization
	void Start () {
        m_cNavMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        TracingTarget();
	}

    void TracingTarget()
    {
        Vector3 vTargetPos = m_Target.position;
        Vector3 vPos = transform.position;

        m_fDist = Vector3.Distance(vTargetPos, vPos);

        if (m_fDist > m_fMinDist)
            m_cNavMeshAgent.SetDestination(vTargetPos);
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 20), "Dist:" + m_fDist);
    }

}
