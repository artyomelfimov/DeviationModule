using DeviationModule.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Windows.System;

namespace DeviationModule.Services
{
    public class ProcedureManager
    {
        public readonly DeviationRepo _Deviations;
        public readonly ProcedureRepo _Procedures;
        public readonly LaunchRepo _Launches;

        public IEnumerable<Deviation> Deviations => _Deviations.GetAll();
        public IEnumerable<Procedure> Procedures => _Procedures.GetAll();
        public IEnumerable<Launch> Launches => _Launches.GetAll();


        public ProcedureManager(DeviationRepo Deviations, ProcedureRepo Procedures,LaunchRepo Launches)
        {
            _Deviations = Deviations;
            _Procedures = Procedures;
            _Launches = Launches;
        }

    }
}
