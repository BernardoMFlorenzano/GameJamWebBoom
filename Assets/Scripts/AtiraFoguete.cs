using System.Collections;
using UnityEngine;

public class AtiraFoguete : MonoBehaviour
{
    [SerializeField] private Transform pontaBazuca;
    [SerializeField] private GameObject foguete;
    [SerializeField] private float delayTiro = 3f;
    private bool podeAtacar = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Atira()
    {
        if (podeAtacar)
        {
            podeAtacar = false;
            StartCoroutine(DelayTiro());
            Instantiate(foguete, pontaBazuca.position, transform.rotation).GetComponent<Rigidbody2D>();
        }
    }

    IEnumerator DelayTiro()
    {
        yield return new WaitForSeconds(delayTiro);
        podeAtacar = true;
    }
}
