using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Coolyeah
{
    class Sleep
    {
        //Mendefinisikan Instance variable
        private string _notes;
        private DateTime _start;
        private DateTime _end;

        //Mendefinisikan Property
        public string Notes { get { return _notes; } set { _notes = value; } }
        public DateTime Start { get { return _start; } set { _start = value; } }
        public DateTime End { get { return _end; } set { _end = value; } }

        //Mendefinisikan method kelas
        public string setValue(DateTime Start, DateTime End)
        {
            _start = Start; _end = End;
            return _notes;
        }
    }
}
