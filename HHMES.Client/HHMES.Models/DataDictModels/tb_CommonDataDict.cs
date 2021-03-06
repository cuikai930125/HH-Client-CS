﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HHMES.ORM;

namespace HHMES.Models
{


    /*==========================================
     *   程序说明: tb_CONFIG_DETAIL的ORM模型
     *   作者姓名: HHMES.com
     *   创建日期: 2018-03-09 10:38:53
     *   最后修改: 2018-03-09 10:38:53
     *   
     *   注: 本代码由ClassGenerator自动生成
     *   版权所有 HHMES.com
     *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:CONFIG_DETAIL,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("CONFIG_DETAIL", "ID", true)]
    public sealed class tb_CONFIG_DETAIL
    {
        public static string __TableName = "CONFIG_DETAIL";

        public static string __KeyName = "ID";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, true, false, false)]
        public static string ID = "ID";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, false, true, false)]
        public static string CONFIG_HEADERID = "CONFIG_HEADERID";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 100, false, true, false, false, false)]
        public static string CODE = "CODE";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 100, false, true, false, false, false)]
        public static string NAME = "NAME";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, false, false, false)]
        public static string SEQUENCE = "SEQUENCE";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 100, false, true, false, false, false)]
        public static string DESCRIPTION = "DESCRIPTION";

        [ORM_FieldAttribute(SqlDbType.Bit, 1, false, true, false, false, false)]
        public static string SYSTEMCREATED = "SYSTEMCREATED";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, false, false, false)]
        public static string ROUTE_HEADERID = "ROUTE_HEADERID";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 100, false, true, false, false, false)]
        public static string DEFINE01 = "DEFINE01";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 100, false, true, false, false, false)]
        public static string DEFINE02 = "DEFINE02";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 100, false, true, false, false, false)]
        public static string DEFINE03 = "DEFINE03";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 100, false, true, false, false, false)]
        public static string CREATEBY = "CREATEBY";

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public static string CREATETIME = "CREATETIME";

        [ORM_FieldAttribute(SqlDbType.NVarChar, 100, false, true, false, false, false)]
        public static string MODIFYBY = "MODIFYBY";

        [ORM_FieldAttribute(SqlDbType.DateTime, 8, false, true, false, false, false)]
        public static string MODIFYTIME = "MODIFYTIME";

        [ORM_FieldAttribute(SqlDbType.Bit, 1, false, true, false, false, false)]
        public static string ISDELETED = "ISDELETED";

    }
}