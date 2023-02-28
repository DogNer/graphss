using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphss
{
    
    public class TransferData
    {
        private int[,] mas;

        public TransferData(int[,] arr)
        {
            mas = arr;
        }

        public TransferData()
        {
        }

        public int[,] getMas() { 
            return mas;
        }

        public void setMas(int[,] arr)
        {
            mas = arr;
        }
        
    }
}
