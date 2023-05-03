using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refatoracao.Models
{
    public class MaiorEMenor
    {
        public Produto Menor { get; private set; } = null;
        public Produto Maior { get; private set; } = null;

        public void Encontra(CarrinhoDeCompras carrinho)
        {
            var produtos = carrinho.Produtos;
            Maior = produtos.OrderByDescending(x => x.Valor).First();
            Menor = produtos.OrderBy(x => x.Valor).First();
        }
    }
}
