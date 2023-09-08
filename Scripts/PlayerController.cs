using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject gun;
    public ParticleSystem deathEffect;
    private float playerSpeed = 10;
    private Rigidbody rb;

    public AudioSource explosionSFX;

    FadeInOut fade;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        fade = FindObjectOfType<FadeInOut>();
        fade.FadeOut();
    }
    void Update()
    {
        OnMove();
        MoveSpeed();
    }

    // Making the player movement input
    void OnMove()
    {
        // when A is pressed, the player moves left 2 units
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -4)
        {
            transform.position += Vector3.left;
        }
        // when D is pressed, the player moves right 2 units
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 4)
        {
            transform.position += Vector3.right;
        }
    }
    // Making the player move forwards
    void MoveSpeed()
    {
        if (rb.velocity.z < playerSpeed)
        {
            rb.AddForce(0, 0, playerSpeed);
        }
    }
    // adding collisions
    private void OnCollisionEnter(Collision collision)
    {
        // If the player hits an obstacle, loss screen will be loaded
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(Die());
        }
        // If the player hits the finish line, victory screen will be loaded
        if(collision.gameObject.CompareTag("Finish"))
        {
            StartCoroutine(Finish());
        }
    }
    // Die function activates death effects and loads loss screen
    public IEnumerator Die()
    {
        fade.FadeIn();
        explosionSFX.Play();
        deathEffect.Play();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gun.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Loss_Screen");
    }
    // Finish function loads victory screen
    public IEnumerator Finish()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Victory_Screen");
    }
}
