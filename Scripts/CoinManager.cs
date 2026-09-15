using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public TMP_Text textoMoedas;

    private int moedas = 0;

    void Start()
    {
        AtualizarTexto();
    }

    // Adiciona moedas ao contador
    // Moeda normal = 1
    // Saco de dinheiro = 10
    public void AdicionarMoeda(int quantidade = 1)
    {
        moedas += quantidade;
        AtualizarTexto();
    }

    // Zera o contador quando o Player morre
    public void ReiniciarContador()
    {
        moedas = 0;
        AtualizarTexto();
    }

    // Atualiza o texto na tela
    private void AtualizarTexto()
    {
        if (textoMoedas != null)
        {
            textoMoedas.text = "Moedas: " + moedas;
        }
    }
}