using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refatoracao.Models;
using System;

namespace RefatoracaoTeste
{
    [TestClass]
    public class TesteDeOrdens
    {
        [TestMethod]
        public void TesteOrdemCrescenteCarrinhoFunciona()
        {
            CarrinhoDeCompras carrinho = new CarrinhoDeCompras();
            MaiorEMenor algoritmo = new MaiorEMenor();

            carrinho.Adiciona(new Produto("Liquidificador", 250.0));
            carrinho.Adiciona(new Produto("Geladeira", 450.0));
            carrinho.Adiciona(new Produto("jogos de prato", 70.0));

            algoritmo.Encontra(carrinho);

            Assert.AreEqual(algoritmo.Menor.Nome, "jogos de prato");
        }

        [TestMethod]
        public void TesteOrdemDecrescenteFunciona()
        {
            CarrinhoDeCompras carrinho = new CarrinhoDeCompras();
            MaiorEMenor algoritmo = new MaiorEMenor();

            carrinho.Adiciona(new Produto("Geladeira", 450.0));
            carrinho.Adiciona(new Produto("Liquidificador", 250.0));
            carrinho.Adiciona(new Produto("jogos de prato", 70.0));

            algoritmo.Encontra(carrinho);

            Assert.AreEqual(algoritmo.Maior.Nome, "Geladeira");
        }
    }
}
