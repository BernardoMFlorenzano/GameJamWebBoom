using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Movimento : MonoBehaviour
{
    [SerializeField] private float vel = 5f;
    private Rigidbody2D rb;
    private Vector2 direcao;
    private Animator animator;
    private AtiraFoguete atirador;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        atirador = GetComponentInChildren<AtiraFoguete>();
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            Debug.Log("Saiu do jogo");
            Application.Quit();
        }

    }

    void FixedUpdate()
    {

        rb.linearVelocity = direcao * vel * Time.deltaTime;
        if (rb.linearVelocity != Vector2.zero)
        {
            animator.SetBool("Movendo", true);
        }
        else
            animator.SetBool("Movendo", false);
    }

    void OnMove(InputValue inputValue)
    {
        direcao = inputValue.Get<Vector2>();
    }

    void OnInteract()
    {
        Debug.Log("Saiu do jogo");
        Application.Quit();
    }

    void OnAttack()
    {
        atirador.Atira();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Explosao") || collision.CompareTag("Inimigo"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

}
