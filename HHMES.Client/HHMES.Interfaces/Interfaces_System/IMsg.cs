

using System;
using System.Collections.Generic;
using System.Text;

namespace HHMES.Core
{
    /// <summary>
    /// ��Ϣ��ʾ�ӿ�
    /// </summary>
    public interface IMsg
    {
        /// <summary>
        /// ��ʾ��Ϣ
        /// </summary>
        /// <param name="msg"></param>
        void UpdateMessage(string msg);
    }
}
