using AutoMapper;
using System.Globalization;

namespace ENT.Framework
{
    public static class TypeConversion
    {
        private static NumberFormatInfo NumberFormatInvariant => CultureInfo.InvariantCulture.NumberFormat;

        private static DateTimeFormatInfo DateTimeFormatInvariant => CultureInfo.InvariantCulture.DateTimeFormat;

        //
        // Summary:
        //     Converte para booleano, caso aconteça erro, retornar o parametro other
        //
        // Parameters:
        //   value:
        //
        //   other:
        //     Valor caso aconteça erro
        //
        // Returns:
        //     Valor convertido ou o valor other
        public static bool ToBool(this IConvertible value, bool other = false)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch (Exception)
            {
                return other;
            }
        }

        //
        // Summary:
        //     Converte para booleano, caso aconteça erro, retornar o parametro other
        //
        // Parameters:
        //   value:
        //
        //   other:
        //     Valor caso aconteça erro
        //
        // Returns:
        //     Valor convertido ou o valor other
        public static bool ToBool(object value, bool other = false)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch (Exception)
            {
                return other;
            }
        }

        //
        // Summary:
        //     Converte para int, caso aconteça erro, retornar o parametro other
        //
        // Parameters:
        //   value:
        //
        //   other:
        //     Valor caso aconteça erro
        //
        // Returns:
        //     Valor convertido ou o valor other
        public static int ToInt(this IConvertible value, int other = 0)
        {
            try
            {
                if (value is int)
                {
                    return (int)(object)value;
                }

                return (int)Math.Truncate(value.ToDouble());
            }
            catch
            {
            }

            return other;
        }

        //
        // Summary:
        //     Converte para int, caso aconteça erro, retornar o parametro other
        //
        // Parameters:
        //   value:
        //
        //   other:
        //     Valor caso aconteça erro
        //
        // Returns:
        //     Valor convertido ou o valor other
        public static int ToInt(object value, int other = 0)
        {
            try
            {
                if (value is int)
                {
                    return (int)value;
                }

                return (int)Math.Truncate(ToDouble(value));
            }
            catch
            {
            }

            return other;
        }

        //
        // Summary:
        //     Converte para long, caso aconteça erro, retornar o parametro other
        //
        // Parameters:
        //   value:
        //
        //   other:
        //     Valor caso aconteça erro
        //
        // Returns:
        //     Valor convertido ou o valor other
        public static long ToLong(this IConvertible value, long other = 0L)
        {
            try
            {
                return Convert.ToInt64(value);
            }
            catch
            {
            }

            return other;
        }

        //
        // Summary:
        //     Converte para long, caso aconteça erro, retornar o parametro other
        //
        // Parameters:
        //   value:
        //
        //   other:
        //     Valor caso aconteça erro
        //
        // Returns:
        //     Valor convertido ou o valor other
        public static long ToLong(object value, long other = 0L)
        {
            try
            {
                return Convert.ToInt64(value);
            }
            catch
            {
            }

            return other;
        }

        //
        // Summary:
        //     Converte para int, caso aconteça erro, retornar null
        //
        // Parameters:
        //   value:
        //
        // Returns:
        //     Valor convertido ou o valor null
        public static int? ToIntNullable(this IConvertible value)
        {
            try
            {
                if (value is int)
                {
                    return (int)(object)value;
                }

                double? num = value.ToDoubleNullable();
                if (!num.HasValue)
                {
                    return null;
                }

                return (int)Math.Truncate(Convert.ToDouble(num));
            }
            catch
            {
            }

            return null;
        }

        //
        // Summary:
        //     Converte para int, caso aconteça erro, retornar null
        //
        // Parameters:
        //   value:
        //
        // Returns:
        //     Valor convertido ou o valor null
        public static int? ToIntNullable(object value)
        {
            try
            {
                if (value is int)
                {
                    return (int)value;
                }

                return (int)Math.Truncate(ToDouble(value));
            }
            catch
            {
            }

            return null;
        }

        //
        // Summary:
        //     Converte para NULL caso object seja zero, caso aconteça erro, retornar null
        //
        // Parameters:
        //   value:
        //
        // Returns:
        //     Valor convertido ou o valor null
        public static int? ToIntZeroNullable(this IConvertible value)
        {
            try
            {
                if (value is int)
                {
                    if ((int)(object)value == 0)
                    {
                        return null;
                    }

                    return (int)(object)value;
                }

                double? num = value.ToDoubleNullable();
                if (!num.HasValue || num == 0.0)
                {
                    return null;
                }

                return (int)Math.Truncate(Convert.ToDouble(num));
            }
            catch
            {
            }

            return null;
        }

        //
        // Summary:
        //     Converte para NULL caso object seja zero, caso aconteça erro, retornar null
        //
        // Parameters:
        //   value:
        //
        // Returns:
        //     Valor convertido ou o valor null
        public static int? ToIntZeroNullable(object value)
        {
            try
            {
                if (value is int)
                {
                    if ((int)value == 0)
                    {
                        return null;
                    }

                    return (int)value;
                }

                double? num = value.ToString().ToDoubleNullable();
                if (!num.HasValue || num == 0.0)
                {
                    return null;
                }

                return (int)Math.Truncate(ToDouble(value));
            }
            catch
            {
            }

            return null;
        }

        //
        // Summary:
        //     Verifica se a data é valida. Sendo válida retorna no formato "dd/MM/yyyy" se
        //     não retorna vazio
        //
        // Parameters:
        //   value:
        public static string ToDateString(this DateTime value)
        {
            string text = value.ToString("dd/MM/yyyy");
            string result;
            switch (text)
            {
                default:
                    result = text;
                    break;
                case "01/01/0001":
                case "01/01/1800":
                case "01/01/1900":
                case "30/12/1899":
                case "18/12/1899":
                    result = string.Empty;
                    break;
            }

            return result;
        }

        //
        // Summary:
        //     Verifica se a data é valida. Sendo válida retorna no formato "dd/MM/yyyy HH:mm"
        //     se não retorna vazio
        //
        // Parameters:
        //   value:
        public static string ToDateTimeString(this DateTime value)
        {
            string result;
            switch (value.ToString("dd/MM/yyyy HH:mm"))
            {
                default:
                    result = value.ToString("dd/MM/yyyy HH:mm");
                    break;
                case "01/01/0001 00:00":
                case "01/01/1800 00:00":
                case "01/01/1900 00:00":
                case "30/12/1899 00:00":
                case "18/12/1899 00:00":
                    result = string.Empty;
                    break;
            }

            return result;
        }

        //
        // Summary:
        //     Retorna no formato "HH:mm"
        //
        // Parameters:
        //   value:
        public static string ToTimeString(this DateTime value)
        {
            return value.ToString("HH:mm");
        }

        //
        // Summary:
        //     Converte para double, caso aconteça erro, retornar o parametro other
        //
        // Parameters:
        //   value:
        //
        //   other:
        //     Valor caso aconteça erro
        //
        // Returns:
        //     Valor convertido ou o valor other
        public static double ToDouble(this IConvertible value, double other = 0.0)
        {
            try
            {
                if (value is double)
                {
                    return (double)(object)value;
                }

                string text = value.ToString(CultureInfo.InvariantCulture);
                if (text.Contains(","))
                {
                    text = text.Replace(".", "").Replace(",", ".");
                }

                if (double.TryParse(text, NumberStyles.Number, NumberFormatInvariant, out var result))
                {
                    return result;
                }
            }
            catch
            {
            }

            return other;
        }

        //
        // Summary:
        //     Converte para double, caso aconteça erro, retornar o parametro other
        //
        // Parameters:
        //   value:
        //
        //   other:
        //     Valor caso aconteça erro
        //
        // Returns:
        //     Valor convertido ou o valor other
        public static double ToDouble(object value, double other = 0.0)
        {
            try
            {
                if (value is double)
                {
                    return (double)value;
                }

                string text = value.ToString();
                if (text.Contains(","))
                {
                    text = text.Replace(".", "").Replace(",", ".");
                }

                if (double.TryParse(text, NumberStyles.Number, NumberFormatInvariant, out var result))
                {
                    return result;
                }
            }
            catch
            {
            }

            return other;
        }

        //
        // Summary:
        //     Converte para double, caso aconteça erro, retornar null
        //
        // Parameters:
        //   value:
        //
        // Returns:
        //     Valor convertido ou o valor null
        public static double? ToDoubleNullable(this IConvertible value)
        {
            try
            {
                if (value is double)
                {
                    return (double)(object)value;
                }

                string text = value.ToString(CultureInfo.InvariantCulture);
                if (text.Contains(","))
                {
                    text = text.Replace(".", "").Replace(",", ".");
                }

                if (double.TryParse(text, NumberStyles.Number, NumberFormatInvariant, out var result))
                {
                    return result;
                }
            }
            catch
            {
            }

            return null;
        }

        //
        // Summary:
        //     Converte para double, caso aconteça erro, retornar null
        //
        // Parameters:
        //   value:
        //
        // Returns:
        //     Valor convertido ou o valor null
        public static double? ToDoubleNullable(object value)
        {
            try
            {
                if (value is double)
                {
                    return (double)value;
                }

                string text = value.ToString();
                if (text.Contains(","))
                {
                    text = text.Replace(".", "").Replace(",", ".");
                }

                if (double.TryParse(text, NumberStyles.Number, NumberFormatInvariant, out var result))
                {
                    return result;
                }
            }
            catch
            {
            }

            return null;
        }

        //
        // Summary:
        //     Converte para DateTime, caso aconteça erro, retornar DateTime.MinValue
        //
        // Parameters:
        //   value:
        //
        // Returns:
        //     Valor Convertido ou DateTime.MinValue
        public static DateTime ToDate(this IConvertible value)
        {
            return value.ToDate(DateTime.MinValue);
        }

        //
        // Summary:
        //     Converte para DateTime, caso aconteça erro, retornar o parametro other
        //
        // Parameters:
        //   value:
        //
        //   other:
        //     Valor caso aconteça erro
        //
        // Returns:
        //     Valor convertido ou o valor other
        public static DateTime ToDate(this IConvertible value, DateTime other)
        {
            try
            {
                if (value is string && string.IsNullOrEmpty(value.ToString()))
                {
                    return other;
                }

                IFormatProvider provider = new CultureInfo("pt-br", useUserOverride: true);
                if (DateTime.TryParse(value.ToString(CultureInfo.InvariantCulture), provider, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.NoCurrentDateDefault, out var result) && !string.IsNullOrEmpty(result.ToDateTimeString()))
                {
                    return result;
                }
            }
            catch
            {
            }

            return other;
        }

        //
        // Summary:
        //     Converte para DateTime, caso aconteça erro, retornar null
        //
        // Parameters:
        //   value:
        //
        // Returns:
        //     Valor convertido ou o valor null
        public static DateTime? ToDateNullable(this IConvertible value)
        {
            try
            {
                if (DateTime.TryParse(value.ToString(CultureInfo.InvariantCulture), DateTimeFormatInvariant, DateTimeStyles.NoCurrentDateDefault, out var result) && !string.IsNullOrEmpty(result.ToDateString()))
                {
                    return result;
                }
            }
            catch
            {
            }

            return null;
        }

        //
        // Summary:
        //     Verifica Vazio, Null, Apenas Espaços e espaço HTML
        //
        // Parameters:
        //   value:
        //     Valor para comparar
        //
        // Returns:
        //     retorna true ou false
        public static bool IsNullOrEmpty(this object value)
        {
            return string.IsNullOrEmpty(value.ToString().Trim()) || value.ToString().Equals("&nbsp;");
        }

        //
        // Summary:
        //     Verifica Vazio, Null, Apenas Espaços, espaço HTML e IsDBNull
        //
        // Parameters:
        //   value:
        //     Valor para comparar
        //
        // Returns:
        //     retorna true ou false
        public static bool IsNullOrEmptyOrIsDBNull(this object value)
        {
            return Convert.IsDBNull(value) || value.IsNullOrEmpty();
        }

        //
        // Summary:
        //     Verifica Vazio, Null, Apenas Espaços, espaço HTML, Zero e Mascaras("__/__/_____"
        //     e "__:__")
        //
        // Parameters:
        //   value:
        //     Valor para comparar
        //
        // Returns:
        //     retorna true ou false
        public static bool IsNullEmptyOrZero(this object value)
        {
            return value.IsNullOrEmpty() || value.Equals("0") || value.Equals("&nbsp;") || value.Equals("__/__/____") || value.Equals("__:__");
        }

        //
        // Summary:
        //     Converter para o tipo do parâmetro "T"
        //
        // Parameters:
        //   obj:
        //
        // Type parameters:
        //   T:
        //     Tipo para Conversão
        private static T To<T>(this IConvertible obj)
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }

        //
        // Summary:
        //     Converte para o tipo T ou retorna o valor default do tipo T.
        //
        // Parameters:
        //   obj:
        //
        // Type parameters:
        //   T:
        //     Tipo para Conversão
        //
        // Returns:
        //     Retornar o valor Convertido ou Default
        private static T ToOrDefault<T>(this IConvertible obj)
        {
            try
            {
                return obj.To<T>();
            }
            catch
            {
                return default(T);
            }
        }

        //
        // Summary:
        //     Converte para o tipo T ou retornar o valor do other
        //
        // Parameters:
        //   obj:
        //
        //   other:
        //     Valor que retornar se nao converter
        //
        // Type parameters:
        //   T:
        //     Tipo para Conversão
        //
        // Returns:
        //     Retornar o valor convertido ou o valor passado
        private static T ToOrOther<T>(this IConvertible obj, T other)
        {
            try
            {
                return obj.To<T>();
            }
            catch
            {
                return other;
            }
        }

        //
        // Summary:
        //     Verifica se o inicio e fim estao entre o valor
        //
        // Parameters:
        //   item:
        //
        //   inicio:
        //     Valor Inicial
        //
        //   fim:
        //     Valor Final
        //
        // Type parameters:
        //   T:
        //     Tipo de Valor
        public static bool IsBetween<T>(this T item, T inicio, T fim)
        {
            return Comparer<T>.Default.Compare(item, inicio) >= 0 && Comparer<T>.Default.Compare(item, fim) <= 0;
        }

        public static T ConvertTo<T, T2>(this T2 obj) where T : class where T2 : class
        {
            //IL_0020: Unknown result type (might be due to invalid IL or missing references)
            //IL_0026: Expected O, but got Unknown
            //IL_0027: Unknown result type (might be due to invalid IL or missing references)
            //IL_002d: Expected O, but got Unknown
            MapperConfiguration val = new MapperConfiguration((Action<IMapperConfigurationExpression>)delegate (IMapperConfigurationExpression cfg)
            {
                ((IProfileExpression)cfg).CreateMap<T2, T>();
            });
            Mapper val2 = new Mapper((IConfigurationProvider)(object)val);
            return val2.Map<T>((object)obj);
        }

        //
        // Summary:
        //     Decimal para valor por extenso
        //
        // Parameters:
        //   valor:
        public static string ToExtenso(this double valor)
        {
            if (valor <= 0.0 || valor >= 1E+15)
            {
                return "Valor não suportado pelo sistema.";
            }

            string text = valor.ToString("000000000000000.00");
            string text2 = string.Empty;
            for (int i = 0; i <= 15; i += 3)
            {
                text2 += escreva_parte(Convert.ToDecimal(text.Substring(i, 3)));
                if ((i == 0) & (text2 != string.Empty))
                {
                    if (Convert.ToInt32(text.Substring(0, 3)) == 1)
                    {
                        text2 = text2 + " TRILHÃO" + ((Convert.ToDecimal(text.Substring(3, 12)) > 0m) ? " E " : string.Empty);
                    }
                    else if (Convert.ToInt32(text.Substring(0, 3)) > 1)
                    {
                        text2 = text2 + " TRILHÕES" + ((Convert.ToDecimal(text.Substring(3, 12)) > 0m) ? " E " : string.Empty);
                    }
                }
                else if ((i == 3) & (text2 != string.Empty))
                {
                    if (Convert.ToInt32(text.Substring(3, 3)) == 1)
                    {
                        text2 = text2 + " BILHÃO" + ((Convert.ToDecimal(text.Substring(6, 9)) > 0m) ? " E " : string.Empty);
                    }
                    else if (Convert.ToInt32(text.Substring(3, 3)) > 1)
                    {
                        text2 = text2 + " BILHÕES" + ((Convert.ToDecimal(text.Substring(6, 9)) > 0m) ? " E " : string.Empty);
                    }
                }
                else if ((i == 6) & (text2 != string.Empty))
                {
                    if (Convert.ToInt32(text.Substring(6, 3)) == 1)
                    {
                        text2 = text2 + " MILHÃO" + ((Convert.ToDecimal(text.Substring(9, 6)) > 0m) ? " E " : string.Empty);
                    }
                    else if (Convert.ToInt32(text.Substring(6, 3)) > 1)
                    {
                        text2 = text2 + " MILHÕES" + ((Convert.ToDecimal(text.Substring(9, 6)) > 0m) ? " E " : string.Empty);
                    }
                }
                else if (((i == 9) & (text2 != string.Empty)) && Convert.ToInt32(text.Substring(9, 3)) > 0)
                {
                    text2 = text2 + " MIL" + ((Convert.ToDecimal(text.Substring(12, 3)) > 0m) ? " E " : string.Empty);
                }

                if (i == 12)
                {
                    if (text2.Length > 8)
                    {
                        if ((text2.Substring(text2.Length - 6, 6) == "BILHÃO") | (text2.Substring(text2.Length - 6, 6) == "MILHÃO"))
                        {
                            text2 += " DE";
                        }
                        else if ((text2.Substring(text2.Length - 7, 7) == "BILHÕES") | (text2.Substring(text2.Length - 7, 7) == "MILHÕES") | (text2.Substring(text2.Length - 8, 7) == "TRILHÕES"))
                        {
                            text2 += " DE";
                        }
                        else if (text2.Substring(text2.Length - 8, 8) == "TRILHÕES")
                        {
                            text2 += " DE";
                        }
                    }

                    if (Convert.ToInt64(text.Substring(0, 15)) == 1)
                    {
                        text2 += " REAL";
                    }
                    else if (Convert.ToInt64(text.Substring(0, 15)) > 1)
                    {
                        text2 += " REAIS";
                    }

                    if (Convert.ToInt32(text.Substring(16, 2)) > 0 && text2 != string.Empty)
                    {
                        text2 += " E ";
                    }
                }

                if (i == 15)
                {
                    if (Convert.ToInt32(text.Substring(16, 2)) == 1)
                    {
                        text2 += " CENTAVO";
                    }
                    else if (Convert.ToInt32(text.Substring(16, 2)) > 1)
                    {
                        text2 += " CENTAVOS";
                    }
                }
            }

            return text2;
        }

        private static string escreva_parte(decimal valor)
        {
            if (valor <= 0m)
            {
                return string.Empty;
            }

            string text = string.Empty;
            if ((valor > 0m) & (valor < 1m))
            {
                valor *= 100m;
            }

            string text2 = valor.ToString("000");
            int num = Convert.ToInt32(text2.Substring(0, 1));
            int num2 = Convert.ToInt32(text2.Substring(1, 1));
            int num3 = Convert.ToInt32(text2.Substring(2, 1));
            switch (num)
            {
                case 1:
                    text += ((num2 + num3 == 0) ? "CEM" : "CENTO");
                    break;
                case 2:
                    text += "DUZENTOS";
                    break;
                case 3:
                    text += "TREZENTOS";
                    break;
                case 4:
                    text += "QUATROCENTOS";
                    break;
                case 5:
                    text += "QUINHENTOS";
                    break;
                case 6:
                    text += "SEISCENTOS";
                    break;
                case 7:
                    text += "SETECENTOS";
                    break;
                case 8:
                    text += "OITOCENTOS";
                    break;
                case 9:
                    text += "NOVECENTOS";
                    break;
            }

            switch (num2)
            {
                case 1:
                    switch (num3)
                    {
                        case 0:
                            text = text + ((num > 0) ? " E " : string.Empty) + "DEZ";
                            break;
                        case 1:
                            text = text + ((num > 0) ? " E " : string.Empty) + "ONZE";
                            break;
                        case 2:
                            text = text + ((num > 0) ? " E " : string.Empty) + "DOZE";
                            break;
                        case 3:
                            text = text + ((num > 0) ? " E " : string.Empty) + "TREZE";
                            break;
                        case 4:
                            text = text + ((num > 0) ? " E " : string.Empty) + "QUATORZE";
                            break;
                        case 5:
                            text = text + ((num > 0) ? " E " : string.Empty) + "QUINZE";
                            break;
                        case 6:
                            text = text + ((num > 0) ? " E " : string.Empty) + "DEZESSEIS";
                            break;
                        case 7:
                            text = text + ((num > 0) ? " E " : string.Empty) + "DEZESSETE";
                            break;
                        case 8:
                            text = text + ((num > 0) ? " E " : string.Empty) + "DEZOITO";
                            break;
                        case 9:
                            text = text + ((num > 0) ? " E " : string.Empty) + "DEZENOVE";
                            break;
                    }

                    break;
                case 2:
                    text = text + ((num > 0) ? " E " : string.Empty) + "VINTE";
                    break;
                case 3:
                    text = text + ((num > 0) ? " E " : string.Empty) + "TRINTA";
                    break;
                case 4:
                    text = text + ((num > 0) ? " E " : string.Empty) + "QUARENTA";
                    break;
                case 5:
                    text = text + ((num > 0) ? " E " : string.Empty) + "CINQUENTA";
                    break;
                case 6:
                    text = text + ((num > 0) ? " E " : string.Empty) + "SESSENTA";
                    break;
                case 7:
                    text = text + ((num > 0) ? " E " : string.Empty) + "SETENTA";
                    break;
                case 8:
                    text = text + ((num > 0) ? " E " : string.Empty) + "OITENTA";
                    break;
                case 9:
                    text = text + ((num > 0) ? " E " : string.Empty) + "NOVENTA";
                    break;
            }

            if ((text2.Substring(1, 1) != "1" && num3 != 0) & (text != string.Empty))
            {
                text += " E ";
            }

            if (text2.Substring(1, 1) != "1")
            {
                switch (num3)
                {
                    case 1:
                        text += "UM";
                        break;
                    case 2:
                        text += "DOIS";
                        break;
                    case 3:
                        text += "TRÊS";
                        break;
                    case 4:
                        text += "QUATRO";
                        break;
                    case 5:
                        text += "CINCO";
                        break;
                    case 6:
                        text += "SEIS";
                        break;
                    case 7:
                        text += "SETE";
                        break;
                    case 8:
                        text += "OITO";
                        break;
                    case 9:
                        text += "NOVE";
                        break;
                }
            }

            return text;
        }
    }
}
