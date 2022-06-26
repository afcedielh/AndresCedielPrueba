using Catalog.Business.DTOs;
using Catalog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Business.Category
{
    public class CategoryBusiness
    {
        public static DTOCategory? Create(DTOCategory cat)
        {
            try
            {
                using var context = new CatalogContext();
                int catCount = context.Categories.Count(c => c.CategoryName == cat.CategoryName);
                if (catCount == 0)
                {
                    Data.Models.Category categoryAdd = context.Categories.Add(new Data.Models.Category()
                    {
                        CategoryName = cat.CategoryName
                    }).Entity;
                    int entries = context.SaveChanges();
                    if (entries > 0)
                    {
                        return new DTOCategory()
                        {
                            CategoryId = cat.CategoryId,
                            CategoryName = cat.CategoryName
                        };
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DTOCategory? Update(DTOCategory cat)
        {
            try
            {
                using var context = new CatalogContext();
                Data.Models.Category? catUpdate = context.Categories.FirstOrDefault(c => c.CategoryId == cat.CategoryId);
                if (catUpdate != null)
                {
                    catUpdate.CategoryName = cat.CategoryName;
                    int entries = context.SaveChanges();
                    if (entries > 0)
                    {
                        return new DTOCategory()
                        {
                            CategoryId = catUpdate.CategoryId,
                            CategoryName = catUpdate.CategoryName
                        };
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool Delete(DTOCategory cat)
        {
            try
            {
                using var context = new CatalogContext();
                Data.Models.Category? catDelete = context.Categories.FirstOrDefault(c => c.CategoryId == cat.CategoryId);
                if (catDelete != null)
                {
                    context.Categories.Remove(catDelete);
                    int entries = context.SaveChanges();
                    return entries > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public static List<DTOCategory> GetAll()
        {
            try
            {
                using var context = new CatalogContext();
                List<DTOCategory> categories = (from cat in context.Categories
                                                select new DTOCategory()
                                                {
                                                    CategoryId = cat.CategoryId,
                                                    CategoryName = cat.CategoryName
                                                }).ToList();
                return categories;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<DTOCategory> GetByID(int Id)
        {
            try
            {
                using var context = new CatalogContext();
                List<DTOCategory> categories = (from cat in context.Categories
                                                where cat.CategoryId == Id
                                                select new DTOCategory()
                                                {
                                                    CategoryId = cat.CategoryId,
                                                    CategoryName = cat.CategoryName
                                                }).ToList();
                return categories;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
