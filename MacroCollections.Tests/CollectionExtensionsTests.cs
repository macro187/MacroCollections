using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MacroCollections.Tests
{


[TestClass]
public class
CollectionExtensionsTests
{


[TestMethod]
public void
IndexOf_Returns_Index_Of_First_Matching_Item()
{
    var list = new List<int>() { 0, 1, 1, 1 };
    Assert.AreEqual(1, list.IndexOf(i => i == 1));
}


[TestMethod]
public void
IndexOf_Returns_NegativeOne_When_Not_Found()
{
    var list = new List<int>() { 0, 1, 1, 1 };
    Assert.AreEqual(-1, list.IndexOf(i => i == 999));
}


[TestMethod]
public void
RemoveAt_Works_At_The_Beginning()
{
    var list1 = new List<int>() { 0, 1, 2, 3 };
    var list2 = new List<int>() {       2, 3 };
    list1.RemoveAt(0, 2);
    Assert.IsTrue(list1.SequenceEqual(list2));
}


[TestMethod]
public void
RemoveAt_Works_In_The_Middle()
{
    var list1 = new List<int>() { 0, 1, 2, 3 };
    var list2 = new List<int>() { 0,       3 };
    list1.RemoveAt(1, 2);
    Assert.IsTrue(list1.SequenceEqual(list2));
}


[TestMethod]
public void
RemoveAt_Works_At_The_End()
{
    var list1 = new List<int>() { 0, 1, 2, 3 };
    var list2 = new List<int>() { 0, 1       };
    list1.RemoveAt(2, 2);
    Assert.IsTrue(list1.SequenceEqual(list2));
}


[TestMethod]
public void
RemoveAt_Zero_Count_Does_Nothing()
{
    var list1 = new List<int>() { 0, 1, 2, 3 };
    var list2 = new List<int>() { 0, 1, 2, 3 };
    list1.RemoveAt(0, 0);
    Assert.IsTrue(list1.SequenceEqual(list2));
}


[TestMethod]
[ExpectedException(typeof(ArgumentOutOfRangeException))]
public void
RemoveAt_Negative_Count_Throws_ArgumentOutOfRangeException()
{
    var list1 = new List<int>() { 0, 1, 2, 3 };
    list1.RemoveAt(0, -1);
}


[TestMethod]
[ExpectedException(typeof(ArgumentOutOfRangeException))]
public void
RemoveAt_Excessive_Count_Throws_ArgumentOutOfRangeException()
{
    var list1 = new List<int>() { 0, 1, 2, 3 };
    list1.RemoveAt(0, list1.Count + 1);
}


[TestMethod]
public void
Insert_At_The_Beginning_Works()
{
    var list1 = new List<int>() {          3, 4 };
    var list2 = new List<int>() { 0, 1, 2, 3, 4 };
    list1.Insert(0, 0, 1, 2);
    Assert.IsTrue(list1.SequenceEqual(list2));
}


[TestMethod]
public void
Insert_In_The_Middle_Works()
{
    var list1 = new List<int>() { 0,          4 };
    var list2 = new List<int>() { 0, 1, 2, 3, 4 };
    list1.Insert(1, 1, 2, 3);
    Assert.IsTrue(list1.SequenceEqual(list2));
}


[TestMethod]
public void
Insert_At_The_End_Works()
{
    var list1 = new List<int>() { 0, 1          };
    var list2 = new List<int>() { 0, 1, 2, 3, 4 };
    list1.Insert(2, 2, 3, 4);
    Assert.IsTrue(list1.SequenceEqual(list2));
}


[TestMethod]
public void
AddRange_Nothing_Does_Nothing()
{
    ICollection<int> list1 = new List<int>() { 0, 1, 2, 3, 4 };
    ICollection<int> list2 = new List<int>() { 0, 1, 2, 3, 4 };
    list1.AddRange(new int[] {});
    Assert.IsTrue(list1.SequenceEqual(list2));
}


[TestMethod]
public void
AddRange_Works()
{
    ICollection<int> list1 = new List<int>() { 0,       3, 4 };
    ICollection<int> list2 = new List<int>() { 0, 1, 2, 3, 4 };
    list1.AddRange(new int[] { 1, 2 });
    Assert.IsTrue(list1.OrderBy(i => i).SequenceEqual(list2.OrderBy(i => i)));
}


}
}
