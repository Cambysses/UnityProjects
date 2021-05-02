using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] int hitpoints = 1;
    [SerializeField] Sprite[] damageSprites;
    [SerializeField] AudioClip destructionSound;
    [SerializeField] int blockPointsValue = 150;
    [SerializeField] GameObject particleEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            DamageBlock();
        }
    }

    private void TriggerParticleEffect()
    {
        Vector3 particleVector = new Vector3(transform.position.x, transform.position.y, (transform.position.z - 9));
        GameObject particleInstance = Instantiate(particleEffect, particleVector, transform.rotation);
        Destroy(particleInstance, 1f);
    }

    private void UpdateSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (hitpoints > 1)
        {
             spriteRenderer.sprite = damageSprites[0];
        }
        else
        {
             spriteRenderer.sprite = damageSprites[1];
        }
    }

    private void DamageBlock()
    {
        hitpoints--;
        UpdateSprite();

        // Destroy block.
        if (hitpoints == 0)
        {
            AudioSource.PlayClipAtPoint(destructionSound, Camera.main.transform.position);
            TriggerParticleEffect();
            Destroy(gameObject);
            FindObjectOfType<GameSession>().AddToScore(blockPointsValue);
            FindObjectOfType<Level>().CountBlocks();
        }
    }
}
