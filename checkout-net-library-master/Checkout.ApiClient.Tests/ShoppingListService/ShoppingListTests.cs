using System;
using System.Linq;
using System.Net;
using FluentAssertions;
using NUnit.Framework;
using Tests.Utils;


namespace Tests.ShoppingListService
{
    /// <summary>
    /// NOTE - ONCE SHOPPINGLIST API IS RUNNING, INTEGRATION TESTS WILL PASS
    /// </summary>
    [TestFixture(Category = "ShoppingListApi")]
    class ShoppingListTests : BaseServiceTests
    {
        [Test]
        public void CreateItem()
        {
            var itemCreateModel = TestHelper.GetItemBaseModel();
            var response = CheckoutClient.ShoppingListService.CreateItem(itemCreateModel.ItemName, itemCreateModel.Quantity, itemCreateModel);
            
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.HttpStatusCode);
        }

        [Test]
        public void UpdateItem()
        {
            var itemCreateModel = TestHelper.GetItemBaseModel();
            //--------------CREATE NEW LIST ITEM
            var response = CheckoutClient.ShoppingListService.CreateItem(itemCreateModel.ItemName, itemCreateModel.Quantity, itemCreateModel);

            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.HttpStatusCode);

            //--------------UPDATE LIST ITEM
            response = CheckoutClient.ShoppingListService.UpdateItem(itemCreateModel.ItemName, new Random().Next(), itemCreateModel);

            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.HttpStatusCode); 
        }

        [Test]
        public void DeleteItem()
        {
            var itemCreateModel = TestHelper.GetItemBaseModel();
            //--------------CREATE NEW LIST ITEM
            var response = CheckoutClient.ShoppingListService.CreateItem(itemCreateModel.ItemName, itemCreateModel.Quantity, itemCreateModel);

            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.HttpStatusCode);

            //--------------DELETE LIST ITEM
            response = CheckoutClient.ShoppingListService.DeleteItem(itemCreateModel.ItemName);

            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.HttpStatusCode);
        }

        [Test]
        public void GetItemQuantity()
        {
            var itemCreateModel = TestHelper.GetItemBaseModel();
            //--------------CREATE NEW LIST ITEM
            var response = CheckoutClient.ShoppingListService.CreateItem(itemCreateModel.ItemName, 7, itemCreateModel);

            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.HttpStatusCode);


            //--------------DELETE LIST ITEM
            var responseTwo = CheckoutClient.ShoppingListService.GetItemQuantity(itemCreateModel.ItemName);

            Assert.IsNotNull(responseTwo);
            Assert.AreEqual(HttpStatusCode.OK, responseTwo.HttpStatusCode);
            Assert.AreEqual(responseTwo.Model.Quantity, 7);
        }

        [Test]
        public void GetAllItems()
        {
            var itemCreateModel = TestHelper.GetItemBaseModel();
            //--------------CREATE NEW LIST ITEM
            var response = CheckoutClient.ShoppingListService.CreateItem(itemCreateModel.ItemName, itemCreateModel.Quantity, itemCreateModel);
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.HttpStatusCode);

            itemCreateModel = TestHelper.GetItemBaseModel();
            response = CheckoutClient.ShoppingListService.CreateItem(itemCreateModel.ItemName, itemCreateModel.Quantity, itemCreateModel);
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.HttpStatusCode);


            //--------------GET ALL LIST ITEMS
            var responseTwo = CheckoutClient.ShoppingListService.GetAllItems();

            Assert.IsNotNull(responseTwo);
            Assert.AreEqual(HttpStatusCode.OK, responseTwo.HttpStatusCode);
            Assert.IsNotNull(responseTwo.Model.ShoppingItemList);
        }
    }
}
