using System;
using System.Collections;
using System.Text;

namespace A5.Task1
{
	public class LinkedSet1 : ISet<int>
	{
		private DoublyLinkedList data = new DoublyLinkedList();

		public bool add(int value)
		{
			try
			{
				if (data.indexOf(value) != -1) { return false; }
				
				data.addFront(value);
				return true;
			}
			catch { return false; } 
		}

		public void addMany(params int[] args)
		{
			foreach(var arg in args) { this.add(arg); }
		}

		public void addAll(ISet<int> otherSet)
		{
			foreach (int node in otherSet) { this.add(node); }
		}

		public bool remove(int value)
		{
			try
			{
				data.remove(data.indexOf(value));
				return true;
			}
			catch { return false; }
		}

		public bool contains(int target)
		{
			return data.indexOf(target) != -1;
		}

		public int get(int index)
		{
			return data.get(index);
		}

		public int size()
		{
			return data.size();
		}

		public bool isEmpty()
		{
			return data.empty();
		}

		public void clear()
		{
			data.clear();
		}

		public String toString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("LinkedSet[");

			for (int i = 0; i < data.size(); ++i) 
			{ 
				sb.Append(data.get(i)); 
				if (i < data.size()) { sb.Append(", "); }
			}
			sb.Append(']');

			return sb.ToString();
		}

		public override bool Equals(Object other)
		{
			ISet<int> set = (ISet<int>)other;

			if (data == other) { return true; }
			if (other == null)  { return false; }
			if (data.size() != set.size()) { return false; }

			for (int i = 0; i < data.size(); ++i)
			{
				if (!set.contains(data.get(i))) { return false; }
			}
			return true; 
		}
		public IEnumerator GetEnumerator()
		{
			for (int i = 0; i < data.size(); ++i) { yield return data.get(i); }
        }
	}

}
