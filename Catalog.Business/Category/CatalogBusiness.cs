using Catalog.Business.DTOs;
using Catalog.Data;

namespace Catalog.Business.Category
{
    public class CatalogBusiness
    {
        public static DTOCatalog? Create(DTOCatalog cat)
        {
            try
            {
                using var context = new CatalogContext();
                int catCount = context.Catalogs.Count(c => c.CatalogName == cat.CatalogName);
                if (catCount == 0)
                {
                    Data.Models.Catalog CatalogAdd = context.Catalogs.Add(new Data.Models.Catalog()
                    {
                        CatalogName = cat.CatalogName,
                        CatalogDescription = cat.CatalogDescription,
                        CatalogImage = cat.CatalogImage
                    }).Entity;
                    int entries = context.SaveChanges();
                    if (entries > 0)
                    {
                        return new DTOCatalog()
                        {
                            CatalogDescription = CatalogAdd.CatalogDescription,
                            CatalogImage = CatalogAdd.CatalogImage,
                            CatalogId = CatalogAdd.CatalogId,
                            CatalogName = CatalogAdd.CatalogName
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

        public static DTOCatalog? Update(DTOCatalog cat)
        {
            try
            {
                using var context = new CatalogContext();
                Data.Models.Catalog? catUpdate = context.Catalogs.FirstOrDefault(c => c.CatalogId == cat.CatalogId);
                if (catUpdate != null)
                {
                    DTOCategory? categ = CategoryBusiness.GetByID(cat.CategoryId).FirstOrDefault();
                    if (categ != null)
                    {

                        catUpdate.CatalogDescription = cat.CatalogDescription;
                        catUpdate.CatalogImage = cat.CatalogImage;
                        catUpdate.CatalogName = cat.CatalogName;
                        catUpdate.CategoryId = cat.CategoryId;

                        int entries = context.SaveChanges();
                        if (entries > 0)
                        {
                            return new DTOCatalog()
                            {
                                CategoryId = catUpdate.CategoryId,
                                CatalogDescription = catUpdate.CatalogDescription,
                                CatalogId = catUpdate.CatalogId,
                                CatalogImage = catUpdate.CatalogImage,
                                CatalogName = catUpdate.CatalogName
                            };
                        }
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool Delete(DTOCatalog cat)
        {
            try
            {
                using var context = new CatalogContext();
                Data.Models.Catalog? catDelete = context.Catalogs.FirstOrDefault(c => c.CatalogId == cat.CatalogId);
                if (catDelete != null)
                {
                    context.Catalogs.Remove(catDelete);
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

        public static List<DTOCatalog> GetAll()
        {
            try
            {
                using var context = new CatalogContext();
                List<DTOCatalog> categories = (from cat in context.Catalogs
                                               select new DTOCatalog()
                                               {
                                                   CategoryId = cat.CategoryId,
                                                   CatalogDescription = cat.CatalogDescription,
                                                   CatalogId = cat.CatalogId,
                                                   CatalogImage = cat.CatalogImage,
                                                   CatalogName = cat.CatalogName
                                               }).ToList();
                return categories;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<DTOCatalog> GetByID(int Id)
        {
            try
            {
                using var context = new CatalogContext();
                List<DTOCatalog> categories = (from cat in context.Catalogs
                                               where cat.CatalogId == Id
                                               select new DTOCatalog()
                                               {
                                                   CategoryId = cat.CategoryId,
                                                   CatalogDescription = cat.CatalogDescription,
                                                   CatalogId = cat.CatalogId,
                                                   CatalogImage = cat.CatalogImage,
                                                   CatalogName = cat.CatalogName
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
