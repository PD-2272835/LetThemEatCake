using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeProjectile : MonoBehaviour
{
    private Vector2 endPos;
    private bool atEndPos = false;
    
    public CakeData type;

    public float size = 1;
    public bool buffer = false;

    // Start is called before the first frame update
    void Start()
    {
        //getting the size of the sprite
        size = transform.localScale.x;
    }
    

    void Update()
    {
        //check for when this projectile reaches the target position
        if (transform.position.x <= endPos.x + size && transform.position.x >= endPos.x - size && transform.position.y <= endPos.y + size && transform.position.y >= endPos.y - size)
        {
            atEndPos = true;
            StartCoroutine(EndPointReached());
        }

        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator EndPointReached()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (atEndPos && !buffer)
        {
            if (col.CompareTag("Enemy")) //checks for an enemy
            {
                buffer = true;
                var hitEnemy = col.gameObject.GetComponent<Enemy_Parent>();

                hitEnemy.Hit(type.GetHitData());
            }
        }
    }

    public void SetLandingPosition(Vector2 landingPosition)
    {
        endPos = landingPosition;
    }
}
