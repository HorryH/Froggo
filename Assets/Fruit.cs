using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    public GameObject fruitSlicedPrefab;
    public static int score = 0;
    public static int combo = 0;
    public float startForce = 15f;
    public bool sliced = false;

    Rigidbody2D rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {
            Vector3 direction = (col.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
            sliced = true;
            Destroy(gameObject);
            Destroy(slicedFruit, 5f);
            score+= getMultiplier();
            combo++;
        }
    }

    private void OnDestroy()
    {
        if (sliced)
        {
        } else
        {
            combo = 0;
        }
    }

    public int getScore()
    {
        return score;
    }

    public int getCombo()
    {
        return combo;
    }

    public int getMultiplier()
    {
        return (int) (combo / 4) + 1;
    }
}
