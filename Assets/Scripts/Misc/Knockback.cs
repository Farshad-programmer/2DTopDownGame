using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    private Rigidbody2D rb;

    public bool GetingKnockback { get; private set; }
    [SerializeField] private float knockbackTime = 0.2f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void GetKnockback(Transform damageSource,float knockbackThrust)
    {
        GetingKnockback = true;
        Vector2 difference = (transform.position - damageSource.position).normalized * knockbackThrust * rb.mass; // mass vase ine ke object har bar motefavot add force kone
        rb.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine(KnockRoutine());
    }

    private IEnumerator KnockRoutine()
    {
        yield return new WaitForSeconds(knockbackTime);
        rb.velocity = Vector2.zero;
        GetingKnockback = false;
    }
}
