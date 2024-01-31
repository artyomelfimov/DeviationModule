using DeviationModule.DAL.Context;
using DeviationModule.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviationModule.Infrastructure
{
    internal class DBInitializer
    {
        private readonly DeviationDB DeviationDB;
        public DBInitializer(DeviationDB dB) {
            DeviationDB = dB;
        }
        public async Task InitializeAsync()
        {
            await DeviationDB.Database.MigrateAsync().ConfigureAwait(false);
            if (await DeviationDB.Deviations.AnyAsync()) return;

            await InitializeProcedures();
            await InitializeLaunches();
            await InitializeDeviations();
        }
        private const int _ProceduresCount = 10;
        private Procedure[] _Procedures;
        private async Task InitializeProcedures()
        {
            _Procedures = new Procedure[_ProceduresCount];
            for (var i = 0; i < _ProceduresCount; i++)
                _Procedures[i] = new Procedure { Name = $"Процедура {i + 1}", Owner = $"Владелец {i + 1}", Description =  $"Описание процедуры {i + 1}", Status = "Готово" };
            await DeviationDB.Procedures.AddRangeAsync( _Procedures );
            await DeviationDB.SaveChangesAsync();
        }
        private const int _LaunchCount = 100;
        private Launch[] _Launches;

        private async Task InitializeLaunches()
        {
            var rnd = new Random();
            _Launches = new Launch[_LaunchCount];
            _Launches = Enumerable.Range(1, _LaunchCount)
               .Select(i => new Launch
               {
                   Consumer = $"Заказчик {i + 1}",
                   LaunchTime = DateTime.Today,
                   LaunchDate = DateTime.Today,
                   Procedure = rnd.NextItem(_Procedures)
               })
               .ToArray();
            await DeviationDB.Launches.AddRangeAsync(_Launches);
            await DeviationDB.SaveChangesAsync();
        }
        private const int _DeviationCount = 1000;
        private Deviation[] _Deviations;
        private async Task InitializeDeviations()
        {
            var rnd = new Random();
            _Deviations = new Deviation[_DeviationCount];
            _Deviations = Enumerable.Range(1, _DeviationCount)
               .Select(i => new Deviation
               {
                   BarCode = $"Штрихкод № {i}",
                   Date = DateTime.Today,
                   IsCorrected = true,
                   Status = "Готов",
                   Owner = $"Владелец {i}",
                   Comment = $"{i}",
                   Procedure = rnd.NextItem(_Procedures)
               })
               .ToArray();
            await DeviationDB.Deviations.AddRangeAsync(_Deviations);
            await DeviationDB.SaveChangesAsync();
        }
    }

}
