﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ComboItem
{
    private Object _key;

    public Object Key
    {
        get { return _key; }
        set { _key = value; }
    }

    private string _value;

    public string Value
    {
        get { return this._value; }
        set { this._value = value; }
    }

    public ComboItem(Object key, string value)
    {
        _key = key;
        _value = value;
    }

    public override string ToString()
    {
        return this._value;
    }
    public static bool operator ==(ComboItem item1, ComboItem item2)
    {
        return ComboItem.Equals(item1, item2);
    }
    public static bool operator !=(ComboItem item1, ComboItem item2)
    {
        return !ComboItem.Equals(item1, item2);
    }
    public override bool Equals(Object obj)
    {
        if (GetType() != obj.GetType())
        {
            return false;
        }
        return ((ComboItem)obj).Key == this._key && ((ComboItem)obj).Value == this._value;
    }
    public override int GetHashCode()
    {
        return this.Key.GetHashCode();
    }
}
