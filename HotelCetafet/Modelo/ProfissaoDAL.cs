using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCetafet.Modelo
{
    public class ProfissaoDAL
    {
        private readonly bdHotelCetafestConexao _conexao;
        public ProfissaoDAL() => _conexao = new bdHotelCetafestConexao();

        public async Task<List<Profissao>> getProfissoes() => await _conexao.Profissao.ToListAsync();

        public async Task setCadastrarPais(Profissao novaProfissao)
        {
            _conexao.Profissao.Add(novaProfissao);
            await _conexao.SaveChangesAsync();
        }

        public async Task<List<Profissao>> getProfissaoLetraInicial(string iniciais) => await _conexao.Profissao.Where(x => x.descricao.StartsWith(iniciais)).ToListAsync();


        public async Task setAtualizar(Profissao profissao)
        {

            _conexao.Entry(profissao).State = EntityState.Modified;
            await _conexao.SaveChangesAsync();
        }

        public async Task<Profissao> getProfissao(int codigo) => await _conexao.Profissao.Where(x => x.codigo == codigo).FirstOrDefaultAsync();

        public async Task setApagar(Profissao profissao)
        {
            _conexao.Profissao.Remove(profissao);
            await _conexao.SaveChangesAsync();
        }
    }
}
