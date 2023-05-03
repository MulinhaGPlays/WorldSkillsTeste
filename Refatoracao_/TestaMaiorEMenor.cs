using Refatoracao.Models;
using System;

namespace Refatoracao
{
    public class TestaMaiorEMenor
    {
        static void Main(string[] args)
        {
            CarrinhoDeCompras carrinho = new CarrinhoDeCompras();
            MaiorEMenor algoritmo = new MaiorEMenor();

            carrinho.Adiciona(new Produto("Liquidificador", 250.0));
            carrinho.Adiciona(new Produto("Geladeira", 450.0));
            carrinho.Adiciona(new Produto("Jogo de pratos", 70.0));

            algoritmo.Encontra(carrinho);

            Console.WriteLine($"O menor produto: {algoritmo.Menor.Nome}");
            Console.WriteLine($"O maior produto: {algoritmo.Maior.Nome}");
            Console.ReadKey();
        }
    }
}