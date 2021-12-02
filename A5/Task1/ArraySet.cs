using System;
using System.Collections;

namespace A5.Task1
{
	public class ArraySet : ISet
	{
		private int[] data;
		private int numItems;

		public ArraySet() : this(20) { }

		public ArraySet(int size)
		{
			data = new int[size];
		}

        public bool add(int value)
		{
            if (contains(value))
			{
                return false;
			}
			if (numItems == data.Length)
			{
				ensureCapacity(numItems * 2);
			}
			data[numItems++] = value;
            return true;
		}

        public void addMany(params int[] args)
		{
            foreach (int i in args)
			{
				add(i);
			}
		}

		public void addAll(ISet otherSet)
		{
			foreach (int i in otherSet)
			{
				add(i);
			}
		}

		public bool remove(int value)
		{
			int idx = 0;
			for (; idx < numItems && !(data[idx].Equals(value)); ++idx) ;

			if (idx == numItems)
			{
				return false;
			}
			--numItems;
			if (numItems > 0)
			{
				data[idx] = data[numItems];
			}
			return true;
		}

        public bool contains(int target)
		{
            for (int i = 0; i < numItems; ++i)
			{
                if (data[i].Equals(target))
				{
                    return true;
				}
			}
            return false;
		}

		public int get(int index)
		{
			if (index < numItems && index >= 0)
			{
				return data[index];
			}
			throw new IndexOutOfRangeException();
		}

		public int size()
		{
			return numItems;
		}

		public int capacity()
		{
			return data.Length;
		}

		public void shrinkToFit()
		{
			if (numItems == data.Length)
			{
				return;
			}
			var newData = new int[numItems];
			Array.Copy(data, 0, newData, 0, numItems);
			data = newData;
		}

		public void clear()
		{
			numItems = 0;
		}

		public bool isEmpty()
		{
			return numItems == 0;
		}

		public override string ToString()
		{
			String str = "ArraySet[";
			for (int i = 0; i < numItems; ++i)
			{
				str += data[i];
				if (i != numItems -1)
				{
					str += ", ";
				}
			}
			return str += "]";
		}

		public override bool Equals(Object other)
		{
			if (this == other)
			{
				return true;
			}
			if (other == null)
			{
				return false;
			}
			if (other.GetType() != typeof(ISet))
			{
				return false;
			}
			ISet set = (ISet)other;
			if (set.size() != size())
			{
				return false;
			}
			if (isEmpty())
			{
				return true;
			}
			for (int i = 0; i < numItems; ++i)
			{
				if (!set.contains(data[i]))
				{
					return false;
				}
			}
			return true;
		}

		public IEnumerator GetEnumerator()
		{
			for (int i = 0; i < numItems; ++i)
			{
				yield return data[i];
			}
		}

		private void ensureCapacity(int newSize)
		{
			var newData = new int[newSize];
			for (int i = 0; i < data.Length; ++i)
			{
				newData[i] = data[i];
			}
			data = newData;
		}
	}
}
