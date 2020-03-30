using System;

namespace HR.Share.PublicShare.ExtendsClass
{
    public class DisposePatternSample : IDisposable
    {
        private bool _isDisposed;//是否已释放了资源，true时方法都不可用了。

        public DisposePatternSample()
        {
            _isDisposed = false;
        }

        public void MethodSample()
        {
            if (_isDisposed)
                throw new ObjectDisposedException("inner resource is disposed.");
            Console.WriteLine("MethodSample is called.");
        }

        /// <summary>
        /// 为继承类释放时使用
        /// <remarks>
        /// Note:这儿为什么要写成虚方法呢？
        /// 1. 为了让派生类清理自已的资源。将销毁和析构的共同工作提取出来，并让派生类也可以释放其自已分配的资源。
        /// 2. 为派生类提供了根据Dispose()或终结器的需要进行资源清理的必要入口。
        /// </remarks>
        /// </summary>
        /// <param name="isDisposing"></param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (_isDisposed) return;

            if (isDisposing)
            {
                //释放托管资源
                //（由CLR管理分配和释放的资源，即由CLR里new出来的对象）
                //TODO: other code
            }

            //释放非托管资源
            //(不受CLR管理的对象，windows内核对象，如文件、数据库连接、套接字、COM对象等)
            //TODO: other code

            _isDisposed = true;
        }

        #region IDisposable 成员

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        ///// <summary>
        ///// 如果没有非托管资源，不要实现它
        ///// </summary>
        //~DisposePatternSample()
        //{
        //    Dispose(false);
        //}
    }


    public class DrivedDisposePatternSample : DisposePatternSample
    {
        private bool _isDisposed = false; //各类维护自已的释放状态，把可能出现的错误限制在类本身

        /// <summary>
        /// 子类清理自已的资源时使用
        /// </summary>
        /// <param name="isDisposing"></param>
        protected override void Dispose(bool isDisposing)
        {
            if (_isDisposed) return;
            if (isDisposing)
            {
                //释放托管资源
                //（由CLR管理分配和释放的资源，即由CLR里new出来的对象）
                //TODO: other code
            }

            //释放非托管资源
            //(不受CLR管理的对象，windows内核对象，如文件、数据库连接、套接字、COM对象等)
            //TODO: other code

            //基类释放资源
            //基类负责调用GC.SuppressFinalize()
            base.Dispose(isDisposing);

            _isDisposed = true;
        }

        ///// <summary>
        ///// 如果没有非托管资源，不要实现它
        ///// </summary>
        //~DrivedDisposePatternSample()
        //{
        //    Dispose(false);
        //}

    }
}
