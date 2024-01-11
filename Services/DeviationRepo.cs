using DeviationModule.Infrastructure;
using DeviationModule.Models;
using DeviationModule.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace DeviationModule.Services
{
    public class DeviationRepo : RepoInMemory<Deviation>
    {
        public DeviationRepo() : base(GetDeviations()) { }
        public override void Update(Deviation entity, Deviation destination)
        {
            destination.Date = entity.Date;
            destination.Status = entity.Status;
            destination.IsCorrected = entity.IsCorrected;
            destination.BarCode = entity.BarCode;
            destination.Comment = entity.Comment;
        }
        public static IEnumerable<Deviation> GetDeviations()
        {
            using TestDbContext db = new();
            return db.Deviations.ToList();
        }
    }
    public class ProcedureRepo : RepoInMemory<Procedure>
    {
        public ProcedureRepo() : base(GetProcedures()) { }
        public override void Update(Procedure Source, Procedure Destination)
        {
            Destination.Status = Source.Status;
            Destination.Name = Source.Name;
            Destination.Description = Source.Description;
            Destination.Owner = Source.Owner;
            Destination.Deviations = Source.Deviations;
            Destination.Launches = Source.Launches;
        }
        public static IEnumerable<Procedure> GetProcedures()
        {
            using TestDbContext db = new();
            return db.Procedures.Include(u => u.Deviations).Include(u => u.Launches).ToList();
        }
    }
    
    public class LaunchRepo : RepoInMemory<Launch>
    {
        public LaunchRepo() : base(GetLaunches()) { }
        public override void Update(Launch Source, Launch Destination)
        {
            Destination.LaunchDate = Source.LaunchDate;
            Destination.LaunchTime = Source.LaunchTime;
            Destination.Procedure = Source.Procedure;
            Destination.Period = Source.Period;
            Destination.Consumer = Source.Consumer;
            
        }
        public static IEnumerable<Launch> GetLaunches()
        {
            using TestDbContext db = new();
            return db.Launches.ToList();
        }
    }
}
