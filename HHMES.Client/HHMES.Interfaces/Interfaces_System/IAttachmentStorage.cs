﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HHMES.Interfaces
{
    /// <summary>
    /// 业务单据附件存储策略
    /// </summary>
    public interface IAttachmentStorage
    {
        /// <summary>
        /// 附件的数据表
        /// </summary>
        DataTable AttachmentStorage { get; set; }

        /// <summary>
        /// 保存附件
        /// </summary>
        void Save();

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        void OpenFile(string fileName);

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        void DeleteFile(string fileName);

        /// <summary>
        /// 增加一个附件
        /// </summary>
        /// <param name="file">文件名</param>
        void AddFile(object file);

        /// <summary>
        /// 增加一个附件
        /// </summary>
        /// <param name="fileFullName">文件全名，完整路径</param>
        void AddFile(string fileFullName);

        /// <summary>
        /// 更新文件
        /// </summary>
        /// <param name="file">文件对象</param>
        void UpdateFile(object file);

        /// <summary>
        /// 文件另存为
        /// </summary>
        /// <param name="fileName">文件名</param>
        void SaveAs(string fileName);

        /// <summary>
        /// 文件是否已存在
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        bool Exists(string fileName);
    }

}
