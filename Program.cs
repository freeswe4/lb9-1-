namespace lb9
{
    public class Program
    {
        static void Main(string[] args)
        {
            int limElem = Array.MaxLength;
            int tempChooseNumHead;
            do
            {

                Console.WriteLine(@"Выберите действие:
1. Работа с классом одинарных парковок
2. Работа с коллекцией
3. Выход");
                Console.WriteLine();
                tempChooseNumHead = InputData.InputAndValidateInt("Введите номер команды", 1, 3);
                switch (tempChooseNumHead)
                {
                    case 1:
                        CarParking carP1 = new CarParking(); //экземпляр конструктора без параметров
                        Console.WriteLine(carP1.Show());

                        CarParking carP2 = new CarParking(InputData.InputAndValidateInt("Введите количество парковочных мест", 0, limElem), InputData.InputAndValidateInt("Введите количестов автомобилей на парковке", 0, limElem)); //экземпляр конструктора с параметрам
                                                                                                                                                                                                                  // вводим значения сами
                        Console.WriteLine(carP2.Show());

                        CarParking carP3 = new CarParking(12, 7); //экземпляр конструктора с параметрами
                        Console.WriteLine(carP3.Show());

                        double percentage1, percentage2, percentage3;

                        percentage1 = CarParking.PercentageOfCars(carP1); //статическая функция
                        Console.WriteLine($"Занято {percentage1}% парковки\n");

                        percentage2 = carP2.PercentageOfCars(); //нестатическая функция
                        Console.WriteLine($"Занято {percentage2}% парковки\n");

                        percentage3 = carP3.PercentageOfCars(); //нестатическая функция
                        Console.WriteLine($"Занято {percentage3}% парковки\n");

                        CarParking carP4 = new CarParking(12, 5); //экземпляр класса для прегрузки операции
                        Console.WriteLine(carP4.Show());

                        CarParking carPCop1 = new CarParking(carP4);
                        carPCop1++; //перегрузка операции инкремента
                        Console.WriteLine("После прибалвения одного автомобиля");
                        Console.WriteLine(carPCop1.Show());

                        CarParking carPCop2 = new CarParking(carPCop1);
                        carPCop2--; //перегрузка операции декремента
                        Console.WriteLine("После убавления одного автомобиля");
                        Console.WriteLine(carPCop2.Show());
                        Console.WriteLine();

                        CarParking carP5 = new CarParking(19, 7);
                        Console.WriteLine(carP5.Show());
                        int overLoad1 = (int)carP5; //перегрзука явно
                        Console.WriteLine($"Необходимо {overLoad1} автомобилей до загруженности парковки на 80%\n");

                        CarParking carP6 = new CarParking(19, 9);
                        Console.WriteLine(carP6.Show());
                        bool overLoad2 = carP6; //перегрузка неявно
                        if (overLoad2 == true)
                            Console.WriteLine("На парквоке есть свободные места\n");
                        else Console.WriteLine("Парковка полностью заполнена\n");

                        CarParking carP7 = new CarParking(367, 235);
                        CarParking carP8 = new CarParking(435, 200);
                        Console.WriteLine(carP7.Show());
                        Console.WriteLine(carP8.Show());
                        CarParking carP9 = carP7 + carP8; //перегрзука операции сложения
                        Console.WriteLine($"Объединяя две парковки получаем: {carP9.NumSlots} парковочных мест и {carP9.NumCars} автомобилей\n");
                        if (carP7 > carP8) //перегрузка операции больше
                            Console.WriteLine("На парковке cp1 загруженность ниже и общее количество мест больше, чем на парковке cp2\n");
                        if (carP7 < carP8) //перегрузка операции меньше
                            Console.WriteLine("На парковке cp1 загруженность выше и общее количество мест меньше, чем на парковке cp2\n");
                        break;

                    case 2:
                        CarParkingArray carPArr1 = new CarParkingArray(); //конструктор коллекции без параметров
                        Console.WriteLine("В первом массиве парковок");
                        for (int i = 0; i < carPArr1.Length; i++) //вывод элементов коллекции с помощю функции класса Class1
                            Console.WriteLine(carPArr1[i].Show());
                        Console.WriteLine();

                        CarParkingArray carPArr2 = new CarParkingArray(5); //конструктор коллекции с параметром (длина)
                        Console.WriteLine("Во втором массиве парковок");
                        for (int i = 0; i < carPArr2.Length; i++) //вывод элементов коллекции с помощю функции класса Class1
                            Console.WriteLine(carPArr2[i].Show());

                        int minParking = CarParkingMin(carPArr2); //вызов функции вычисления свободных мест на самой малозагруженной парковке
                        if (minParking == 0)
                            Console.WriteLine("Все парквоки загружены максимально\n");
                        else
                            Console.WriteLine($"Количество свободных парковочных мест на самой малозагруженной парковке равно {minParking}\n");

                        CarParkingArray carPArr3 = new CarParkingArray(carPArr2); //конструктор глубокого копирования коллекции
                        Console.WriteLine("В третьем массиве парковок(глубокое копирование)");
                        for (int i = 0; i < carPArr3.Length; i++) //вывод элементов коллекции с помощю функции класса Class1
                            Console.WriteLine(carPArr3[i].Show());
                        Console.WriteLine();

                        for (int i = 0; i < carPArr3.Length; i++) //ввод элементов массива с помощью ввода
                        {
                            carPArr3[i] = new(InputData.InputAndValidateInt($"Введите количество парковочных мест на {i + 1} парковке", 0, limElem), InputData.InputAndValidateInt($"Введите количество машин на {i + 1} парковке", 0, limElem));
                        }
                        for (int i = 0; i < carPArr3.Length; i++)
                            Console.WriteLine(carPArr3[i].Show());
                        Console.WriteLine();

                        Console.WriteLine($"Создано {CarParking.GetCount} объектов класса CapParking\n"); //вывод количества объектов класса Class1
                        Console.WriteLine($"Создано {CarParkingArray.GetCountArr} объектов класса CapParkingArray\n"); //вывод количества объектов класса CarParkingArray

                        try
                        {
                            carPArr2[0] = new(200, 5); //запись нового объекта по существующему индексу
                            for (int i = 0; i < carPArr2.Length; i++) //вывод элементов коллекции с перезаписанными элементами с помощю функции класса Class1 
                                Console.WriteLine(carPArr2[i].Show());
                            Console.WriteLine();
                            carPArr2[100] = new(100, 20); //запись объекта по несуществующему индексу
                            Console.WriteLine(carPArr2[100]);

                            Console.ReadLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Конец работы");
                        }
                        break;

                    default: break;
                }   
            } while (tempChooseNumHead != 3);
            Console.WriteLine("До свидания");
        }

        public static int CarParkingMin(CarParkingArray carPArr) //функция вычисления свободных мест на самой малозагруженной парковке
        {
            double minNumCarParking = 100; //максимально возможная загруженность
            CarParking tempElemArr = carPArr[0]; //вспомогательная переменная для поиска минимальной загруженности
            for (int i = 0; i < carPArr.Length; i++)
            {
                if (CarParking.PercentageOfCars(carPArr[i]) < minNumCarParking) //если загруженность парковки текущей парковки меньше минимальной
                {
                    tempElemArr = carPArr[i];
                    minNumCarParking = CarParking.PercentageOfCars(tempElemArr); //минимальная загруженность становится равна загруженности текущего элемента
                }
            }
            return (tempElemArr.NumSlots - tempElemArr.NumCars); //вывод свободных мест
        }
    }
}
