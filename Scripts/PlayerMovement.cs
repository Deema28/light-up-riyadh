
using UnityEngine;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public Sprite flameOutSprite;
    public AudioSource audioSource;
    public AudioClip extinguishSound;
    public AudioClip gameOverSound;
    private SpriteRenderer spriteRenderer;
    private bool isDead = false;

    public GameObject gameOverPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flapStrength = PlayerPrefs.GetInt("Difficulty", 0) == 1 ? 3.2f : 2.5f;
        Time.timeScale = 1f;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        if (other.GetComponentInParent<WaterObstacleMovement>() != null)
        {
            isDead = true;
            spriteRenderer.sprite = flameOutSprite;
            if (audioSource != null && extinguishSound != null)
            {
                audioSource.PlayOneShot(extinguishSound);
            }
            myRigidbody.linearVelocity = Vector2.zero;

            Time.timeScale = 0f;
            StartCoroutine(ShowGameOver());
        }
    }
    IEnumerator ShowGameOver()
    {
        float waitTime = extinguishSound != null
            ? extinguishSound.length : 1f;

        yield return new WaitForSecondsRealtime(waitTime);

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (audioSource != null && gameOverSound != null)
        {
            audioSource.PlayOneShot(gameOverSound);
        }
    }

}
