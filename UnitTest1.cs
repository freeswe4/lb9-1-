using lb9;
namespace UnitTestsLb9
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodCostructorAndExpOper1()
        {
            //Arrange
            //Act
            CarParking carP = new CarParking(259, 10000);
            int result = (int)carP;
            //Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethodCostructorAndExpOper2()
        {
            //Arrange
            //Act
            CarParking carP = new CarParking(259, 9);
            int result = (int)carP;
            //Assert
            Assert.AreEqual(result, 199);
        }

        [TestMethod]
        public void TestMethodCostructor2()
        {
            //Arrange
            CarParking carP1 = new CarParking();
            CarParking carP2 = new CarParking(carP1);
            //Act
            CarParking carP3 = carP1 + carP2;
            //Assert
            Assert.AreEqual(carP3.NumCars, carP2.NumCars + carP1.NumCars);
            Assert.AreEqual(carP3.NumSlots, carP2.NumSlots + carP1.NumSlots);
        }
        [TestMethod]
        public void TestMethodInc()
        {
            //Arrange
            CarParking carP1 = new CarParking();
            CarParking carP2 = new CarParking(carP1);
            //Act
            carP2++;
            //Assert
            Assert.AreEqual(carP2.NumSlots, carP1.NumSlots);
            Assert.AreEqual(carP2.NumCars, carP1.NumCars + 1);
        }

        [TestMethod]
        public void TestMethodPercentagAndCompare1()
        {
            //Arrange
            CarParking carP1 = new CarParking(17, 13);
            CarParking carP2 = new CarParking(13, 13);
            //Act
            bool result = carP1 > carP2; ;
            //Assert
            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void TestMethodPercentag()
        {
            //Arrange
            CarParking carP1 = new CarParking(17, 13);
            //Act
            double result = carP1.PercentageOfCars();
            //Assert
            Assert.AreEqual(result, 76.47);
        }

        [TestMethod]
        public void TestMethodDec()
        {
            //Arrange
            CarParking carP1 = new CarParking();
            CarParking carP2 = new CarParking(carP1);
            //Act
            carP2--;
            //Assert
            Assert.AreEqual(carP2.NumSlots, carP1.NumSlots);
            Assert.AreEqual(carP2.NumCars, carP1.NumCars - 1);
        }

        [TestMethod]
        public void TestMethodPercentagAndCompare2()
        {
            //Arrange
            CarParking carP1 = new CarParking(17, 13);
            CarParking carP2 = new CarParking(13, -13);
            //Act
            bool result = carP1 < carP2;
            //Assert
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void TestMethodImplBool()
        {
            //Arrange
            CarParking carP = new CarParking(1000000000, 12424);
            //Act
            bool result = carP;
            //Assert
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethodOutput()
        {
            int result1 = CarParking.GetCount;
            CarParking carP = new CarParking();
            //Act
            int result2 = CarParking.GetCount;
            //Assert
            Assert.AreEqual(result2 - result1, 1);
        }
    }
}