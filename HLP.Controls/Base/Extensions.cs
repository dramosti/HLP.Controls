using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace HLP.Controls.Base
{
    public static class Extensions
    {

        #region isValid
        public static bool IsValidUrl(this string text)
        {
            Regex rx = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
            return rx.IsMatch(text);
        }

        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }

        public static bool IsValidIPAddress(this string s)
        {
            return Regex.IsMatch(s, @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
        }

        public static bool IsValidDateTime(this string s)
        {
            try
            {
                Convert.ToDateTime(s);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Extensions string

        public static decimal ToDecimal(this string value)
        {
            decimal number;

            Decimal.TryParse(value, out number);
            return number;
        }

        public static int ToInt32(this string value)
        {
            int number;

            Int32.TryParse(value, out number);
            return number;
        }

        public static DateTime ToDateTime(this string value)
        {
            DateTime date;

            DateTime.TryParse(value, out date);
            return date;
        }

        public static string FirstLetterToUpper(this string Text)
        {
            Text = Text.ToLower();
            return char.ToUpper(Text[0]) + Text.Substring(1);
        }

        public static string RemoveSpecialChars(this string Text)
        {
            return Text.Replace(".", "")
                .Replace(",", "")
                .Replace("/", "")
                .Replace("'\'", "")
                .Replace("-", "")
                .Replace("_", "")
                .Replace("[", "")
                .Replace("]", "")
                .Replace("{", "")
                .Replace("}", "")
                .Replace("(", "")
                .Replace(")", "").Trim();
        }




        /// <summary>
        /// Envia um email
        /// </summary>
        /// <param name="body">String que será usada no corpo do email</param>
        /// <param name="subject">Asssunto do email</param>
        /// <param name="nameSender">Nome do Remetente do email</param>
        /// <param name="sender">Email do remetente da menssagem</param>
        /// <param name="password">Senha do email do remetente</param>
        /// <param name="recipient">Email do receptor</param> 
        /// <param name="server">Servidor do qual o e-mail será enviado.</param>
        /// <param name="port">Porta do servidor de email</param> 
        /// <returns>Um valor booleano que indica o sucesso do e-mail enviado.</returns>
        public static bool Email(this string body, string subject, string nameSender, string sender, string password, string recipient, string server, int port)
        {
            try
            {
                // To
                MailMessage mailMsg = new MailMessage();
                mailMsg.To.Add(recipient);

                // From
                MailAddress mailAddress = new MailAddress(sender, nameSender);
                mailMsg.From = mailAddress;

                // Subject and Body
                mailMsg.Subject = subject;
                mailMsg.Body = body;

                // Init SmtpClient and send
                SmtpClient smtpClient = new SmtpClient(server, port);
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(sender, password);
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Deleta todos os arquivos de determinado diretório, baseado em uma extensão
        /// </summary>
        /// <param name="folderPath">Caminho (pasta)</param>
        /// <param name="ext">Extensão do arquivo à ser deletado</param>
        public static void DeleteFiles(this string folderPath, string ext)
        {
            string mask = "*." + ext;

            try
            {
                string[] fileList = Directory.GetFiles(folderPath, mask);

                foreach (string file in fileList)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    fileInfo.Delete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar arquivo(s). Rasão: " + ex.Message);
            }
        }

        #endregion

        #region Extensions decimal
        public static int ToInt32(this decimal value)
        {
            try
            {
                int number = Convert.ToInt32(value);
                return number;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao converter o tipo decimal para inteiro.");
            }
        }
        #endregion

        #region Entensions DataTable

        /// <summary>
        /// Este método recebe qualquer DataTable e remove os registros duplicados com base em qualquer coluna.
        /// </summary>
        /// <param name="tblIn">Objeto DataTable à ser manipulado</param>
        /// <param name="KeyColName">Nome da coluna à ser desconsiderado os dados repetidos</param>
        /// <returns>DataTable sem dados duplicados</returns>
        public static DataTable Dedup(this DataTable tblIn, string KeyColName)
        {
            DataTable tblOut = tblIn.Clone();
            foreach (DataRow row in tblIn.Rows)
            {
                bool found = false;
                string caseIDToTest = row[KeyColName].ToString();
                foreach (DataRow row2 in tblOut.Rows)
                {
                    if (row2[KeyColName].ToString() == caseIDToTest)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    tblOut.ImportRow(row);
            }
            return tblOut;
        }


        public static bool ToBoolean(this byte value)
        {
            if (value == 0)
                return false;
            else
                return true;
        }



        #endregion

        #region Extension Bool

        public static Byte ToByte(this bool value)
        {
            try
            {
                return Convert.ToByte((value ? 1 : 0));
            }
            catch (Exception)
            {
                throw new Exception("objeto bool está nullo.");
            }
        }


        #endregion

        #region Extensions Generic

        /// <summary>
        /// Verifica se determinado dado está entre
        /// </summary>
        /// <typeparam name="T">Tipo do objeto a ser comparado</typeparam>
        /// <param name="value">Valor à ser comparado</param>
        /// <param name="from">Parametrô 1 para comparação</param>
        /// <param name="to">>Parametrô 2 para comparação</param>
        /// <returns></returns>
        public static bool Between<T>(this T value, T from, T to) where T : IComparable<T>
        {
            return value.CompareTo(from) >= 0 && value.CompareTo(to) <= 0;
        }

        /// <summary>
        /// Seleciona um valor de uma lista qualquer dinâmicamente.
        /// </summary>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="sequence">Valores a serem sortidos</param>
        /// <returns>Retorna o valor sortiado</returns>
        public static T SelectRandom<T>(this IEnumerable<T> sequence)
        {
            Random random = new Random();

            if (sequence == null)
            {
                throw new ArgumentNullException();
            }

            if (!sequence.Any())
            {
                throw new ArgumentException("A sequência está vázia");
            }

            //otimiização para ICollection<T>
            if (sequence is ICollection<T>)
            {
                ICollection<T> col = (ICollection<T>)sequence;
                return col.ElementAt(random.Next(col.Count));
            }

            int count = 1;
            T selected = default(T);

            foreach (T element in sequence)
            {
                if (random.Next(count++) == 0)
                {
                    //Seleciona o elemento atual com probabilidade 1/count
                    selected = element;
                }
            }

            return selected;
        }

        #endregion

        #region Extension Control

        public static object ToObject(this System.Windows.Controls.Control value)
        {
            try
            {
                object obj = (value as object);
                return obj;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao converter o tipo Control para Object.");
            }
        }

        #endregion

        #region Extension Object
        public static int ToInt32(this object value)
        {
            int number = 0;
            if (value == null)
                return number;

            Int32.TryParse(value.ToString(), out number);
            return number;
        }

        public static void SetPropertyValue(this object containingObject, string propertyName, object newValue)
        {
            if (containingObject != null)
                try
                { containingObject.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, containingObject, new object[] { newValue }); }
                catch (Exception)
                { }
        }

        public static object GetPropertyValue(this object value, string sNameProperty)
        {
            try
            {
                return value.GetType().GetProperty(sNameProperty).GetValue(value, null);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro ao buscar a propriedade {0} do objeto:{1}{3}Erro:", sNameProperty, value.GetType().Name, Environment.NewLine) + ex.Message);
            }
        }

        #endregion

        #region Extension Reflection

        /// <summary>
        /// Gets the specified attribute from the PropertyDescriptor.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(this PropertyDescriptor prop) where T : Attribute
        {
            foreach (Attribute att in prop.Attributes)
            {
                var tAtt = att as T;
                if (tAtt != null) return tAtt;
            }
            return null;
        }

        /// <summary>
        /// Gets the specified attribute from the type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(this Type type, bool inherit) where T : Attribute
        {
            var atts = type.GetCustomAttributes(typeof(T), inherit);
            if (atts.Length == 0) return null;
            return atts[0] as T;
        }

        /// <summary>
        /// Gets the specified attribute for the assembly.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="asm"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(this Assembly asm) where T : Attribute
        {
            if (asm == null) return null;

            var atts = asm.GetCustomAttributes(typeof(T), false);
            if (atts == null) return null;
            if (atts.Length == 0) return null;

            return (T)atts[0];
        }

        /// <summary>
        /// Gets the specified attribute from the PropertyDescriptor.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(this object obj, bool inherit) where T : Attribute
        {
            if (obj == null) return null;
            return obj.GetType().GetAttribute<T>(inherit);
        }
        #endregion

        #region ToolStripItem

        public static ContextMenuStrip GetContextMenuStrip(this ToolStripItem item)
        {
            ToolStripItem itemCheck = item;

            while (!(itemCheck.GetCurrentParent() is ContextMenuStrip) && itemCheck.GetCurrentParent() is ToolStripDropDown)
            {
                itemCheck = (itemCheck.GetCurrentParent() as ToolStripDropDown).OwnerItem;
            }

            return itemCheck.GetCurrentParent() as ContextMenuStrip;
        }
        #endregion
        
        #region TimeSpan

        public static string ToStringHoras(this object value)
        {
            if (value != null)
            {
                int iTotHoras = (((TimeSpan)value).Days * 24) + ((TimeSpan)value).Hours;

                int iMinutes;
                if (((TimeSpan)value).Minutes < 0)
                    iMinutes = ((TimeSpan)value).Minutes * -1;
                else
                    iMinutes = ((TimeSpan)value).Minutes;
                return iTotHoras.ToString().PadLeft(2, '0') + ":"
                    + iMinutes.ToString().PadLeft(2, '0') + ":00";
            }
            return "00:00:00";
        }

        public static TimeSpan ToTimeSpan(this string Text)
        {
            string sSinal = (Text.Contains('-') ? "-" : "");
            return new TimeSpan
                (
                Convert.ToInt32(Text.Split(':')[0]),
                Convert.ToInt32(sSinal + Text.Split(':')[1]),
                Convert.ToInt32(sSinal + Text.Split(':')[2])
                );
        }
        #endregion

    }
}
