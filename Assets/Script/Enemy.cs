using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    private Transform playerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if(playerObject == null)
        {
            playerObject = FindObjectOfType<GameObject>();

        }
        if(playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.Log("no player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Audio.instance.PlayDieClip();
            GameManager.instance.EnemySkillPlayer();
            collision.gameObject.SetActive(false);
        }
        if(collision.tag == "Bullet")
        {
            GameManager.instance.addScore(1);
            Destroy(gameObject);
        }
    }
}
