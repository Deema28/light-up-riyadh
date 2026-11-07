using UnityEngine;

public class WaterObstacleMovement : MonoBehaviour
{
    public float moveSpeed=4 ;
    public float destroyX = -12f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
