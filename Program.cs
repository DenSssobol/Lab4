using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class SportEquipment
    {
        private int countHoop;
        private int countBall;
        private int countJumpRope;
        private int countTShirt;
        private int countWhistle;
        public SportEquipment()//конструктор по умолчанию
        {

        }
        //присваиваем полям значения
        public SportEquipment(int countHoop, int countBall, int countJumpRope, int countTShirt, int countWhistle)
        {
            this.countHoop = countHoop;
            this.countBall = countBall;
            this.countJumpRope = countJumpRope;
            this.countTShirt = countTShirt;
            this.countWhistle = countWhistle;
        }
        //свойства на чтение полей
        public int GetCountHoop
        {
            get { return countHoop; }
        }
        public int GetCountBall
        {
            get { return countBall; }
        }
        public int GetCountJumpRope
        {
            get { return countJumpRope; }
        }
        public int GetCountTShirt
        {
            get { return countTShirt; }
        }
        public int GetCountWhistle
        {
            get { return countWhistle; }
        }
        
        //метод который возвращает отсортированый массив по количеству обручей
        public SportEquipment[] SortByCountHoop(SportEquipment[] array)
        {
            Array.Sort(array, new SortCountHoop());
            return array;
        }
        //метод который возвращает отсортированый(реверс) массив по количеству мячей
        public SportEquipment[] SortReverseByCountBall(SportEquipment[] array)
        {
            Array.Sort(array, new SortReverseCountBall());
            return array;
        }
    }
    //два вспомогательных класса которые наследуют и реализуют интерфейс, который говорит сортировке как сортировать
    class SortCountHoop : IComparer<SportEquipment>
    {
        public int Compare(SportEquipment s1, SportEquipment s2)
        {
            if (s1.GetCountHoop > s2.GetCountHoop)
            {
                return 1;
            }
            else if (s1.GetCountHoop < s2.GetCountHoop)
            {
                return -1;
            }
            else
                return 0;
        }
    }
    class SortReverseCountBall : IComparer<SportEquipment>
    {
        public int Compare(SportEquipment s1, SportEquipment s2)
        {
            if (s1.GetCountBall > s2.GetCountBall)
            {
                return -1;
            }
            else if (s1.GetCountBall < s2.GetCountBall)
            {
                return 1;
            }
            else
                return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //инстанцируем класс рандом
            Random random = new Random();

            //массив объектов типа "спортИнвентарь"
            SportEquipment[] sportEquipment = new SportEquipment[10];

            //заполняем массив 
            for (int i = 0; i < sportEquipment.Length; i++)
            {
                sportEquipment[i] = new SportEquipment(random.Next(1, 51), random.Next(1, 51), random.Next(1, 51), random.Next(1, 51), random.Next(1, 51));
            }
            //экземпляр чисто для сортировки
            SportEquipment instanceForSorting = new SportEquipment();

            //отсортированный массив по количеству обручей
            SportEquipment[] sortHoop = instanceForSorting.SortByCountHoop(sportEquipment);
            Console.WriteLine("Sorting by count of hoop:");
            for (int i = 0; i < sortHoop.Length; i++)
            {
                Console.WriteLine(sortHoop[i].GetCountHoop);
            }

            //отсортированый(реверс) массив по количеству мячей
            SportEquipment[] sortReverseBall = instanceForSorting.SortReverseByCountBall(sportEquipment);
            Console.WriteLine("Reverse sort by count of ball:");
            for (int i = 0; i < sortReverseBall.Length; i++)
            {
                Console.WriteLine(sortReverseBall[i].GetCountBall);
            }
            Console.ReadKey();
        }
    }
}
