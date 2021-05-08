using StockBusinessLogic.BindingModels;
using StockBusinessLogic.Interfaces;
using StockBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockBusinessLogic.BusinessLogic
{
    public class ProductBusinessLogic
    {
        private readonly IProductStorage _productStorage;

        public ProductBusinessLogic(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }

        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            if (model == null)
            {
                return _productStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ProductViewModel> { _productStorage.GetElement(model) };
            }
            return _productStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ProductBindingModel model)
        {
            var element = _productStorage.GetElement(new ProductBindingModel { Name = model.Name, Price = model.Price });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть такой продукт");
            }
            if (model.Id.HasValue)
            {
                _productStorage.Update(model);
            }
            else
            {
                _productStorage.Insert(model);
            }
        }

        public void Delete(ProductBindingModel model)
        {
            var element = _productStorage.GetElement(new ProductBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Продукт не найден");
            }
            _productStorage.Delete(model);
        }
    }
}
