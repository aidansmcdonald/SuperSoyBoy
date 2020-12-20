using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public GameObject playerDeathPrefab;
    public AudioClip deathClip;
    public Sprite hitSprite;
    private SpriteRenderer spriteRenderer;



    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Check object has player tag
        if (coll.transform.tag == "Player")
        {
            // Determine is audioclip has been assigned to the script and that it exists, if so play sound effect
            var audioSource = GetComponent<AudioSource>();
            if (audioSource != null && deathClip != null)
            {
                audioSource.PlayOneShot(deathClip);
            }
            // Instantiate the death prefab at the collision point and swap saw sprite for new sprite
            Instantiate(playerDeathPrefab, coll.contacts[0].point,
            Quaternion.identity);
            spriteRenderer.sprite = hitSprite;
            // Destroy colliding object (player)
            Destroy(coll.gameObject);

            GameManager.instance.RestartLevel(1.25f);
        }
    }
}
