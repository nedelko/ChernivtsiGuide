using System;
using System.Collections.Generic;
using System.Text;

namespace ChernivtsiGuide
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
