using MvvmCross.Core.ViewModels;
using Now.Core.Abstract;
using Now.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Now.Core.ViewModels
{
    public class ListViewModel : MvxViewModel
    {
        private readonly IDataService dataService;

        public List<TodoItemViewModel> Items
        {
            get
            {
                return dataService.List().Select(item =>
                {
                    return new TodoItemViewModel(item, this);
                }).ToList();
            }
        }

        public ListViewModel(IDataService dataService)
        {
            this.dataService = dataService; 
        }

        public void AddItem(string item)
        {
            dataService.Add(new TodoItem { Text = item, Completed = false });

            RaisePropertyChanged(() => Items);
        }

        public void CheckToggle(TodoItemViewModel item)
        {
            dataService.Update(item.Item);

            RaisePropertyChanged(() => Items);
        }

        public void Remove(TodoItemViewModel item)
        {
            dataService.Remove(item.Item);

            RaisePropertyChanged(() => Items);
        }
    }
}
