using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout.ApiServices.SharedModels;
using Checkout.ApiServices.ShoppingList.RequestModels;
using Checkout.ApiServices.ShoppingList.ResponseModels;

namespace Checkout.ApiServices.ShoppingList
{
    /// <summary>
    /// ADDITIONAL CHANGES MADE INCLUDE ADDING A NEW 'LOCAL' ENVIRONMENT 
    /// FOR LOCALHOST URI
    /// </summary>
    public class ShoppingListService
    {
        public HttpResponse<OkResponse> CreateItem(string itemName, int quantity, ItemBase requestModel)
        {
            var createItemUri = string.Format(ApiUrls.ShoppingListItems, itemName, quantity);
            return new ApiHttpClient().PostRequest<OkResponse>(createItemUri, AppSettings.SecretKey, requestModel);
        }

        public HttpResponse<OkResponse> UpdateItem(string itemName, int quantity, ItemBase requestModel)
        {
            var updateItemUri = string.Format(ApiUrls.ShoppingListItems, itemName, quantity);
            return new ApiHttpClient().PutRequest<OkResponse>(updateItemUri, AppSettings.SecretKey, requestModel);
        }

        public HttpResponse<OkResponse> DeleteItem(string itemName)
        {
            var deleteItemUri = string.Format(ApiUrls.ShoppingListItem, itemName);
            return new ApiHttpClient().DeleteRequest<OkResponse>(deleteItemUri, AppSettings.SecretKey);
        }

        public HttpResponse<ItemQuantity> GetItemQuantity(string itemName)
        {
            var getItemQuantityUri = string.Format(ApiUrls.ShoppingListItem, itemName);
            return new ApiHttpClient().GetRequest<ItemQuantity>(getItemQuantityUri, AppSettings.SecretKey);
        }

        public HttpResponse<ItemList> GetAllItems()
        {
            var getAllItemsUri = string.Format(ApiUrls.ShoppingListAllItems);
            return new ApiHttpClient().GetRequest<ItemList>(getAllItemsUri, AppSettings.SecretKey);
        }
    }
}
