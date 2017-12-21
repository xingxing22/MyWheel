using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CommonHelper
    {
        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string SBCToDBC(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)//12288全角空格ASCII码
                {
                    c[i] = (char)32;//半角空格ASCII码
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)//全角字符的临界值
                {
                    c[i] = (char)(c[i] - 65248);//半角字符的临界值
                }
            }
            return new String(c);
        }

        /// <summary>
        /// 写文件
        /// </summary>
        public static void WriteFile(string path,string filename)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string file = string.Format(@"{0}\{1}", path, filename);
            using (StreamWriter sw = new StreamWriter(file, true))
            {
                for (int i = 0; i < 10; i++)
                {
                    string str = string.Format("{0}\t{1}", i, i * i);
                    sw.WriteLine(str);
                    Console.WriteLine(str);
                }
                sw.Close();
            }
        }

        /// <summary>
        /// 省份证号码校验
        /// </summary>
        /// <param name="card_no"></param>
        /// <returns></returns>
        public static double CdCardCheck(string card_no)
        {
            string yinzi = string.Empty;
            var cardchar = card_no.Substring(0, card_no.Length - 1).ToArray();
            double sum = 0;
            for (int i = 0; i < card_no.Length - 1; i++)
            {
                double value = Math.Pow(2, card_no.Length - 1 - i);
                double mod = value % 11;
                Console.WriteLine(mod);
                sum += mod * Convert.ToDouble(cardchar[i].ToString());
            }
            var mod2 = sum % 11;
            var mod3 = (12 - mod2) % 11;

            return mod3;
            
        }

        /// <summary>
        /// 时间转换
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static long DateTimeToLong(DateTime date)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = date.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
            return (long)ts.TotalMilliseconds;
        }

        /// <summary>
        /// 获取当前运行服务器外网ip
        /// </summary>
        /// <returns></returns>
        public static string GetIp2()
        {
            string outerIp = string.Empty;
            TcpClient c = new TcpClient();
            c.Connect("www.baidu.com", 80);
            outerIp = ((System.Net.IPEndPoint)c.Client.LocalEndPoint).Address.ToString();
            c.Close();
            return outerIp;
        }
    }
}
