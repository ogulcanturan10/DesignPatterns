﻿using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar { Make="BMW",Model="3.20",HirePrice=2500};
            SpecialOffer specialOffer = new SpecialOffer(personalCar);
            specialOffer.DiscountPercantage = 10;

            Console.WriteLine("Concrete: {0}", personalCar.HirePrice);
            Console.WriteLine("Special offer : {0}", specialOffer.HirePrice);

            Console.ReadLine();
        }
    }

    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }

    }

    class PersonalCar : CarBase
    {
        public override string Make { get ; set ; }
        public override string Model { get ; set ; }
        public override decimal HirePrice { get ; set ; }
    }

    class Commercial : CarBase
    {
        public override string Make { get ; set ; }
        public override string Model { get ; set ; }
        public override decimal HirePrice { get ; set ; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            this.carBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase

    {
        public int DiscountPercantage { get; set; }
        private readonly CarBase _carBase;

        public SpecialOffer(CarBase carBase) : base(carBase)
        {
           _carBase = carBase;
        }


        public override string Make { get ; set ; }
        public override string Model { get ; set ; }
        public override decimal HirePrice { get 
            { return _carBase.HirePrice- _carBase.HirePrice*DiscountPercantage/100;} 
            set { } 
        }
    }

}
