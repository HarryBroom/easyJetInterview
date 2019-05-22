using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Interview
{
    [TestFixture]
    public class Tests
    {
        private static readonly Repository Repo = new Repository();

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            var listOfFlights = new List<T>();
            listOfFlights.AddRange(new List<Flight>
            {
                new Flight { Id = 1, Type = "A321" },
                new Flight { Id = 2, Type = "A321N" },
                new Flight { Id = 3, Type = "A320B" },
                new Flight { Id = 4, Type = "A320A" },
                new Flight { Id = 5, Type = "A319" }
            });

            Repo.SaveAll(listOfFlights);
        }

        [Test]
        public void FindById()
        {
            var result = (Flight)Repo.FindById(1);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("A321", result.Type);
        }

        [Test]
        public void FindByIdDoesNotExist()
        {
            var result = Repo.FindById(10);
            Assert.IsNull(result);
        }

        [Test]
        public void DeleteShouldFailIfItemDoesNotExist()
        {
            var item = new Flight { Id = 10, Type = "A319" };
            Assert.Throws<InvalidOperationException>(() => Repo.Delete(item));
        }

        [Test]
        public void Delete()
        {
            var item = new Flight { Id = 5, Type = "A319" };
            Repo.Delete(item);
            Assert.IsNull(Repo.FindById(5));
        }

        [Test]
        public void Save()
        {
            var repo = new Repository();
            repo.Save(new Flight { Id = 1, Type = "A321" });
            var result = repo.FindById(1) as Flight;
            Assert.AreEqual(1, result?.Id);
            Assert.AreEqual("A321", result?.Type);
        }

        [Test]
        public void SaveShouldNotAllowDuplicates()
        {
            var repo = new Repository();
            repo.Save(new Flight { Id = 1, Type = "A321" });
            Assert.Throws<InvalidOperationException>(() => repo.Save(new Flight { Id = 1, Type = "A321" }));
        }

        [Test]
        public void SaveAllShouldAllowNotDuplicates()
        {
            var repo = new Repository();
           var flights = new List<T> { new Flight { Id = 1, Type = "A321" } , new Flight { Id = 1, Type = "A321" }, new Flight { Id = 1, Type = "A322" } };
            Assert.Throws<InvalidOperationException>(() => repo.SaveAll(flights));
        }


    }
}