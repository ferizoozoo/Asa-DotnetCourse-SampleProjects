using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using ASa.ApartmentManagement.Core.BaseInfo.Managers;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.Core.Test
{
    public class BuildingManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }



        [Test]
        public void RUN_Just_For_Test()
        {
            //A
            BuildingManager buildingManager = new BuildingManager();
            int a = 10;
            int b = 15;
            //A

            var result = buildingManager.JustForTest(a, b);
            //A
            Assert.AreEqual(a + b, result);
        }

        [Test]
        public async Task Building_Name_Cannot_Be_Null_Or_Empty()
        {
            //A => Arange

            BuildingManager buildingManager = new BuildingManager();
            BuildingDTO building = new BuildingDTO { Id = 0, Name = string.Empty, NumberOfUnits = 10 };
            //A => Act
            //A => Assert
            Assert.CatchAsync(() => buildingManager.AddBuilding(building));

            //AsyncTestDelegate asyncTestDelegate = DoMyAcgtion;
            //Assert.CatchAsync(asyncTestDelegate);
        }
        
        //FAKE Mock Stub Dummy
        //Autofac

        //private async Task DoMyAcgtion()
        //{
        //    BuildingManager buildingManager = new BuildingManager();
        //    BuildingDTO building = new BuildingDTO { Id = 0, Name = string.Empty, NumberOfUnits = 10 };
        //    await buildingManager.AddBuilding(building);
        //}
    }
}