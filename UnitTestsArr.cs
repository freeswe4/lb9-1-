using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lb9;

namespace UnitTestsLb9
{
    [TestClass]
    public class UnitTestsArr
    {
        [TestMethod]
        public void TestMethodConstructor()
        {
            //Arrange
            CarParkingArray carPArr = new CarParkingArray();
            CarParkingArray carPArrCop = new CarParkingArray(carPArr);
            //Act
            CarParking carP = carPArrCop[2];
            //Assert
            Assert.AreEqual(carP.NumCars, carPArrCop[2].NumCars);
            Assert.AreEqual(carP.NumSlots, carPArrCop[2].NumSlots);
        }

        [TestMethod]
        public void TestMethodConstructorWithArg()
        {
            //Arrange
            CarParkingArray carrPArr = new CarParkingArray(10);
            //Assert
            Assert.ThrowsException<IndexOutOfRangeException>(()=>carrPArr[100]);
        }

        [TestMethod]
        public void TestMethodOutput()
        {
            //Arrange
            CarParkingArray carPArr = new CarParkingArray();
            //Act
            string resultFunc = carPArr.Show();
            string resultMethod = "";
            for (int i = 0; i < carPArr.Length; i++)
                resultMethod += (carPArr[i].Show() + "\n");
            //Assert
            Assert.AreEqual(resultFunc, resultMethod);
        }

        [TestMethod]
        public void TestMethodCountObj()
        {
            int result1 = CarParkingArray.GetCountArr;
            CarParkingArray carPArr = new CarParkingArray();
            int result2 = CarParkingArray.GetCountArr;
            Assert.AreEqual(result2 - result1, 1);
        }

        [TestMethod]
        public void TestMethodFuncOfProgram()
        {
            //Arrange
            CarParkingArray carPArr = new CarParkingArray();
            //Act
            int result = Program.CarParkingMin(carPArr);
            //Assert
            Assert.AreEqual(result, carPArr[carPArr.Length - 1].NumSlots - carPArr[carPArr.Length - 1].NumCars);
        }

        [TestMethod]
        public void TestMethodOfInputDataClass()
        {
            //Arrange
            int num = 23, min = 0, max = System.Array.MaxLength;
            //Act
            bool result = InputData.IntValidate(num, min, max);
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethodConstructorWithArg2()
        {
            //Arrange
            CarParkingArray carrPArr = new CarParkingArray(10);
            //Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => carrPArr[100] = new(100,99));
        }
    }
}
