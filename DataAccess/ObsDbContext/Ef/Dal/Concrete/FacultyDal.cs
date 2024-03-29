﻿using DataAccess.ObsDbContext.Ef.Dal.Abstract;
using Entities.ObsEntities;
using System.Linq.Expressions;
using DataAccess.ObsDbContext.Ef.Repository;

namespace DataAccess.ObsDbContext.Ef.Dal.Concrete
{
    public class FacultyDal:IFacultyDal
    {
        public bool Any(Expression<Func<Faculty, bool>> filter)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                return context.Faculties.Any(filter);
            }
        }

        public Faculty Get(Expression<Func<Faculty, bool>> filter)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                return context.Faculties.FirstOrDefault(filter);
            }
        }

        public List<Faculty> GetList(Expression<Func<Faculty, bool>>? filter=null)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                if (filter == null)
                    return context.Faculties.ToList();
                else
                    return context.Faculties.Where(filter).ToList();
            }
        }

        public Faculty Add(Faculty entity)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                context.Faculties.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public Faculty Update(Faculty entity)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                context.Faculties.Update(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public Faculty Remove(Faculty entity)
        {
            using (var context = new BiruniSchoolDbContext())
            {
                context.Faculties.Remove(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public bool BulkInsert(List<Faculty> list)
        {
            throw new NotImplementedException();
        }
    }
}
