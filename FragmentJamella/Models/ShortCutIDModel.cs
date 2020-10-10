using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragmentJamella
{
    public class ShortCutIDModel
    {
        public string _id;
        public int _typeID;
        public string _categoryID;
        public string _name;

        public ShortCutIDModel(string id,int typeID, string catID,string name)
        {
            _id = id;
            _typeID = typeID;
            _categoryID = catID;
            _name = name;
        }
    }
}
