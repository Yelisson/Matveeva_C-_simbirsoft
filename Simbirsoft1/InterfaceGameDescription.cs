using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbirsoft1
{
   public interface InterfaceGameDescription
    {
        void fixNextStep(int i,int j, int num);
        bool isCompleted();
        void initMatrix();
    }
}
