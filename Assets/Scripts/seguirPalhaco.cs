using UnityEngine;

public class seguirPalhaco : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;

    private Animator anim;
    private SpriteRenderer sr;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (target == null) return;

        Vector2 diff = target.position - transform.position;

        Vector2 direction;
        if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
        {
            direction = new Vector2(Mathf.Sign(diff.x), 0f); 
        }
        else
        {
            direction = new Vector2(0f, Mathf.Sign(diff.y)); 
        }

        transform.position += (Vector3)(direction * speed * Time.deltaTime);

       
        if (direction.y > 0) 
        {
            anim.Play("WalkUp");
        }
        else if (direction.y < 0) 
        {
            anim.Play("andando");
        }
        else if (direction.x != 0) 
        {
            anim.Play("walk_lado");

            sr.flipX = direction.x < 0;
        }
    }
}
