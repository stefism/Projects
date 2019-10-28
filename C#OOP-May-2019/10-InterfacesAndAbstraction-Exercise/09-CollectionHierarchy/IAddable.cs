﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _09_CollectionHierarchy
{
    public interface IAddable
    {
        int Add(string item);
        int Index { get; }
        List<String> Collection { get; }
    }
}
