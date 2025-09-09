using UnityEngine;

public class MovimentoFoguete : MonoBehaviour
{
    [SerializeField] private float velFoguete = 15f;
    private Rigidbody2D rb;
    private Vector3 mousePos;
    private Camera mainCamera;

    [SerializeField] private GameObject explosao;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rotacaoMira = mousePos - transform.position;
        rotacaoMira.Normalize();
        rb.AddForce(rotacaoMira * velFoguete, ForceMode2D.Impulse);
        Debug.Log(rotacaoMira);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo"))
        {
            Instantiate(explosao, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
