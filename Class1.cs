using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb9
{
    public class CarParking
    {
        int numSlots;
        int numCars;
        static int count = 0; //статическая переменная для подсчёта объектов

        public int NumSlots //свойство для парковки
        {
            get => numSlots;
            set {
                if (value < 0)
                {
                    numSlots = 1;
                    Console.WriteLine("Количество мест на парковке не может быть отрицательным");
                }
                else numSlots = value;
            }
        }

        public int NumCars //свойство для автомобилей
        {
            get => numCars;
            set
            {
                if (value < 0)
                {
                    numCars = 0;
                    Console.WriteLine("Количестов машин не может быть отрицательным");
                }
                if (value > numSlots)
                {
                    numCars = numSlots;
                    Console.WriteLine("Машин не может быть больше парковочных мест");
                }
                //if (numCars == 0 & numSlots == 0)
                  // Console.WriteLine("И мест и автомобилей по нулям, деление на ноль - фу");
                else numCars = value;
            }
        }

        public CarParking() //конструктор без параметров
        {
            NumSlots = 12;
            NumCars = 5;
            count++;
        }

        public CarParking(int numSlots, int numCars) //конструктор с параметрами (играет роль this)
        {
            NumSlots = numSlots;//поправил
            NumCars = numCars;
            count++;
        }

        public CarParking(CarParking carP) //конструктор копирования
        {
            NumSlots = carP.NumSlots;
            NumCars = carP.NumCars;
            count++;
        }

        //можно ещё созать: конструктор, который будет ссылаться на другой конструктор; конструктор, который будет ссылаться по одному парметру через this;
        //в основ проге можно сделать инициализатор

        public string Show()
        {
            return $"На стоянке {NumSlots} мест и {NumCars} автомобилей"; 
        }


        public double PercentageOfCars() //процент загруженности парковки (до 0.01) (нестатическая)
        {
            return Math.Round((double)NumCars/(double)NumSlots * 100, 2);
        }

        public static double PercentageOfCars(CarParking carP)  //процент загруженности парковки (до 0.01) (статическая)
        {
            return Math.Round((double)carP.NumCars / (double)carP.NumSlots * 100, 2);
        }

        public static CarParking operator ++(CarParking carP) //перегрузка инкремента
        {
            CarParking carPTemp = new CarParking(carP);
            carPTemp.NumCars++;
            return carPTemp;
        }

        public static CarParking operator --(CarParking carP) //перегрузка декремента
        {
            CarParking carPTemp = new CarParking(carP);
            carPTemp.NumCars--;
            return carPTemp;
        }

        public static explicit operator int(CarParking carP) //перегрзка типа int (явно)
        {
            if (carP.NumCars/ carP.NumSlots < 0.8)
            {
                return (int)(Math.Ceiling((double)carP.NumSlots * 0.8)) - carP.NumCars;
            }
            else return 0;
        }

        public static implicit operator bool(CarParking carP)  //перегрзка типа bool (неявно)
        {
            return carP.NumSlots != carP.NumCars;
        }

        public static CarParking operator +(CarParking carP1, CarParking carP2) //перегрзука сложения
        {
            CarParking tempInst = new CarParking();
            tempInst.NumSlots = carP1.NumSlots + carP2.NumSlots;
            tempInst.NumCars = carP1.NumCars + carP2.NumCars;
            return tempInst;
        }

        public static bool operator >(CarParking carP1, CarParking carP2) //перегрузка операции больше
        {
            return PercentageOfCars(carP1) < PercentageOfCars(carP2) && carP1.NumSlots > carP2.NumSlots;
        }

        public static bool operator <(CarParking carP1, CarParking carP2) //перегрузка операции меньше
        {
            return PercentageOfCars(carP1) > PercentageOfCars(carP2) && carP1.NumSlots < carP2.NumSlots;
        }

        public static int GetCount => count; //подсчёт объектов
    }
}
