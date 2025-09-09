using UnityEngine;

public class MovimentoInimigo : MonoBehaviour
{
    [SerializeField] private float inimigoVel = 100f;
    private Rigidbody2D rb;
    private Vector2 direcao;
    private Transform caraTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        caraTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        direcao = caraTransform.position - transform.position;
        rb.linearVelocity = direcao.normalized * inimigoVel * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Explosao"))
            Destroy(gameObject);
    }
}
