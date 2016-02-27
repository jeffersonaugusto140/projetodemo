using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase.ExceptionsExtension
{
    public static class ControladorExcecao
    {
        private static List<ExcecaoGenericaException> _excecoes = new List<ExcecaoGenericaException>();

        public static void AdicionarNoControle(this ExcecaoGenericaException exception)
        {
            if (exception == null)
                return;

            _excecoes.Add(exception);
        }

        public static bool ExisteExcecoes()
        {
            return _excecoes.Any();
        }

        public static string Trace(this ExcecaoGenericaException exception)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Origem::::::::");

            exception.TraceIn(builder);

            return builder.ToString();
        }

        public static string Trace()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Origem::::::::");

            _excecoes.ForEach(ex =>
            {
                ex.TraceIn(builder);
            });

            return builder.ToString();
        }

        private static void TraceIn(this Exception exception, StringBuilder builder)
        {
            exception.InnerException?.TraceIn(builder);
            
            builder.AppendLine(exception.Message);
        }

        public static void Limpar()
        {
            _excecoes.Clear();
        }
    }
}
