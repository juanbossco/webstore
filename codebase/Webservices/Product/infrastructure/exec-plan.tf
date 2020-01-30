# Create a resource group
resource "azurerm_resource_group" "webstore" {
    name     = "webstore-dev"
    location = "West US"
}

resource "azurerm_api_management" "webstore" {
    name                = "webstore-apim"
    location            = "${azurerm_resource_group.webstore.location}"
    resource_group_name = "${azurerm_resource_group.webstore.name}"
    publisher_name      = "Thought Salad"
    publisher_email     = "juanbossco@gmail.com"
    sku_name            = "Developer_1"
}

resource "azurerm_api_management_api" "product" {
    name                = "product-api"
    resource_group_name = "${azurerm_resource_group.webstore.name}"
    api_management_name = "${azurerm_api_management.webstore.name}"
    revision            = "1"
    display_name        = "Product API"
    path                = "product"
    protocols           = ["https"]
}