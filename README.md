# Architecture
![BFF/Microservice Architecture](resources/Webstore%20Architecture.png?raw=true "BFF/Microservice Architecture")

## Architecture Overview
### Backend For Frontend (BFF) Architecture
### Gateway Architecture
### Microservice Architecture
### Event Driven Architecture
Decouple service
Asynchronous processes

### Relational Dabase (SQL) & Non-Relational Database (NoSQL)
SQL for transactional features
No-SQL to store Order history
ElastiSearch to index and search Orders

## Project folder structure

* codebase
⋅⋅* Consumers

## Core Services

### Product API
* Endpoint: [webstore-productapi]( https://webstore-productapi.azurewebsites.net/api/products/ "Product API")

### Order API
* Endpoint: [webstore-orderapi]( https://webstore-orderapi.azurewebsites.net/api/orders/ "Order API")

## Cart API
* Endpoint: [webstore-cartapi]( https://webstore-orderapi.azurewebsites.net/api/cart/ "Cart API")

## Gateway API
* Endpoint: [webstore-gatewayapi]( https://webstore-gatewayapi.azurewebsites.net/api/webstore/ "Gateway API")
