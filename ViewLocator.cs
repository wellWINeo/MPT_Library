using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Library.ViewModels;

namespace Library
{
    public class ViewLocator : IDataTemplate
    {
        /// <summary>
        /// Поиск View по ViewModel
        /// </summary>
        /// <param name="data">ViewModel</param>
        /// <returns>View</returns>
        public IControl Build(object data)
        {
            var name = data.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }
            else
            {
                return new TextBlock { Text = "Not Found: " + name };
            }
        }
        
        /// <summary>
        /// Наследует ли ViewModelBase
        /// </summary>
        /// <param name="data">ViewModel</param>
        /// <returns>наследует ли</returns>
        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}