using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaPulo = 20f;

    public float limiteEsquerdo = -10f;
    public float limiteDireito = 10f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private int pulosRestantes;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        pulosRestantes = 2;
    }

    void Update()
    {
        // Movimento A e D
        float movimento = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(
            movimento * velocidade,
            rb.linearVelocity.y
        );

        // ANIMAÇÃO
        // Andando = run
        // Parado = Idle
        animator.SetBool("IsRunning", movimento != 0);

        // Vira o personagem para direita/esquerda
        if (movimento > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movimento < 0)
        {
            spriteRenderer.flipX = true;
        }

        // Pulo + pulo duplo
        if (Input.GetKeyDown(KeyCode.Space) && pulosRestantes > 0)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                forcaPulo
            );

            pulosRestantes--;
        }

        // Limites laterais do mapa
        Vector3 posicao = transform.position;

        posicao.x = Mathf.Clamp(
            posicao.x,
            limiteEsquerdo,
            limiteDireito
        );

        transform.position = posicao;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Só verifica objetos com a tag Chao
        if (!collision.gameObject.CompareTag("Chao"))
        {
            return;
        }

        // Só recupera os pulos quando estiver EM CIMA do chão
        foreach (ContactPoint2D contato in collision.contacts)
        {
            if (contato.normal.y > 0.5f)
            {
                pulosRestantes = 2;
                break;
            }
        }
    }

    // Usado quando vai para outro mapa
    public void TrocarLimites(float novoEsquerdo, float novoDireito)
    {
        limiteEsquerdo = novoEsquerdo;
        limiteDireito = novoDireito;
    }
}