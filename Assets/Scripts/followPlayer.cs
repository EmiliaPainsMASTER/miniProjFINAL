using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    private Vector3 offset = new Vector3(6, 5, -15);  // Adjust the offset if needed

    void LateUpdate() {
        // Update position to follow player with the desired offset
        transform.position = player.position + offset;
        
        // Keep the camera rotation as set in the Inspector
    }
}