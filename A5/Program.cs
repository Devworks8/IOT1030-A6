using System;

using A5.Task1;

namespace A5
{
	class Program
	{
		static void Main(string[] args)
		{
			var list = new DoublyLinkedList();

			list.addFront(2);
			list.addBack(3);
			list.addFront(1);
			list.addBack(4);

			for (int i = 0; i < 4; ++i)
			{
				Console.WriteLine(list.removeBack());
			}

			var test = new int[10];
			test[0] = 1;

			foreach (var item in test)
			{
				Console.WriteLine(item);
			}
		}
	}
}
