using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class Ship : MonoBehaviour
    {
        public GameObject projectilePrefab;
        public Image imageHealthBar;

        public float firingDelay = 1f;
        public float healthMax = 100f;
        public float health = 100f;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine("FiringTimer");

        }

        // Update is called once per frame
        void Update()
        {
            if (health > 0)
            {
                float yPosition = Mathf.Sin(GameController.instance.timeElapsed) * 3f;
                transform.position = new Vector2(0, yPosition);
            }
        }

        void Die()
        {
            StopCoroutine("FiringTimer");
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            
        }
        void FireProjectile()
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }

        IEnumerator FiringTimer()
        {
            yield return new WaitForSeconds(firingDelay);

            FireProjectile();

            StartCoroutine("FiringTimer");

        }
    }
}