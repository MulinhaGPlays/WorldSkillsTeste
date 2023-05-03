using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCetafet.Modelo
{
    public class ClienteDAL
    {
        private readonly bdHotelCetafestConexao _conexao;
        public ClienteDAL() => _conexao = new bdHotelCetafestConexao();

        public async Task<List<Profissao>> getClientes() => await _conexao.Profissao.ToListAsync();

        public async Task setCadastrarPais(Cliente novoCliente)
        {
            _conexao.Cliente.Add(novoCliente);
            await _conexao.SaveChangesAsync();
        }

        public async Task<List<Cliente>> getClienteLetraInicial(string iniciais) => await _conexao.Cliente.Where(x => x.nome.StartsWith(iniciais)).ToListAsync();


        public async Task setAtualizar(Cliente cliente)
        {

            _conexao.Entry(cliente).State = EntityState.Modified;
            await _conexao.SaveChangesAsync();
        }

        public async Task<Cliente> getProfissao(int codigo) => await _conexao.Cliente.Where(x => x.codigo == codigo).FirstOrDefaultAsync();

        public async Task setApagar(Cliente cliente)
        {
            _conexao.Cliente.Remove(cliente);
            await _conexao.SaveChangesAsync();
        }
    }
}
