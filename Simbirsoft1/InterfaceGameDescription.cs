using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbirsoft1
{
   public interface InterfaceGameDescription
    {
        bool fixNextStep(int i,int j, int num);
        string isCompleted();
        void initMatrix();
    }
}
