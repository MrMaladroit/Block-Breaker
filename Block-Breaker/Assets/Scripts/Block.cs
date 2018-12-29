using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip blockBreakingSoundClip;

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
        FindObjectOfType<GameStatus>().AddToScore();
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(blockBreakingSoundClip, Camera.main.transform.position);
        blockManager.SubtractFromBlockCount();
        Destroy(gameObject);
    }
}