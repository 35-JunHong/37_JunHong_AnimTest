using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator playerAnim;

    float speed = 20.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //forward
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            playerAnim.SetBool("isStrafe", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.SetBool("isStrafe", false);
        }

        //attack
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.SetBool("isAttack", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerAnim.SetBool("isAttack", false);
        }
    }

    //collision on cube
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("Barrier"))
        {
            playerAnim.SetTrigger("trigDeath");
        }
    }
}
