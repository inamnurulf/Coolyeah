using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coolyeah
{
    class Drink
    {
        //Mendefinisikan Instance variable
        private int _value;

        //Mendefinisikan Property
        public int Value { get { return _value; } set { _value = value; } }

        //Mendefinisikan method kelas
        public int Increase()
        {
            return _value ++;
        }
        public int Decrease()
        {
            return _value--;
        }
    }
}
