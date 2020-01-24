using UnityEngine;
using UnityEngine.AI;

[System.Obsolete]
public class Bot : MonoBehaviour
{
    private RaycastHit _hitInfo = default(RaycastHit);
    private NavMeshAgent _navMeshAgent = null;
    private Camera _mainCam = null;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _mainCam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out _hitInfo))
            {
                _navMeshAgent.SetDestination(_hitInfo.point);
            }
        }
    }
}