using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip blockBreakingSoundClip;
    [SerializeField] private GameObject blockSparklesVFX;

    private BlockManager blockManager;

    private void Awake()
    {
        blockManager = FindObjectOfType<BlockManager>();
    }
    private void Start()
    {
        blockManager.AddToBlockCount();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameSession>().AddToScore();
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(blockBreakingSoundClip, Camera.main.transform.position);
        blockManager.SubtractFromBlockCount();
        TriggerSparklesVFX();
        Destroy(gameObject);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}