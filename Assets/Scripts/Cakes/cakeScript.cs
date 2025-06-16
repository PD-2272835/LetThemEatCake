using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cakeScript : MonoBehaviour
{
    public bool atendpoint = false;
    public int type = 1;
    public Transform selftransfrom;
    public Vector3 endlocation;
    public float size = 1;
    public bool buffer = false;

    // Start is called before the first frame update
    void Start()
    {
        //getting the size of the sprite
        size = selftransfrom.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        //checking when it nears the end location
        if (selftransfrom.position.x <= endlocation.x + size && selftransfrom.position.x >= endlocation.x - size && selftransfrom.position.y <= endlocation.y + size && selftransfrom.position.y >= endlocation.y - size)
        {
            atendpoint = true;
            StartCoroutine(reachedEndPoint());
        }
    }

    IEnumerator reachedEndPoint()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject); //destroys itself at the end
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (atendpoint == true && buffer == false)
        {
            if (col.gameObject.tag == "Enemy") //checks for an enemy
            {
                buffer = true;
                enemyHealthScript hitEnemy = col.gameObject.GetComponent<enemyHealthScript>();

                switch(type) //changes the behaviour based on the type of cake
                {
                    case 1: //basic cake
                        hitEnemy.health -= 10;
                        break;
                    case 2: //large cake
                        hitEnemy.health -= 15;
                        break;
                    case 3: //spicy cake
                        hitEnemy.health -= 5;
                        hitEnemy.startDOT();
                        break;
                    case 4: //bouncy cake??
                        break;
                }
            }
        }
    }
}
