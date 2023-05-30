using IExamSystemCore.Implementation;

namespace HashSetImplementationTests
{
    public class StripedCuckooHashSetImplementationTests
    {
        [Test]
        public void AddTest()
        {
            var iExamSystem = new StripedCuckooHashSetImplementation();

            for (int i = 0; i < 10; i++)
            {
                iExamSystem.Add(i, i + 1);
            }

            Assert.That(iExamSystem.Count, Is.EqualTo(10));
            Assert.IsTrue(iExamSystem.Contains(1, 2));
            Assert.IsFalse(iExamSystem.Contains(2, 1));
        }

        [Test]
        public void RemoveTest()
        {
            var iExamSystem = new StripedCuckooHashSetImplementation();

            for (int i = 0; i < 10; i++)
            {
                iExamSystem.Add(i, i + 1);
            }

            Assert.That(iExamSystem.Count, Is.EqualTo(10));
            Assert.IsTrue(iExamSystem.Contains(3, 4));

            for (int i = 2; i < 4; i++)
            {
                iExamSystem.Remove(i, i + 1);
            }

            Assert.That(iExamSystem.Count, Is.EqualTo(8));
            Assert.IsFalse(iExamSystem.Contains(2, 3));

        }

        [Test]
        public void CollisionTest()
        {
            var iExamSystem = new StripedCuckooHashSetImplementation();

            for (int i = 1; i < 5; i++)
            {
                iExamSystem.Add(i, i + 1);
            }

            iExamSystem.Remove(1, 2);

            for (int i = 2; i < 5; i++)
            {
                Assert.IsTrue(iExamSystem.Contains(i, i + 1));
            }
            Assert.IsFalse(iExamSystem.Contains(1, 2));
        }

        [Test]
        public void ResizeTest()
        {
            var iExamSystem = new StripedCuckooHashSetImplementation();

            for (int i = 0; i < 10; i++)
            {
                iExamSystem.Add(15 * i, 30 * i);
            }

            Assert.That(iExamSystem.Count, Is.EqualTo(10));
        }
    }
}