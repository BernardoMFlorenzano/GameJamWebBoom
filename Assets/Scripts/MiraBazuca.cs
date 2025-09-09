using UnityEngine;
using UnityEngine.Animations;

public class MiraBazuca : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCamera;
    private Transform jogadorTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        jogadorTransform = transform.parent;
    }

    void FixedUpdate()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotacaoMira = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotacaoMira.y, rotacaoMira.x) * Mathf.Rad2Deg;

        if (mousePos.x < jogadorTransform.position.x)
        {
            jogadorTransform.localScale = new Vector3(-1f, 1f, 1f); // esquerda
            transform.rotation = Quaternion.Euler(0, 0, rotZ + 180);
        }

        else
        {
            jogadorTransform.localScale = new Vector3(1f, 1f, 1f);   // direita
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }

    }
}
