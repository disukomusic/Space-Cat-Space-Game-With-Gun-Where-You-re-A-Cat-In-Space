using UnityEngine;


public class Rotate : MonoBehaviour
{
    public float degreesPerSecond;
    void Update()
    {
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);
    }
}
