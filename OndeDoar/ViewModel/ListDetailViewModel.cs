using System;
using OndeDoar.Model;

namespace OndeDoar.ViewModel
{
    public class ListDetailViewModel : BaseViewModel
    {

        public string Name { get; }
        public string What { get; }
        public string Description { get; }
        public string Address { get; }
        public string Contato { get; }

        public ListDetailViewModel(Place selected)
        {
            Name = selected.Name;
            What = selected.What;
            Description = selected.Description;
            Address = selected.Address;
            Contato = selected.Phone + " " + selected.Email;
        }
    }
}