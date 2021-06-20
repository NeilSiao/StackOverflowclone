using System;
using System.Collections.Generic;
using System.Linq;
using StackOverflow.DomainModels;
namespace StackOverflow.Repositories
{
    public interface ICategoriesRepository
    {
        void InsertCategory(Category u);
        void UpdateCategory(Category u);
        void DeleteCategory(int cid);
        Category GetCategoryByCategoryID(int cid);

        List<Category> GetCategories();
    }
    public class CategoriesRepository : ICategoriesRepository
    {
        readonly StackOverflowDatabaseDbContext db;

        public CategoriesRepository()
        {
            db = new StackOverflowDatabaseDbContext();
        }

        public void DeleteCategory(int cid)
        {
            Category ct = db.Categories.Where(temp => temp.CategoryID == cid).FirstOrDefault();
            if(ct != null)
            {
                db.Categories.Remove(ct);
                db.SaveChanges();
            }
        }

        public Category GetCategoryByCategoryID(int cid)
        {
           Category cts = db.Categories.Where(temp => temp.CategoryID == cid)
                .FirstOrDefault();
   
                return cts;
            
        }

        public void InsertCategory(Category ct)
        {
            
                db.Categories.Add(ct);
                db.SaveChanges();
            
        }

        public void UpdateCategory(Category u)
        {
            Category ct = db.Categories.Where(temp => temp.CategoryID == u.CategoryID).FirstOrDefault();
            if (ct != null)
            {
                ct.CategoryName = u.CategoryName;
                db.SaveChanges();
            }
        }
        public List<Category> GetCategories()
        {
            List<Category> ct = db.Categories.ToList();
            return ct;
        }
    }
    
}
