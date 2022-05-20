using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleMovement : MonoBehaviour
{
    public AudioSource swingAudio;
    public AudioSource pointAudio;
    public AudioSource crushAudio;
    public float rotate = 10f;
    GameManager gameManager;
    // Update is called once per frame
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        gameObject.transform.Rotate(0f, 0f, rotate * Time.deltaTime * 10f);
        if (Input.GetKeyDown(KeyCode.A))
        {
            swingAudio.Play();
            rotate = rotate * -1f;
        }
        
    }
    IEnumerator WaitForReload()
    {
        crushAudio.Play();
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(WaitForReload());
            
        }
        if (collision.gameObject.CompareTag("Point"))
        {
            pointAudio.Play();
            Destroy(collision.gameObject);
            gameManager.score++;
        }
    }
    
}
