using System;
using System.Collections.Generic;
using System.Text;
using DTOShared.DTOs;

namespace StockList.Endpoints
{
    public class ProductDisplay : ProductDto
    {
        public string PriceStr => $"{CurrencySymbol}{Price:#0.00}";
    }
}
