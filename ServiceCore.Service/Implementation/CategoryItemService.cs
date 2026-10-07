using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public class CategoryItemService : ICategoryItemService
    {
        private readonly IRepository<CategoryItem> _categoryItemRepository;

        public CategoryItemService(IRepository<CategoryItem> categoryItemRepository)
        {
            _categoryItemRepository = categoryItemRepository;
        }

        public CategoryItem DeleteById(Guid ID)
        {
            var categoryItem = GetByID(ID);

            if (categoryItem == null)
            {
                throw new Exception("No such item found!");
            }

            _categoryItemRepository.Delete(categoryItem);
            return categoryItem;
        }

        public List<CategoryItem> GetAll()
        {
            return _categoryItemRepository.GetAll(selector: x => x).ToList();
        }

        public CategoryItem GetByID(Guid ID)
        {
            return _categoryItemRepository.Get(selector: x => x, predicate: x => x.Id == ID)!;
        }

        public List<CategoryItem> GetCategoryItemsBySubcategoryID(Guid SubcategoryID)
        {
            return _categoryItemRepository.
                GetAll(selector: x => x, predicate: x => x.SubcategoryId == SubcategoryID).ToList();
        }

        public CategoryItem Insert(CategoryItem categoryItem)
        {
            categoryItem.Id = Guid.NewGuid();
            return _categoryItemRepository.Insert(categoryItem);
        }

        public CategoryItem Update(CategoryItem categoryItem)
        {
            return _categoryItemRepository.Update(categoryItem);
        }
    }
}
