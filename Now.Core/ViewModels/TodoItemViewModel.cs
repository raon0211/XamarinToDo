using MvvmCross.Core.ViewModels;
using Now.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace Now.Core.ViewModels
{
    public class TodoItemViewModel : MvxViewModel
    {
        private TodoItem item;
        private ListViewModel parent;

        public TodoItemViewModel(TodoItem item, ListViewModel parent)
        {
            this.item = item;
            this.parent = parent;
        }

        public IMvxCommand DeleteClick
        {
            get
            {
                return new MvxCommand(() => parent.Remove(this));
            }
        }

        public IMvxCommand CheckboxClick
        {
            get
            {
                return new MvxCommand(() => parent.CheckToggle(this));
            }
        }

        public TodoItem Item { get { return item; } }
    }
}
