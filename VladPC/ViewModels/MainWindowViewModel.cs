using VladPC.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladPC.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Заголовок окна

        /// <summary>
        /// Заголовок окна
        /// </summary>

        private string _title = "Магазин компьютерной техники";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        #endregion
    }
}
