using System;
using UnityEngine;

public class ClickToMove : MonoBehaviour {
    
    [SerializeField] private float speed = 4;

    private Vector3 _targetPosition;
    private bool _isMoving = false;
    private static readonly int WalkDirection = Animator.StringToHash("WalkDirection");
    private AgentScript _agentScript;

    private void Awake() {
        gameObject.GetComponent<Animator>().SetInteger(WalkDirection, 4);
        _agentScript = GetComponent<AgentScript>();
    }

    void Update() {
        if (Input.GetMouseButtonUp(1)) SetTargetPosition();
        if (_isMoving) Move();
    }

    private void SetTargetPosition() {
        _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _isMoving = true;
    }

    private void Move() {
        if (Vector2.Distance(transform.position, _targetPosition) < 0.1f) {
            gameObject.GetComponent<Animator>().SetInteger(WalkDirection, 4);
            _isMoving = false;
            return;
        }

        _agentScript.SetTarget(_targetPosition);
        
        var diff = _targetPosition - transform.position;
        var angleBetween = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        angleBetween += 45.0f;
        angleBetween %= 360;
        if (angleBetween < 0) angleBetween += 360;
        AngleToAnim((int)angleBetween / 90);
    }

    private void AngleToAnim(int angleBetween) {
        if (angleBetween == 2) {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            angleBetween = 0;
        }
        else {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        gameObject.GetComponent<Animator>().SetInteger(WalkDirection, angleBetween);
    }
}