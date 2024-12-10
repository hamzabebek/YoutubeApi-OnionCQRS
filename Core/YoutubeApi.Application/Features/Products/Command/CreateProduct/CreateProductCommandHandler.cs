using MediatR;
using YoutubeApi.Application.Features.Products.Rules;
using YoutubeApi.Application.Interface.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Products.Command.CreateProduct
{
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductRules productRules;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, ProductRules productRules)
        {
            this._unitOfWork = unitOfWork;
            this.productRules = productRules;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();

            await productRules.ProductTitleMustNotBeSame(products, request.Title);

            Product product = new(request.Title,request.Description,request.BrandId,request.Price,request.Discount);

            await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if(await _unitOfWork.SaveAsync() > 0)
            {
                foreach(var categoryId in request.CategoryIds)
                {
                    await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId
                    });

                    await _unitOfWork.SaveAsync();
                }
            }
            return Unit.Value;
        }
    }
}
