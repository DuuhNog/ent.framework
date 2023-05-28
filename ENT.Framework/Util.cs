namespace ENT.Framework
{
    public static class Util
    {
        public static string CalculoIdade(DateTime pDataAtual, DateTime pDataNascimento)
        {
            var pIdade = pDataAtual.Year - pDataNascimento.Year;

            if (pDataAtual.DayOfYear < pDataNascimento.DayOfYear)
                pIdade--;

            return $"{pIdade} Ano(s)";
        }

        public static string CalculoIdadePrecisa(DateTime pDataAtual, DateTime pDataNascimento)
        {
            int Anos = new DateTime(DateTime.Now.Subtract(pDataNascimento).Ticks).Year - 1;
            DateTime AnosTranscorridos = pDataNascimento.AddYears(Anos);
            int Meses = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (AnosTranscorridos.AddMonths(i) == pDataAtual)
                {
                    Meses = i;
                    break;
                }
                else if (AnosTranscorridos.AddMonths(i) >= pDataAtual)
                {
                    Meses = i - 1;
                    break;
                }
            }
            int Dias = pDataAtual.Subtract(AnosTranscorridos.AddMonths(Meses)).Days;
            int Horas = pDataAtual.Subtract(AnosTranscorridos).Hours;
            int Minutos = pDataAtual.Subtract(AnosTranscorridos).Minutes;
            int Segundos = pDataAtual.Subtract(AnosTranscorridos).Seconds;

            return $"{Anos} Ano(s) {Meses} Mes(es) {Dias} Dia(s)";
        }
    }
}
