using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    int tX;
    private bool ded;
    private float timer;
    Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        tX = (int)GameObject.Find("Player").transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (ded)
            timer += Time.deltaTime;
        if (timer > 0.2)
            Destroy(this.gameObject);
        transform.Translate(new Vector2(tX * speed * Time.deltaTime, 0));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        myAnimator.SetBool("Coll", true);
        speed = 0;
        ded = true;
    }
}
