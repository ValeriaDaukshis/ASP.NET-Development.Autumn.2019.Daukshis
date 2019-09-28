using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Hero elf = new Hero(new ElfFactory());
            elf.Hit(); 
        }

        abstract class Weapon
        {
            public abstract void Hit();
        } 
        
        class Arbalet : Weapon
        {
            public override void Hit()
            {
                Console.WriteLine("Стреляем из арбалета");
            }
        }
        
        abstract class HeroFactory
        { 
            public abstract Weapon CreateWeapon();
        }

        class ElfFactory : HeroFactory
        { 
            public override Weapon CreateWeapon()
            {
                return new Arbalet();
            }
        }
        class Hero
        {
            private Weapon weapon;
            public Hero(HeroFactory factory)
            {
                weapon = factory.CreateWeapon();
            }
            public void Hit()
            {
                weapon.Hit();
            }
        }
    }
}