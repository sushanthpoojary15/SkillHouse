using EduSync.DataAccess.Contracts;
using EduSync.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EduSync.DataAccess
{
    public class XyzRepository : IXyzRepository
    {
        private readonly EduSyncContext _eduSyncContext;

        public XyzRepository(EduSyncContext eduSyncContext)
        {
            this._eduSyncContext = eduSyncContext;
        }
        public void AddXyz(Xyz xyz)
        {
            this._eduSyncContext.Xyzs.Add(xyz);
        }

        public void DeleteXyz(int xyzId)
        {
            var entityToBeDeleted = this._eduSyncContext.Xyzs.Where(c => c.Id == xyzId).FirstOrDefault();
            if (entityToBeDeleted != null)
            {
                var entry = this._eduSyncContext.Entry(entityToBeDeleted);
                entry.State = EntityState.Deleted;
            }
        }

        public Xyz GetXyz(int xyzId)
        {
            var entityToBeFetched = this._eduSyncContext.Xyzs.Where(c => c.Id == xyzId).FirstOrDefault();
            return entityToBeFetched;
        }

        public List<Xyz> GetXyzs()
        {
            return this._eduSyncContext.Xyzs.ToList();
        }

        public int SaveChanges()
        {
            return this._eduSyncContext.SaveChanges();
        }

        public void UpdateXyz(Xyz xyz)
        {
            var entityToUpdate = this._eduSyncContext.Xyzs.Find(xyz.Id);
            if (entityToUpdate != null)
            {
                entityToUpdate.Column1 = xyz.Column1;
                entityToUpdate.Column2 = xyz.Column2;
            }
        }
    }
}
