using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Transversal.Recursos
{
   public class Funciones
    {
        public static string EliminarDominioUsuario(string strUserName)
        {
            int hasDomain = strUserName.IndexOf(@"\");
            if (hasDomain > 0)
            {
                strUserName = strUserName.Remove(0, hasDomain + 1);
            }
            return strUserName;
        }

        public static string ToUpperFirstLetter(string strCadena)
        {
            if (string.IsNullOrEmpty(strCadena))
                return string.Empty;

            char[] chrLetras = strCadena.ToCharArray();
            chrLetras[0] = char.ToUpper(chrLetras[0]);

            return new string(chrLetras);
        }

        public static IEnumerable<KeyValuePair<string, string>> ListarMeses()
        {
            for (int i = 1; i <= 12; i++)
            {
                yield return new KeyValuePair<string, string>(i.ToString().Trim().PadLeft(2, '0'), CultureInfo.GetCultureInfoByIetfLanguageTag("es-ES").DateTimeFormat.GetMonthName(i).ToUpper());  //DateTimeFormatInfo.CurrentInfo.GetMonthName(i).ToUpper()
            }
        }

        public static IEnumerable<string> ListarAnios(int intAnioInicio)
        {
            List<string> lstAnios = new List<string>();

            for (int i = DateTime.Now.Year; i >= intAnioInicio; i--)
            {
                lstAnios.Add(i.ToString());
            }

            return lstAnios;
        }

        public static bool IsNumber(Object oCadena)
        {
            try
            {
                Double.Parse(oCadena.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidarRUC(string strRUC)
        {
            int intSumDig = 0;
            string strModCal;
            string strCadena = "5432765432";
            if (strRUC.Trim().Length == 11)
            {
                //Aplico Modulo 11
                int j = 0;
                for (int i = 1; i <= 10; i++)
                {
                    intSumDig = intSumDig + (int.Parse(strRUC.Trim().Substring(j, i - j)) * int.Parse(strCadena.Substring(j, i - j)));
                    j = j + 1;
                }

                //Calculando el modulo once
                string strMod11 = (11 - (intSumDig % 11)).ToString();

                if (strMod11.Length == 2)
                {
                    strModCal = strMod11.Substring(1, 1);
                }
                else
                {
                    strModCal = strMod11.Substring(0, 1);
                }

                //Comparando Resultados
                if (strModCal != strRUC.Substring(10, 1))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public static string CalcularAnteriorLetra(string strLetra)
        {
            string strAnteriorLetra;

            if (string.IsNullOrEmpty(strLetra) || strLetra.Trim().ToUpper() == "A")
            {
                strAnteriorLetra = "A";
            }
            else
            {
                strAnteriorLetra = ExcelColumnFromNumber(NumberFromExcelColumn(strLetra) - 1);
            }

            return strAnteriorLetra;
        }

        public static string CalcularSiguienteLetra(string strLetra)
        {
            string strSiguienteLetra;

            if (string.IsNullOrEmpty(strLetra))
            {
                strSiguienteLetra = "A";
            }
            else
            {
                strSiguienteLetra = ExcelColumnFromNumber(NumberFromExcelColumn(strLetra) + 1);
            }

            return strSiguienteLetra;
        }

        public static string ExcelColumnFromNumber(int value)
        {
            StringBuilder sb = new StringBuilder();

            do
            {
                value--;
                int remainder = 0;
                value = Math.DivRem(value, 26, out remainder);
                sb.Insert(0, Convert.ToChar('A' + remainder));

            } while (value > 0);

            return sb.ToString();
        }

        public static int NumberFromExcelColumn(string column)
        {
            int retVal = 0;
            string col = column.ToUpper();
            for (int iChar = col.Length - 1; iChar >= 0; iChar--)
            {
                char colPiece = col[iChar];
                int colNum = colPiece - 64;
                retVal = retVal + colNum * (int)Math.Pow(26, col.Length - (iChar + 1));
            }
            return retVal;
        }

        public static string FormatoCorreo(List<string> lstCorreoAlerta)
        {
            string strCorreo = string.Empty;

            foreach (string strCorreoAlerta in lstCorreoAlerta)
            {
                if (strCorreo != string.Empty)
                {
                    strCorreo += "; ";
                }

                strCorreo += strCorreoAlerta;
            }

            return strCorreo;
        }

        public static decimal TruncateDecimal(decimal value, int precision)
        {
            decimal step = (decimal)Math.Pow(10, precision);
            return Math.Truncate(step * value) / step;
        }

        public static double RoundUp(double dblNumero, int intDigitos)
        {
            return Math.Ceiling(dblNumero * Math.Pow(10, intDigitos)) / Math.Pow(10, intDigitos);
        }

        public static bool ValidarDecimalPrecisionScale(decimal decValor, int intPrecision, int intScale)
        {
            try
            {
                System.Data.SqlTypes.SqlDecimal.ConvertToPrecScale(new SqlDecimal(decValor), intPrecision, intScale);
            }
            catch (SqlTruncateException ex)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Permite convertir de String a DateTime con su respectivo formato de fecha
        /// </summary>
        /// <param name="valor">Fecha</param>
        /// <param name="formato">Formato</param>
        /// <returns>Retorna de Fecha</returns>
        public static DateTime? CadenaFormatoFecha(string valor, string formato)
        {
            try
            {
                return string.IsNullOrEmpty(valor) ? (DateTime?)null : DateTime.ParseExact(valor, formato, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                return null;
            }
        }

        /// <summary>
        /// Permite convertir DateTime a String con su respectivo formato de fecha
        /// </summary>
        /// <param name="valor">Fecha</param>
        /// <param name="formato">Formato</param>
        /// <returns>Retorna la fecha formateada</returns>
        public static string FechaFormatoCadena(DateTime? valor, string formato)
        {
            if (valor.HasValue)
            {
                return Convert.ToDateTime(valor).ToString(formato, System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Permite convertir de String a Decimal con su respectivo formato de decimal
        /// </summary>
        /// <param name="value">Decimal</param>
        /// <param name="format">Formato</param>
        /// <param name="numberFormat">Formato de Número</param>
        /// <returns>Retorna de Decimal</returns>
        public static decimal? CadenaFormatoDecimal(string value, string format, string separadorDecimal)
        {
            try
            {
                if (!format.Contains("{"))
                {
                    format = "{0:" + format + "}";
                }

                NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
                numberFormatInfo.NumberDecimalSeparator = separadorDecimal;
                numberFormatInfo.NumberGroupSeparator = string.Empty;

                return string.IsNullOrEmpty(value) ? (decimal?)null : System.Decimal.Parse(value, numberFormatInfo);
            }
            catch (FormatException)
            {
                return null;
            }
        }

        /// <summary>
        /// Permite convertir Decimal a String con su respectivo formato de decimal
        /// </summary>
        /// <param name="value">Decimal</param>
        /// <param name="format">Formato</param>
        /// <param name="numberFormat">Formato de Número</param>
        /// <returns>Retorna el decimal formateado</returns>
        public static string DecimalFormatoCadena(decimal? value, string format, string separadorDecimal)
        {
            if (value.HasValue)
            {
                if (!format.Contains("{"))
                {
                    format = "{0:" + format + "}";
                }
                NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
                numberFormatInfo.NumberDecimalSeparator = separadorDecimal;
                numberFormatInfo.NumberGroupSeparator = string.Empty;

                format = format.Replace(numberFormatInfo.NumberDecimalSeparator, "@");
                format = format.Replace("@", ".");

                return string.Format(numberFormatInfo, format, value);
            }
            else
            {
                return string.Empty;
            }
        }

        public static string ObtenerFechaLarga(DateTime dtFecha)
        {
            string fechaLarga = string.Empty;

            fechaLarga = dtFecha.ToString("dddd, d * MMMM - yyyy", CultureInfo.CreateSpecificCulture("es-PE"));

            return fechaLarga.Replace("*", "de").Replace("-", "del");
        }
        public static string genera_codigo(int intNumero)
        {
            Random aleatorio = new Random();
            string res = "";
            string[] vals = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            for (int i = 0; i <= intNumero; i++)
            {
                res = res + vals[aleatorio.Next(vals.GetUpperBound(0) + 1)];
            }
            return res;
        }

        static string Mayusculas(string value)
        {
            char[] array = value.ToCharArray();

            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }
    }
}
