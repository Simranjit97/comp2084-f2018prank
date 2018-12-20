using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F2018Pranks.Models
{
    public class EFPrank : IMockPrank
    {
        public DbModel db = new DbModel();

        public IQueryable<Prank> Pranks { get { return db.Pranks; } }

        public Prank Save(Prank prank)
        {
            try
            {
                db.SaveChanges();
                return prank;
            }
            catch
            {
                throw new HttpException(503, string.Format("cannot be save"));
            }
        }
        public Prank Find(Prank prank)
        {
            try
            {
                var pranks = db.Pranks.Find(prank);
                return pranks;
            }
            catch
            {
                throw new HttpException(503, string.Format("cannot be Found"));
            }
        }
        public Prank Add(Prank prank)
        {
            try
            {
                db.SaveChanges();
                return prank;
            }
            catch
            {
                throw new HttpException(503, string.Format("cannot be added"));
            }
        }
    }
}