using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	public class LinkedSetTester
	{
		A5.Task1.ISet set = new A5.Task1.LinkedSet1();
		
		[TestMethod]
		public void add()
		{
			Assert.IsTrue(set.add(1));
			Assert.AreEqual(1, set.size());
			Assert.IsTrue(set.add(2));
			Assert.AreEqual(2, set.size());
			Assert.IsFalse(set.add(1));
			Assert.AreEqual(2, set.size());

			System.Console.Out.WriteLine("add method succeeded");
		}

		[TestMethod]
		public void remove()
		{
			Assert.IsTrue(set.add(1));
			Assert.IsTrue(set.add(2));
			Assert.IsFalse(set.remove(3));
			Assert.AreEqual(2, set.size());
			Assert.IsTrue(set.remove(1));
			Assert.AreEqual(1, set.size());

			System.Console.Out.WriteLine("remove method succeeded");
		}

		[TestMethod]
		public void contains()
		{
			set.add(1);
			set.add(2);
			Assert.IsTrue(set.contains(1));
			Assert.IsFalse(set.contains(3));

			System.Console.Out.WriteLine("contains method succeeded");
		}

		[TestMethod]
		public void sizes()
		{
			Assert.AreEqual(0, set.size());
			Assert.IsTrue(set.isEmpty());
			set.add(1);
			Assert.AreEqual(1, set.size());
			Assert.IsFalse(set.isEmpty());
			set.clear();
			Assert.AreEqual(0, set.size());
			Assert.IsTrue(set.isEmpty());

			System.Console.Out.WriteLine("sizes method succeeded");
		}

		[TestMethod]
		public void Equals()
		{
			A5.Task1.ArraySet otherSet = new A5.Task1.ArraySet();
			Assert.IsTrue(set.Equals(otherSet));
			otherSet.add(1);
			Assert.IsFalse(set.Equals(otherSet));
			set.add(1);
			Assert.IsTrue(set.Equals(otherSet));
			otherSet.remove(1);
			Assert.IsFalse(set.Equals(otherSet));
			for (var idx = 1; idx < 10; ++idx)
			{
				set.add(idx);
				otherSet.add(idx);
			}
			Assert.IsTrue(set.Equals(otherSet));
			set.remove(2);
			set.remove(3);
			otherSet.remove(3);
			otherSet.remove(2);
			Assert.IsTrue(set.Equals(otherSet));
			otherSet.clear();
			Assert.IsFalse(set.Equals(otherSet));

			System.Console.Out.WriteLine("Equals method succeeded");
		}
	}

	[TestClass]
	public class GenericLinkedSetTester
	{
		A5.Task2.ISet<double> set = new A5.Task2.ArraySet<double>();

		[TestMethod]
		public void add()
		{
			Assert.IsTrue(set.add(1));
			Assert.AreEqual(1, set.size());
			Assert.IsTrue(set.add(2));
			Assert.AreEqual(2, set.size());
			Assert.IsFalse(set.add(1));
			Assert.AreEqual(2, set.size());

			System.Console.Out.WriteLine("add method succeeded");
		}

		[TestMethod]
		public void remove()
		{
			Assert.IsTrue(set.add(1));
			Assert.IsTrue(set.add(2));
			Assert.IsFalse(set.remove(3));
			Assert.AreEqual(2, set.size());
			Assert.IsTrue(set.remove(1));
			Assert.AreEqual(1, set.size());

			System.Console.Out.WriteLine("remove method succeeded");
		}

		[TestMethod]
		public void contains()
		{
			set.add(1);
			set.add(2);
			Assert.IsTrue(set.contains(1));
			Assert.IsFalse(set.contains(3));

			System.Console.Out.WriteLine("contains method succeeded");
		}

		[TestMethod]
		public void sizes()
		{
			Assert.AreEqual(0, set.size());
			Assert.IsTrue(set.isEmpty());
			set.add(1);
			Assert.AreEqual(1, set.size());
			Assert.IsFalse(set.isEmpty());
			set.clear();
			Assert.AreEqual(0, set.size());
			Assert.IsTrue(set.isEmpty());

			System.Console.Out.WriteLine("sizes method succeeded");
		}

		[TestMethod]
		public void Equals()
		{
			A5.Task2.ArraySet<double> otherSet = new A5.Task2.ArraySet<double>();
			//A5.Task1.ArraySet otherSet = new A5.Task1.ArraySet();
			Assert.IsTrue(set.Equals(otherSet));
			otherSet.add(1);
			Assert.IsFalse(set.Equals(otherSet));
			set.add(1);
			Assert.IsTrue(set.Equals(otherSet));
			otherSet.remove(1);
			Assert.IsFalse(set.Equals(otherSet));
			for (var idx = 1; idx < 10; ++idx)
			{
				set.add(idx);
				otherSet.add(idx);
			}
			Assert.IsTrue(set.Equals(otherSet));
			set.remove(2);
			set.remove(3);
			otherSet.remove(3);
			otherSet.remove(2);
			Assert.IsTrue(set.Equals(otherSet));
			otherSet.clear();
			Assert.IsFalse(set.Equals(otherSet));

			System.Console.Out.WriteLine("Equals method succeeded");
		}

	}

}
