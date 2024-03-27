using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace mvieww
{
    public class ViewModelTovar : INotifyPropertyChanged
    {

        public ObservableCollection<Tovar> Tovares { get; set; }

        public Tovar selectTovar;
        public Tovar SelectTovar
        {
            get { return selectTovar; }
            set
            {
                selectTovar = value;
                OnPropCh("SelectTovar");
            }
        }
        private void OnPropCh([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }

        }

        public ViewModelTovar()
        {
            Tovares = new ObservableCollection<Tovar>
         {
             new Tovar {Title="Молоко", Company="Ферма", Price=560 },
             new Tovar {Title="Хлеб", Company="Пончик", Price =100},
             new Tovar {Title="Масло", Company="Ферма", Price=300  },
             new Tovar {Title="Мандарин", Company="Сад", Price=350}
         };
        }
        public event PropertyChangedEventHandler PropertyChanged;

        Mycommand add;
        public Mycommand Add
        {
            get
            {
                return add ?? (add = new Mycommand(obj =>
                {
                    Tovar t = new Tovar();
                    Tovares.Insert(0,t);
                    SelectTovar = t;
                }
                ));
            }
        }

        Mycommand remove;
        public Mycommand Remove
        {
            get
            {
                return remove ?? (remove = new Mycommand
                (obj =>
                {
                    Tovar t = obj as Tovar;
                    if (t != null)
                    {
                        Tovares.Remove(t);
                    }
                },
                (obj)=>Tovares.Count>0));
            }
        }
    }
}
