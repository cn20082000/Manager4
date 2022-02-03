using Manager4.data.entity;

namespace Manager4.data.model
{
    public class Eye
    {
        private long _id;
        private float _sph;
        private float _cyl;
        private int _ax;
        private float _add;
        private int _va;
        private int _fh;
        private float _pd2;
        private float _pd;

        public Eye(EyeEntity entity)
        {
            Id = entity.Id;
            Sph = entity.Sph;
            Cyl = entity.Cyl;
            Ax = entity.Ax;
            Add = entity.Add;
            Va = entity.Va;
            Fh = entity.Fh;
            Pd2 = entity.Pd2;
            Pd = entity.Pd;
        }

        public long Id
        {
            get => _id;
            set => _id = value;
        }

        public float Sph
        {
            get => _sph;
            set => _sph = value;
        }

        public float Cyl
        {
            get => _cyl;
            set => _cyl = value;
        }

        public int Ax
        {
            get => _ax;
            set => _ax = value;
        }

        public float Add
        {
            get => _add;
            set => _add = value;
        }

        public int Va
        {
            get => _va;
            set => _va = value;
        }

        public int Fh
        {
            get => _fh;
            set => _fh = value;
        }

        public float Pd2
        {
            get => _pd2;
            set => _pd2 = value;
        }

        public float Pd
        {
            get => _pd;
            set => _pd = value;
        }
    }
}
