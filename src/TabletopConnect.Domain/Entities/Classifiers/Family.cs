﻿using TabletopConnect.Domain.Entities.Common;

namespace TabletopConnect.Domain.Entities.Classifiers;

public class Family : BaseClassifier<int>
{
    private Family()
    {
    }

    public Family(string name) : base(name)
    {
    }
}
