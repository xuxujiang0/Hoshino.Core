using System;
using System.Collections.Generic;
using System.Text;

namespace Hoshino.Core.Common.Exception
{
    public interface ICoreException
    {
        int getCode();

        string getMessage();
    }
}
