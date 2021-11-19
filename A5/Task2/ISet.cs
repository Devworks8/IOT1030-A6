using System.Collections.Generic;

namespace A5.Task2
{
	/**
	 * The Set interface is meant for a simple collection of unordered elements. 
	 * A set does not allow for duplicates. 
	 */
	public interface ISet<T>
	{
		/// <summary>
		/// Adds a single element into the set
		/// </summary>
		/// <param name="value">The element to add to the set</param>
		/// <returns>True if the element was added, false otherwise</returns>
		bool add(T value);
		/// <summary>
		/// Adds all of the specified elements into the set
		/// </summary>
		/// <param name="args">The elements to add to the set</param>
		void addMany(params T[] args);
		/// <summary>
		/// Add all the elements from another set to this set
		/// </summary>
		/// <param name="otherSet">The other set who's contents will be added to the current set</param>
		void addAll(ISet<T> otherSet);
		/// <summary>
		/// Removes the specific value from the set
		/// </summary>
		/// <param name="value">The value to remove from the set</param>
		/// <returns>True is the value was removed, false otherwise</returns>
		bool remove(T value);
		/// <summary>
		/// Determines if a specified element exists within the set
		/// </summary>
		/// <param name="target">The element to search for</param>
		/// <returns>True if the element exists, false otherwise</returns>
		bool contains(T target);
		/// <summary>
		/// Gets the element at the specified index
		/// </summary>
		/// <param name="index">The index of the element</param>
		/// <returns>The element at the specified index</returns>
		T get(int index);
		/// <summary>
		/// Gets the current number of elements within the set
		/// </summary>
		/// <returns>The number of elements within the set</returns>
		int size();
		/// <summary>
		/// Determines if the set is empty
		/// </summary>
		/// <returns>True if the set is empty, False otherwise.</returns>
		bool isEmpty();
		/// <summary>
		/// Removes all the elements from the set
		/// </summary>
		void clear();
	}
}
