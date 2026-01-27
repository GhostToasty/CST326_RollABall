using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //calculates offset between position between camera and player 
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame, but at the very end of the code running
    void LateUpdate()
    {
        //offsets camera by position only 
        transform.position = player.transform.position + offset;
    }
}
