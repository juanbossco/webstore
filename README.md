# Intro

---

The technologies used in this POC are the ones I have experience with. I used ASP.NET Core 2.2 and Azure to host services.

This POC does not implement databases, in-memory storage was implemented.


# Architecture

---

Architecture Diagram

![BFF/Microservice Architecture](resources/Webstore%20Architecture.png?raw=true "BFF/Microservice Architecture")

## Architecture Overview

---

### Backend For Frontend (BFF) Architecture

---
Authenticates Customers

### Gateway Architecture

---

The Gateway services performs as the business layer

### Microservice Architecture

---
Services that can evolve and be deployed indenpendently

### Event Driven Architecture

---

Decouple services, execute asynchronous processes and implement workflow automation

Use case: trigger OrderPlaced event when Customer places and Order, then the Orchestrator will call the Cart service to delete the Cart associated with the Order.

### Relational Dabase (SQL) & Non-Relational Database (NoSQL)

---

* NOTE: No database was implemented in this POC. An in-mem storage system was implemented.

SQL for transactional features, i.e. Creating Products
No-SQL to store Order and Cart data

### Caching

---

Products and Cart services can impplement caching, not implemented in this POC, but some caching strategies can be implemented, i.e. in-mem caching or redis

### ElastiSearch 

---

Index Orders using ElasticSerach to support certain functionalities that require querying Orders history, i.e. Search orders

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
