using Manager4.data.entity;
using System;

namespace Manager4.data.dao
{
    public class EyeDAO : DAO, IDisposable
    {
        public EyeEntity Create(float sph, float cyl, int ax, float add, int va, int fh, float pd2, float pd)
        {
            EyeEntity entity = new EyeEntity();
            entity.Sph = sph;
            entity.Cyl = cyl;
            entity.Ax = ax;
            entity.Add = add;
            entity.Va = va;
            entity.Fh = fh;
            entity.Pd2 = pd2;
            entity.Pd = pd;

            try
            {
                db.Eyes.Add(entity);
                db.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                db.Eyes.Remove(entity);
                throw;
            }
        }

        public void Dispose() { }
    }
}
