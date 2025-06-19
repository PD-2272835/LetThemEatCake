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

    //call this method to initialize the thrown object upon instance
    public void Initialize(Vector2 landingPosition, CakeData cakeData)
    {
        endPos = landingPosition;
        type = cakeData;
        GetComponent<SpriteRenderer>().sprite = type.sprite;
        size = transform.localScale.x; //getting the size of the sprite
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

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("CALL");
        if (!buffer)
        {
            if (col.gameObject.tag == "Enemy") //checks for an enemy
            {
                Debug.Log("ENEMY");
                buffer = true;
                var hitEnemy = col.gameObject.GetComponent<Enemy_Parent>();

                hitEnemy.Hit(type.GetHitData());
                Destroy(this.gameObject);
            }
        }
    }
}
