using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console.main.设计思想
{
    class IocAndDITest
    {
        static void Main(string[] args)
        {
            #region 手动构造函数注入方式调用          
            //Order order = new Order(new SqlDal());
            //order.Add();
            #endregion

            #region 手动属性注入方式调用      
            //Order order = new Order();
            //order.Idal = new SqlDal();
            //order.Add();
            #endregion

            #region 手动接口注入方式调用    
            //Order order = new Order();
            //order.SetDepend(new SqlDal());
            //order.Add();
            #endregion
        }
    }
    /// <summary>
    /// 数据访问接口
    /// </summary>
    public interface IDal
    {
        void Add();
    }

    /// <summary>
    /// 接口注入,需要Ioc的类必须实现该接口
    /// </summary>
    public interface IDependent
    {
        void SetDepend(IDal idal);
    }
    /// <summary>
    /// MySql数据访问
    /// </summary>
    class MySqlDal : IDal
    {
        public void Add()
        {
            Console.WriteLine("向MySql数据库添加一条新订单");
        }
    }
    /// <summary>
    /// SqlServer数据访问
    /// </summary>
    class SqlDal : IDal
    {
        public void Add()
        {
            Console.WriteLine("向SQLServer数据库添加一条新订单");
        }
    }

    class Order : IDependent
    {
        private IDal _dal;

        public Order()
        {

        }

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="idal"></param>
        public Order(IDal idal)
        {
            _dal = idal;
        }

        /// <summary>
        /// 属性注入
        /// </summary>
        public IDal Idal
        {
            get { return _dal; }
            set { _dal = value; }
        }

        /// <summary>
        /// 接口注入:实现接口类中的方法实现依赖传递
        /// </summary>
        /// <param name="idal"></param>
        public void SetDepend(IDal idal)
        {
            _dal = idal;
        }

        public void Add()
        {
            _dal.Add();
        }
    }
}
