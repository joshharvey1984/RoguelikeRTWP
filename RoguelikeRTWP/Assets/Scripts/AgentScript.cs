using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour {
    [SerializeField] private Transform target;

    private Vector3 _targetPosition;
    private NavMeshAgent _agent;
    

    private void Start() {
        if (!gameObject.CompareTag("Player")) SetTarget(GameObject.FindGameObjectWithTag("Player").transform);
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update() {
        _agent.SetDestination(_targetPosition);
    }

    public void SetTarget(Vector3 targetPosition) {
        _targetPosition = targetPosition;
    }

    public void SetTarget(Transform targetTransform) {
        target = targetTransform;
        _targetPosition = target.position;
    }
}