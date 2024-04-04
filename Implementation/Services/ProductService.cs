using file.DTOs;
using file.Entities;
using file.Interfaces.Repositoritories;
using file.RequestModel;
using file.ResponseModel;

namespace file.Implementation.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public BaseResponse AddProduct(ProductRequestModel productRequestModel)
        {
            if(_productRepository.GetProductByName(productRequestModel.Name) != null)
            {
                return new BaseResponse
                {
                    Message = "Already exist",
                    Status = false
                };
            }

            Product product = new Product
            {
                Name = productRequestModel.Name,
                Description = productRequestModel.Description,
                UnitOfMeasurement = productRequestModel.UnitOfMeasurement,
                SellingPrice = productRequestModel.Price,
                QuantityAvailable = productRequestModel.QuantityAvailable,
                IsDeleted = false,

            };
            _productRepository.Add(product);
            return new BaseResponse
            {
                Message = "Sucessfully added",
                Status = true
            };
        }
        public BaseResponse DeleteProduct(string name)
        {
            var product = _productRepository.GetProductByName(name);
            if (product == null)
            {
                return new BaseResponse
                {
                    Message = "Product not found",
                    Status = false
                };
            }
            product.IsDeleted = true;
            return new BaseResponse
            {
                Message = "Sucessfully deleted",
                Status = true
            };
        }
        public BaseResponse UpdateProduct( ProductRequestModel poductRequestModel)
        {
            var product = _productRepository.GetProductByName(poductRequestModel.Name);
            if (product == null)
            {
                return new BaseResponse
                {
                    Message = "Product not found",
                    Status = false
                };
            }
            product.Name = poductRequestModel.Name;
            product.Description = poductRequestModel.Description;
            product.UnitOfMeasurement = poductRequestModel.UnitOfMeasurement;
            product.SellingPrice = poductRequestModel.Price;
            return new BaseResponse
            {
                Message = "Sucessfully updated",
                Status = true
            };
        }
        public ProductResponseModel GetProductById(string name)
        {
            var product = _productRepository.GetProductByName(name);
            if (product == null)
            {
                return new ProductResponseModel
                {
                    Message = "Product not found",
                    Status = false
                };
            }
            return new ProductResponseModel
            {
                Data = new ProductDTO
                {
                    Name = product.Name,
                    QuantityAvailable = product.QuantityAvailable,
                    Price = Math.Round(product.SellingPrice,2),
                    UnitOfMeasurement = product.UnitOfMeasurement,
                    Description = product.Description
                },
                Message = "Product returned",
                Status = true
            };
        }

        public GetAllProductResponse GetAllProductResponse()
        {
            

            var Product = _productRepository.GetAllProducts();
            if(Product == null)
            {
                return new GetAllProductResponse
                {
                    Status = false,
                    Message = "No product retrieved"

                };
            }

            var ProductReturned = Product.Select(sr => new ProductDTO
                {
                    Name = sr.Name,
                    Description = sr.Description,
                    Price = Math.Round(sr.SellingPrice,2),
                    UnitOfMeasurement = sr.UnitOfMeasurement
                }).ToList();
            return new GetAllProductResponse
            {
                Data = ProductReturned,
                Message = $"Product available is {ProductReturned.Count} ",
                Status = true
            };
        
        }

    }
}
