using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;
using System.IO;
using System.Collections;
using System.Data;
using System.Net;
using System.Linq;

namespace HHMES.Common
{
    /// <summary>
    /// 公共单元
    /// </summary>
    public class Globals
    {
        public const string DEF_PROGRAM_NAME = "仓库智能管理系统";
        public const string DEF_DESIGNBY = "2016-2018";
        public const string DEF_DATE_FORMAT = "yyyy-MM-dd";// "dd/MM/yyyy";
        public const string DEF_LONE_DATE_FORMAT = "yyyy-MM-dd hh:mm:ss";//"dd/MM/yyyy hh:mm:ss";
        public const string DEF_YYYYMMDD = "yyyyMMdd";
        public const string DEF_YYYYMMDD_LONG = "yyyy-MM-dd";//"yyyy/MM/dd";
        public const string DEF_DATE_LONG_FORMAT = "yyyy-MM-dd hh:mm:ss";//"yyyy/MM/dd hh:mm:ss";                
        public const string DEF_NULL_DATETIME = "1900-1-1";
        public const string DEF_NULL_VALUE = "NULL";          
        public const string DEF_CURRENCY = "RMB";//预设货币
        public const string DEF_DECIMAL_FORMAT = "0.00"; //输出格式        
        public const string DEF_NO_TEXT = "*自动生成*";
        /// <summary>
        /// 系统数据库名。开发框架2.2版支持多帐套管理，帐套表定义在系统数据库。
        /// 打开登录窗体时加载帐套数据给用户选择。        
        /// 
        /// 帐套数据由系统管理员在后台配置，不提供配置窗体。
        /// </summary>
        public const string DEF_SYSTEM_DB = "HHMES.System";
        public const string DEF_MASTER_DB = "master";

        public const int DEF_DECIMAL_ROUND = 2;//四舍五入小数位

        public static string DEF_ClientIP()
        {
              return Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault<IPAddress>(a => a.AddressFamily.ToString().Equals("InterNetwork")).ToString();
        }
        
        public static  string DEF_ClientName()
        {
              return System.Environment.MachineName;
        }
        /// <summary>
        /// 加载Debug\Images目录下的的图片
        /// </summary>
        /// <param name="imgFileName">文件名</param>
        /// <returns></returns>
        public static Image LoadImage(string imgFileName)
        {
            string file = Application.StartupPath + @"\images\" + imgFileName;
            if (File.Exists(file))
                return Image.FromFile(file);
            else
                return null;
        }

        /// <summary>
        /// 加载Debug\Images目录下的的图片
        /// </summary>
        /// <param name="imgFileName">文件名</param>
        /// <returns></returns>
        public static Bitmap LoadBitmap(string imgFileName)
        {
            string file = Application.StartupPath + @"\images\" + imgFileName;

            if (File.Exists(file))
                return new Bitmap(Bitmap.FromFile(file));
            else
                return null;
        }

        /// <summary>
        /// 移除ＳＱＬ注入非法字符
        /// </summary>
        /// <param name="content">字符串内容</param>
        /// <param name="returnMaxLength">返回的长度，0长度为不处理．</param>
        /// <returns></returns>
        public static string RemoveInjection(string content, int returnMaxLength)
        {
            string replaced = content.Replace("'", "").Replace("@", "").Replace("0x", "");
            if (returnMaxLength == 0)
                return replaced;
            else
                return replaced.Substring(0, replaced.Length < returnMaxLength ? replaced.Length : returnMaxLength);
        }

        
    }
}
