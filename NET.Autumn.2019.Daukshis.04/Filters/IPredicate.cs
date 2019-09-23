using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    public interface IPredicate
    {
        bool IsMatch(int value);
    }
}
