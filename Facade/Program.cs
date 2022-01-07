using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();

            Console.ReadLine();
        }
    }

    class Logging:ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }

    }

    class Caching:ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }

    }

    internal interface ICaching
    {
        void Cache();
    }

    internal interface ILogging
    {
        void Log();
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class Authorize: IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked");
        }

    }

    class CustomerManager
    {

        private CrossCuttingConcernFacde _concerns;
        public CustomerManager()
        {
            _concerns = new CrossCuttingConcernFacde();
        }

        public void Save()
        {
            _concerns.Logging.Log();
            _concerns.Caching.Cache();
            _concerns.Authorize.CheckUser();
            Console.WriteLine("Saved");

        }
    }

    class CrossCuttingConcernFacde
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;

        public CrossCuttingConcernFacde()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();


        }

    }

}
