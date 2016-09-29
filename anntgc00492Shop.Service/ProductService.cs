using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using anntgc00492Shop.Common;
using anntgc00492Shop.Data.Infrastructure;
using anntgc00492Shop.Data.Repositories;
using anntgc00492Shop.Model.Models;

namespace anntgc00492Shop.Service
{
    public interface IProductService
    {
        Product Add(Product product);
        void Update(Product product);
        Product Delete(int id);
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAll(string keyword);
        IEnumerable<Product> GetLatest(int top);
        IEnumerable<Product> GetTopSale(int top);
        void Save();

        IEnumerable<Product> GetProductListByCategoryIdSearchSort(int? categoryid, string searchString,
            string orderSort);

    }

    public class ProductService:IProductService
    {
        private IProductRepository _productRepository;
        private ITagRepository _tagRepository;
        private IProductTagRepository _productTagRepository;

        private IUnitOfWork _unitOfWork;



        public ProductService(IProductRepository productRepository,ITagRepository tagRepository,IProductTagRepository productTagRepository,IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._productTagRepository = productTagRepository;
            this._tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
        }   

        public Product Add(Product product)
        {
            var _product = _productRepository.Add(product);
            _unitOfWork.Commit();
            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] tags = product.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.Id == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.Id = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tag);
                    }

                    ProductTag productTag = new ProductTag();
                    productTag.ProductId = product.Id;
                    productTag.TagId = tagId;
                    _productTagRepository.Add(productTag);
                }
            }
            return _product;
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] tags = product.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.Id == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.Id = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tag);
                    }
                    _productTagRepository.DeleteMulti(x => x.ProductId == product.Id);
                    ProductTag productTag = new ProductTag();
                    productTag.ProductId = product.Id;
                    productTag.TagId = tagId;
                    _productTagRepository.Add(productTag);
                }

            }
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public Product GetById(int id)
        {
            return _productRepository.GetSingleById(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _productRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            else
            {
                return _productRepository.GetAll();
            }
        }

        public IEnumerable<Product> GetLatest(int top)
        {
            return _productRepository.GetMulti(x => x.Status).OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public IEnumerable<Product> GetTopSale(int top)
        {
            return
                _productRepository.GetMulti(x => x.Status && x.HotFlag == true)
                    .OrderByDescending(x => x.CreatedDate)
                    .Take(top);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }


        public IEnumerable<Product> GetProductListByCategoryIdSearchSort(int? categoryId, string searchString, string orderSort)
        {
            var productList = GetAll();
            if (!string.IsNullOrEmpty(categoryId.ToString()))
            {
                productList = productList.Where(p => p.CategoryId == categoryId);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                productList = productList.Where(p => p.Name.Contains(searchString) || p.Alias.Contains(searchString));
            }
            switch (orderSort)
            {
                case "Name":
                    productList = productList.OrderByDescending(p => p.Name);
                    break;
                case "Price":
                    productList = productList.OrderByDescending(p => p.Price);
                    break;
                case "Popular":
                    productList = productList.OrderByDescending(p => p.ViewCount);
                    break;
                default:
                    productList = productList.OrderByDescending(p => p.CreatedDate);
                    break;
            }
            return productList;
        }
    }
}
