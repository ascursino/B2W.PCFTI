
namespace B2WTI.PCFTI.APRESENTACAO.Extensions
{
    using System.Globalization;
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        public static string Titleize(this string text)
        {
            string ret = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text).ToSentenceCase();

            switch (ret.ToUpper())
            {
                case "ANOCALENDARIO":
                    ret = "Ano Calendário";
                    break;
                case "TIPOBLOCO":
                    ret = "Tipo de Bloco";
                    break;
                case "RESPONSAVEL":
                    ret = "Responsável";
                    break;
                case "TIPODEPAGAMENTO":
                    ret = "Tipo de Pagamento";
                    break;
                case "TIPOSERVICO":
                    ret = "Tipo de Serviço";
                    break;
                case "ORCAMENTO":
                    ret = "Orçamento";
                    break;
                case "USUARIO":
                    ret = "Usuário";
                    break;
                case "VISAO":
                    ret = "Visão";
                    break;
                case "LANCAMENTO":
                    ret = "Lançamento";
                    break;
            }

            return ret;
        }

        public static string ToSentenceCase(this string str)
        {
            return Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));
        }
    }
}