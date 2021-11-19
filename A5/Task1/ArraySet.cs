using System;
using System.Collections;

namespace A5.Task1
{
	public class ArraySet<T> : ISet<T>
	{
		private T[] data;
		private int numItems;

		public ArraySet() : this(20) { }

		public ArraySet(int size)
		{
			data = new T[size];
		}

        public bool add(T value)
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

        public void addMany(params T[] args)
		{
            foreach (T i in args)
			{
				add(i);
			}
		}

		public void addAll(ISet<T> otherSet)
		{
			foreach (T i in otherSet)
			{
				add(i);
			}
		}

		public bool remove(T value)
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

        public bool contains(T target)
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

		public T get(int index)
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
			var newData = new T[numItems];
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

		public bool equals(Object other)
		{
			if (this == other)
			{
				return true;
			}
			if (other == null)
			{
				return false;
			}
			if (other.GetType() != typeof(ISet<T>))
			{
				return false;
			}
			ISet<T> set = (ISet<T>)other;
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
			var newData = new T[newSize];
			for (int i = 0; i < data.Length; ++i)
			{
				newData[i] = data[i];
			}
			data = newData;
		}
	}
}
