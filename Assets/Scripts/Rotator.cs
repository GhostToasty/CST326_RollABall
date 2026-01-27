using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //rotates object on x, y, z axises
        transform.Rotate(new Vector3 (15, 30, 45) * Time.deltaTime);
    }
}
