using DeviationModule.Models;
using DeviationModule.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviationModule.Services
{
    class UserDialogService
    {
        public bool Edit(object item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            switch (item)
            {
                default: throw new NotSupportedException($"Редактирование объекта типа {item.GetType().Name} не поддерживается");
                case Launch launch:
                    return EditLaunch(launch);

            }
        }
        bool EditLaunch(Launch launch)
        {
            
                var Dlg = new LaunchEditWindowView
                {
                    Consumer = launch.Consumer,
                    Period = launch.Period,
                    StartDate = launch.LaunchDate,
                    StartTime = launch.LaunchTime
                };
            if (Dlg.ShowDialog() != true) return false;

            launch.Period = Dlg.Period;
            launch.Consumer = Dlg.Consumer;
            launch.LaunchDate = Dlg.StartDate;
            launch.LaunchTime = Dlg.StartTime;
            return true;
        }
    }
}
