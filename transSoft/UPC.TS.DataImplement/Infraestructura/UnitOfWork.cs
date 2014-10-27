using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC.TS.DataContract.Infraestructura;
using UPC.TS.Entities;
using System.Transactions;
using System.Data.Entity;
namespace UPC.TS.DataImplement.Infraestructura
{
    public class UnitOfWork : IUnitOfWork
    {
        private TransactionScope _transaction;
        private readonly UPCEntities _db;


        public UnitOfWork()
        {
            _db = new UPCEntities();

        }

        public void Dispose() {
        }

        public void StartTransaction()
        {
            _transaction = new TransactionScope();
        }

        public void Commit()
        {
            _db.SaveChanges();
            _transaction.Complete();
        }

        public DbContext Db
        {
            get { return _db; }
        }

    }
}
