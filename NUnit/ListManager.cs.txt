using System;
using System.Collections.Generic;
using NUnit.Framework;

public class ListManager
{
    public void AddElement(List<int> list, int element)
    {
        if (list == null) throw new ArgumentNullException(nameof(list));
        list.Add(element);
    }

    public bool RemoveElement(List<int> list, int element)
    {
        if (list == null) throw new ArgumentNullException(nameof(list));
        return list.Remove(element);
    }

    public int GetSize(List<int> list)
    {
        if (list == null) throw new ArgumentNullException(nameof(list));
        return list.Count;
    }
}

[TestFixture]
public class ListManagerTests
{
    private ListManager _listManager;
    private List<int> _testList;

    [SetUp]
    public void Setup()
    {
        _listManager = new ListManager();
        _testList = new List<int>();
    }

    [Test]
    public void AddElement_ShouldIncreaseListSize()
    {
        _listManager.AddElement(_testList, 10);
        Assert.AreEqual(1, _listManager.GetSize(_testList));

        _listManager.AddElement(_testList, 20);
        Assert.AreEqual(2, _listManager.GetSize(_testList));
    }

    [Test]
    public void RemoveElement_ShouldDecreaseListSize()
    {
        _listManager.AddElement(_testList, 10);
        _listManager.AddElement(_testList, 20);
        _listManager.AddElement(_testList, 30);
        
        Assert.AreEqual(3, _listManager.GetSize(_testList));

        bool isRemoved = _listManager.RemoveElement(_testList, 20);
        Assert.IsTrue(isRemoved);
        Assert.AreEqual(2, _listManager.GetSize(_testList));
    }

    [Test]
    public void RemoveElement_ShouldReturnFalseIfElementNotFound()
    {
        _listManager.AddElement(_testList, 10);
        bool isRemoved = _listManager.RemoveElement(_testList, 99);
        Assert.IsFalse(isRemoved);
    }

    [Test]
    public void GetSize_ShouldReturnCorrectSize()
    {
        Assert.AreEqual(0, _listManager.GetSize(_testList));

        _listManager.AddElement(_testList, 10);
        Assert.AreEqual(1, _listManager.GetSize(_testList));
    }

    [Test]
    public void Methods_ShouldThrowExceptionIfListIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => _listManager.AddElement(null, 10));
        Assert.Throws<ArgumentNullException>(() => _listManager.RemoveElement(null, 10));
        Assert.Throws<ArgumentNullException>(() => _listManager.GetSize(null));
    }
}
