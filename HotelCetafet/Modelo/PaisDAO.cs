using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCetafet.Modelo
{
    public class PaisDAO
    {
        private readonly bdHotelCetafestConexao _conexao;
        public PaisDAO() => _conexao = new bdHotelCetafestConexao();

        public async Task<List<Pais>> getPaises() => await _conexao.Pais.ToListAsync();

        public async Task setCadastrarPais(Pais novoPais)
        {
            _conexao.Pais.Add(novoPais);
            await _conexao.SaveChangesAsync();
        }

        public async Task<List<Pais>> getPaisLetraInicial(string iniciais) => await _conexao.Pais.Where(x => x.nome.StartsWith(iniciais)).ToListAsync();


        public async Task setAtualizar(Pais pais) {

            _conexao.Entry(pais).State = EntityState.Modified;
            await _conexao.SaveChangesAsync();
        }

        public async Task<Pais> getPais(int codigo) => await _conexao.Pais.Where(x => x.codigo == codigo).FirstOrDefaultAsync();

        public async Task setApagar(Pais pais)
        {
            _conexao.Pais.Remove(pais);
            await _conexao.SaveChangesAsync();
        }
    }
}
