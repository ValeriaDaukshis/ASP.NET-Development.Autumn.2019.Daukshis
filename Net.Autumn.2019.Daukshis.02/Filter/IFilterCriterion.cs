using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filter
{
    public interface IFilterCriterion
    {
        bool IsMatch(int value);
    }
}
