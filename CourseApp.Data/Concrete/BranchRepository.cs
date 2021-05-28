using CourseApp.Data.Abstract;
using CourseApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseApp.Data.Concrete
{
    public class BranchRepository : IBranchRepository
    {
        private CourseContext context;
        public BranchRepository(CourseContext _context)
        {
            context = _context;
        }
        public void Add(Branch entity)
        {
            context.Branchs.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = context.Branchs.SingleOrDefault(b=>b.BranchId==id);
            if (result != null)
            {
                context.Branchs.Remove(result);
                context.SaveChanges();
            }

        }

        public IQueryable<Branch> GetAll() => context.Branchs;

        public Branch GetById(int id) => context.Branchs.SingleOrDefault(b=>b.BranchId==id);

        public void Update(Branch entity)
        {
            var result = context.Branchs.SingleOrDefault(b => b.BranchId == entity.BranchId);
            if (result != null)
            {
                result.BranchName = entity.BranchName;
                result.Address = entity.Address;
                result.CoursePrograms = entity.CoursePrograms;
                context.SaveChanges();
            }
        }
    }
}
