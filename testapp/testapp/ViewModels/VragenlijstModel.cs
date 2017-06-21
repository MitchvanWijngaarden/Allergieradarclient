using System;
using System.Collections.Generic;
using System.Text;

namespace testapp.ViewModels
{
    class VragenlijstModel
    {
        private Dictionary<int, string> myList;
        public Dictionary<int, string> MyList
        {
            get { return myList; }
            set
            {
                myList = value;
                NotifyPropertyChanged("MyList");
            }
        }

        private void LoadData()
        {
            for (int i = 0; i < 3; i++)
            {
                MyList.Add(i, "Item " + i);
            }
        }
    }
}
