/*
 * Use these method names
 * 
 * front <-------------------> Done
 * indexOf
 * add <---------------------> Done
 * empty <-------------------> Done
 * get <---------------------> Done
 * addFront <----------------> Done
 * remove <------------------> Done
 * addBack <-----------------> Done
 * back <--------------------> Done
 * removeFront <-------------> Done
 * size <--------------------> Done
 * clear <-------------------> Done
 * removeBack <--------------> Done
 * 
 */

using System;

namespace A5.Task1
{
	public class DoublyLinkedList
	{
		private class Node
		{
			public int data;
			public Node next;
			public Node previous;

			public Node(int data, Node next, Node previous)
			{
				this.data = data;
				this.next = next;
				if (next != null)
				{
					next.previous = this;
				}
				this.previous = previous;
				if (previous != null)
				{
					previous.next = this;
				}
			}
			public Node(int data, Node next) : this(data, next, null) { }
			public Node(int data) : this(data, null, null) { }
		}

		private Node head; // Start of the list
		private Node tail; // End of the list

		/// <summary>
		/// Add a new node to the front of the list
		/// </summary>
		/// <param name="value">The integer value stored in the new node</param>
		public void addFront(int value)
		{
			head = new Node(value, head);
			if (tail == null)
			{
				tail = head;
			}
		}

		/// <summary>
		/// Add a new node to the back of the list
		/// </summary>
		/// <param name="value">The integer value stored in the new node</param>
		public void addBack(int value)
		{
			tail.next = new Node(value, null, tail);
			tail = tail.next;
			if (head == null)
			{
				head = tail;
			}
		}

		/// <summary>
		/// Remove the first node
		/// </summary>
		/// <returns>Value of the front node</returns>
		public int removeFront()
		{
			if (head == null)
			{
				throw new InvalidOperationException("List is empty");
			}
			int temp = head.data;
			head = head.next;
			if (head != null)
			{
				head.previous = null;
			}
			else
			{
				tail = null;
			}
			return temp;
		}

		/// <summary>
		/// Remove the last node
		/// </summary>
		/// <returns>Value of the last node</returns>
		public int removeBack()
		{
			if (tail == null)
			{
				throw new InvalidOperationException("List is empty");
			}
			int temp = tail.data;
			tail = tail.previous;
			if (tail != null)
			{
				tail.next = null;
			}
			else
			{
				head = null;
			}
			return temp;
		}

		/// <summary>
		/// Add new node at given index
		/// </summary>
		/// <param name="value">Integer value stored in the node</param>
		/// <param name="index">Integer index to insert node at</param>
		public void add(int value, int index)
		{
			int numElems = size();
			if (index < 0 || index > numElems)
			{
				throw new IndexOutOfRangeException();
			}
			if (index == 0)
			{
				addFront(value);
			}
			else if (index == numElems)
			{
				addBack(value);
			}
			else
			{
				int count = 0;
				Node temp = head;
				while(count < index)
				{
					temp = temp.next;
					++count;
				}
				temp.next = new Node(value, temp.next, temp);
			}
		}

		/// <summary>
		/// Remove node atr given index
		/// </summary>
		/// <param name="index">Integer index value</param>
		/// <returns>The adjacent node</returns>
		public int remove(int index)
		{
			int numElems = size();
			if (index < 0 || index >= numElems)
			{
				throw new IndexOutOfRangeException();
			}
			if (index == 0)
			{
				return removeFront();
			}
			if (index == numElems - 1)
			{
				return removeBack();
			}

			int count = 0;
			Node temp = head;
			while (count < index - 1)
			{
				temp = temp.next;
				++count;
			}

			int tmp = temp.next.data;
			temp.next = temp.next.next;
			if (temp.next != null)
			{
				temp.next.previous = temp;
			}
			return tmp;
		}

		/// <summary>
		/// Return the size of the list
		/// </summary>
		/// <returns>Integer element count</returns>
		public int size()
		{
			int count = 0;
			Node temp = head;
			while (temp != null)
			{
				++count;
				temp = temp.next;
			}
			return count;
		}

		/// <summary>
		/// Return index of  where the given value is located
		/// </summary>
		/// <param name="value">Integer value</param>
		/// <returns>Integer index or -1 if not found</returns>
		public int indexOf(int value)
		{
			Node temp = head;
			int idx = 0;
			while (temp != null)
			{
				if (temp.data == value)
				{
					return idx;
				}
				temp = temp.next;
				++idx;
			}
			return -1;
		}

		
		/// <summary>
		/// Check if the list is empty
		/// </summary>
		/// <returns>Boolean</returns>
		public bool empty()
		{
			return head == null; 
		}

		/// <summary>
		/// Get value by index
		/// </summary>
		/// <param name="index">Integer index</param>
		/// <returns>Integer value of node found at index</returns>
		public int get(int index)
		{
			if (index < 0 || index >= size())
			{
				throw new IndexOutOfRangeException();
			}

			int count = 0;
			Node temp = head;
			while (count < index)
			{
				temp = temp.next;
				++count;
			}
			return temp.data;
		}

		/// <summary>
		/// Return the first node
		/// </summary>
		/// <returns>Integer value of node</returns>
		public int front()
		{
			if (head == null)
			{
				throw new InvalidOperationException("List is empty");
			}
			return head.data;
		}

		/// <summary>
		/// Return the last node
		/// </summary>
		/// <returns>Integer value of node</returns>
		public int back()
		{
			if (tail == null)
			{
				throw new InvalidOperationException("List is empty");
			}
			return tail.data;
		}

		/// <summary>
		/// Clear the list
		/// </summary>
		/// <returns>Nullifies the head and tail</returns>
		public void clear()
		{
			head = null;
			tail = null;
		}
	}
}
