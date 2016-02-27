using System.Collections.Generic;
using System.Linq;
using App.Dominio.Generico;

namespace App.Dominio.GerenciamentoUsuario.ObjetoDeValor
{
    public class VerificadorExistencia
    {
        public static bool Existe<T>(IEnumerable<T> lista, T valor) where T : EntidadeBase
        {
            if (valor == null || lista == null || !lista.Any())
                return false;
            return lista.Any(x => x.Id == valor.Id);
        }

        public static bool NaoExiste<T>(IEnumerable<T> lista, T valor) where T : EntidadeBase
        {
            return !Existe(lista, valor);
        }
    }
}
