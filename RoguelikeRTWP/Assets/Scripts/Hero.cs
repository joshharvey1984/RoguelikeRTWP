using UnityEngine;

public class Hero : MonoBehaviour {
    private static readonly int WalkDirection = Animator.StringToHash("WalkDirection");
    private void Awake() {
        gameObject.GetComponent<Animator>().SetInteger(WalkDirection, 4);
    }
}