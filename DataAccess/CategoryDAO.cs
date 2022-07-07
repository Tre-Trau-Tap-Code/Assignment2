using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDAO : FStoreContext
    {
        private static CategoryDAO instance = null;
        private static readonly object instanceLock = new object();
        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                    return instance;
                }
            }
        }
        public Category GetCategoryByID(int categoryId) => Categories.Find(categoryId);
        public IEnumerable<Category> GetCategories => Categories.ToList();
        public void AddNew(Category category) { Categories.Add(category); SaveChanges(); }
        public void Update(Category category) { Categories.Update(category); SaveChanges(); }
        public void Remove(int categoryId) { Categories.Remove(GetCategoryByID(categoryId)); SaveChanges(); }
    }
}
