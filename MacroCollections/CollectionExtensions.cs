using System;
using System.Collections.Generic;
using System.Linq;

namespace
MacroCollections
{


public static class
CollectionExtensions
{


/// <summary>
/// Find the ordinal position of the first item in a sequence matching specified criteria
/// </summary>
///
/// <returns>
/// The zero-based position of the first item matching <paramref name="criteria"/>
/// - OR -
/// <c>-1</c> if there are no matching items
/// </returns>
///
public static int
IndexOf<T>(this IEnumerable<T> sequence, Predicate<T> criteria)
{
    if (sequence == null) throw new ArgumentNullException(nameof(sequence));
    if (criteria == null) throw new ArgumentNullException(nameof(criteria));
    int pos = 0;
    foreach (var item in sequence)
    {
        if (criteria(item)) return pos;
        pos++;
    }
    return -1;
}
    

/// <summary>
/// Remove the specified number of items from the specified position in the list
/// </summary>
///
/// <exception cref="ArgumentNullException">
/// <paramref name="list"/> is <c>null</c>
/// </exception>
///
/// <exception cref="ArgumentOutOfRangeException">
/// <paramref name="count"/> is negative or greater than the number of items present at <paramref name="index"/>
/// </exception>
///
public static void
RemoveAt<T>(this IList<T> list, int index, int count)
{
    if (list == null) throw new ArgumentNullException("list");
    if (count < 0 || count > (list.Count - index)) throw new ArgumentOutOfRangeException(nameof(count));
    for (int i = 0; i < count; i++) list.RemoveAt(index);
}


/// <summary>
/// Insert item(s) into the list at the specified position
/// </summary>
///
/// <exception cref="ArgumentOutOfRangeException">
/// <paramref name="index"/> is not a valid index in the <paramref name="list"/>
/// </exception>
///
public static void
Insert<T>(this IList<T> list, int index, T item, params T[] moreItems)
{
    if (list == null) throw new ArgumentNullException(nameof(list));
    moreItems = moreItems ?? new T[0];
    var items = new[] { item }.Concat(moreItems);
    list.InsertRange(index, items);
}


/// <summary>
/// Insert items into the list at the specified position
/// </summary>
///
/// <exception cref="ArgumentOutOfRangeException">
/// <paramref name="index"/> is not a valid index in the <paramref name="list"/>
/// </exception>
///
public static void
InsertRange<T>(this IList<T> list, int index, IEnumerable<T> items)
{
    if (list == null) throw new ArgumentNullException(nameof(list));
    foreach (var item in items.Reverse())
    {
        list.Insert(index, item);
    }
}


/// <summary>
/// Add item(s) to the collection
/// </summary>
/// 
/// <exception cref="ArgumentNullException">
/// <paramref name="items"/> is <c>null</c>
/// </exception>
///
public static void
AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
{
    if (collection == null) throw new ArgumentNullException(nameof(collection));
    if (items == null) throw new ArgumentNullException(nameof(items));
    foreach (T item in items) collection.Add(item);
}


}
}
