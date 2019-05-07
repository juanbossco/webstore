# Intro

Tech Stack

* ASP.NET Core 2.2
* Azure services

For purposes of this POC in-memory storage was implemented. This POC does not implement databases.


# Architecture

Architecture Diagram

![BFF/Microservice Architecture](resources/Webstore%20Architecture.png?raw=true "BFF/Microservice Architecture")

## Architecture Overview

---

Different architecture patterns were used to design this POC

* The Backend for Frontend (BFF) architecture
* Gatteway architecture


### Backend For Frontend (BFF) Architecture

---
Authenticates Customers

### Gateway Architecture

---

The Gateway API performs as the business layer and proxy for all clients; it's the single point of entry for all clients to interact with internal microservices.

This architecture pattern abstracts away all backend (internal services) and dependencies behind facades.

### Microservice Architecture

---
Loosely coupled services that can evolve and be deployed indenpendently.

### Event Driven Architecture

---

Decouple services, execute asynchronous processes and implement workflow automation after an event occurs.


### Relational Dabase (SQL) & Non-Relational Database (NoSQL)

---

* NOTE: No database was implemented in this POC. An in-mem storage system was implemented.

SQL database (relational database) for transaction oriented applications, frequent and short transactions.
No-SQL for storage and fast retrieval of data, i.e. Order history.


### Caching

---

Product and Cart services can impplement caching to cache the Customer's cart and product information until an Order is placed for that Cart.

### ElastiSearch 

---

* Optional

Index data to support search functionality.


## Project folder structure
---

<ul type="none">
  <li>Codebase</li>
  <li>
    <ul>
      <li>Event Consumers</li>
      <ul type="none">
        <li>Orchestrator</li>
        <li>Data Aggregator</li>
      </ul>
      <li>DataContext</li>
      <li>Events</li>
      <li>Gateways</li>
      <li>Infrastructure</li>
      <li>Models</li>
      <li>Webservices</li>
      <ul type="none">
        <li>Cart</li>
        <li>Order</li>
        <li>Product</li>
      </ul>
      <li>Test</li>
    </ul>
  </li>
</ul>

## Core Services

---

### Product API
* Endpoint: [webstore-productapi]( https://webstore-productapi.azurewebsites.net/api/products/ "Product API")

### Order API
* Endpoint: [webstore-orderapi]( https://webstore-orderapi.azurewebsites.net/api/orders/ "Order API")

## Cart API
* Endpoint: [webstore-cartapi]( https://webstore-orderapi.azurewebsites.net/api/cart/ "Cart API")

## Gateway API
* Endpoint: [webstore-gatewayapi]( https://webstore-gatewayapi.azurewebsites.net/api/webstore/ "Gateway API")
