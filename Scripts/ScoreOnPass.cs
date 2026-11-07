using UnityEngine;

public class ScoreOnPass : MonoBehaviour
{
    private Transform player;
    private bool scored = false;


    void Start()
    {
        PlayerMovement playerMovement =
            FindFirstObjectByType<PlayerMovement>();

        if (playerMovement != null)
        {
            player = playerMovement.transform;
        }
    }

    void Update()
    {
        if (scored || player == null || Time.timeScale == 0f)
            return;

        if (transform.position.x < player.position.x)
        {
            scored = true;

            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddPoint();
            }
        }
    }
}