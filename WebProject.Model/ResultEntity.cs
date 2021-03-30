using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebProject.Model
{
    /// <summary>
    /// 泛型返回值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultEntity<T>
    {
        /// <summary>
        /// 成功或失败
        /// </summary>
        public bool IsOK { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }
    }
    /// <summary>
    /// 返回值
    /// </summary>
    public class ResultEntity
    {
        /// <summary>
        /// 成功或失败
        /// </summary>
        public bool IsOK { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }
    }
}
