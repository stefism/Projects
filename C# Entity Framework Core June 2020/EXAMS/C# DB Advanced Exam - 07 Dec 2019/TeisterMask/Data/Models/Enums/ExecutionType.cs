using System;
using System.Collections.Generic;
using System.Text;

namespace TeisterMask.Data.Models.Enums
{
    public enum ExecutionType
    {
        ProductBacklog,
        SprintBacklog,
        InProgress,
        Finished

            //Много грозно! Първо ни се обяснява как трябва да има дефолтна нулева стойност и всички да имат зададен номер, а после на изпита се прави точно обратното и иди гадай как ти започва енъма.

       // Unknown = 0,
       // ProductBacklog = 1,
       // SprintBacklog = 2,
       // InProgress = 3,
       // Finished = 4
    }
}
