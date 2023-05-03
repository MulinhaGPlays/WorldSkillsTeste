using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refatoracao.Models
{
    public class CarrinhoDeCompras
    {
        public CarrinhoDeCompras() => Produtos = new List<Produto>();

        public List<Produto> Produtos { get; private set; }

        public void Adiciona(Produto produto) => Produtos.Add(produto);
    }
}
