using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip blockBreakingSoundClip;
    [SerializeField] private GameObject blockSparklesVFX;
    [SerializeField] private int maxHits;
    [SerializeField] private Sprite[] damageBlockSprites;

    private BlockManager blockManager;

    [SerializeField] private int timesHit;

    private void Awake()
    {
        blockManager = FindObjectOfType<BlockManager>();
    }

    private void Start()
    {
        if(tag == "Breakable")
        {
            blockManager.AddToBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            int damageSpriteIndex = timesHit - 1;
            GetComponent<SpriteRenderer>().sprite = damageBlockSprites[damageSpriteIndex];
        }
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameSession>().AddToScore();
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