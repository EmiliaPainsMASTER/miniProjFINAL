using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    private Vector3 _offset = new (6, 5, -15);

    void LateUpdate() {
        // Check if the player reference is valid
        if (player != null) {
            transform.position = player.position + _offset;
        } else {
            
        }
    }
}