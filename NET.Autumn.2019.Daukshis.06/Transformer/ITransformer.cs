using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transformer
{
    interface ITransformer
    {
        string TransformToWords(double number);
    }
}
