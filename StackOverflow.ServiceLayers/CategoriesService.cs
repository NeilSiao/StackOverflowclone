using System;
using System.Collections.Generic;
using StackOverflow.DomainModels;
using StackOverflow.ViewModels;
using StackOverflow.Repositories;
using AutoMapper;
using AutoMapper.Configuration;
namespace StackOverflow.ServiceLayers
{
    public interface ICategoriesService
    {
        void InsertCategory(CategoryViewModel cvm);
        void UpdateCategory(CategoryViewModel cvm);
        void DeleteCategory(int cid);
        List<CategoryViewModel> GetCategories();
        CategoryViewModel GetCategoryByCategoryID(int cid);
    }

   public class CategoriesService:ICategoriesService

    {
        readonly ICategoriesRepository cr;

        public CategoriesService()
        {
            cr = new CategoriesRepository();
        }
        public void InsertCategory(CategoryViewModel cvm)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryViewModel, Category>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Category c = mapper.Map<Category>(cvm);
            cr.InsertCategory(c);
        }
        public void UpdateCategory(CategoryViewModel cvm)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryViewModel, Category>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            Category c = mapper.Map<Category>(cvm);
            cr.UpdateCategory(c);
        }

        public void DeleteCategory(int cid)
        {
            cr.DeleteCategory(cid);
        }

        public List<CategoryViewModel> GetCategories()
        {
            List<Category> c = cr.GetCategories();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            List<CategoryViewModel> cvm = mapper.Map<List<CategoryViewModel>>(c);
            return cvm;
        }
        public CategoryViewModel GetCategoryByCategoryID(int cid)
        {
            Category c = cr.GetCategoryByCategoryID(cid);
            CategoryViewModel cvm = null;
            if(c!= null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Category, CategoryViewModel>();
                    cfg.IgnoreUnmapped();
                });
                IMapper mapper = config.CreateMapper();
                 cvm = mapper.Map<CategoryViewModel>(c);
            }
         
            return cvm;
        }
    }
}
