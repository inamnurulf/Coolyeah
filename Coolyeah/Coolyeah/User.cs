using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coolyeah
{
    class User
    {
        //Mendefinisikan Instance variable
        private string _name;
        private int _height;
        private int _weight;
        private int _age;
        private string _sex;
        private int _productivity;
        private int[] _idealvalue;

        //Mendefinisikan Property
        public string Name { get { return _name; } set { _name = value; } }
        public int Height { get { return _height; } set { _height = value; } }
        public int Weight { get { return _weight; } set { _weight = value; } }
        public int Age { get { return _age; } set { _age = value; } }
        public string Sex { get { return _sex; } set { _sex = value; } }
        public int Productivity { get { return _productivity; } set { _productivity = value; } }
        public int[] Idealvalue { get { return _idealvalue; } set { _idealvalue = value; } }

        //Mendefinisikan method kelaz
        public string InputData(string Name, int Height, int Weight, int Age, string Sex, int Productivity)
        {
            return "kalkulasinya belum";
        }
        public string ResetData()
        {
            return "belum juga";
        }
    }
}
