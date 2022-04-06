# .Net-core-API-microservices-DDD
This repository include 2 API's that are going to demonstrate a simple way to implement a microservices architecture for an application. Based on the Microsoft definition, Domain Driven Design talks about problems as domains. It describes independent problem areas as Bounded Contexts (each Bounded Context correlates to a microservice), and emphasizes a common language to talk about these problems. In this repo, we make an effort to implement simple API's and implement a message bus using RabbitMq to share informations between API's. It makes a connection between these API's to talk to each other. Before going deeper in microservice architecture, it is better to bo familiar with below items.

# Message broker
Based on the IBM description, Message brokers are an inter-application communication technology to help build a common integration mechanism to support cloud native, microservices-based, serverless and hybrid cloud architectures. It is significant way to have a talk with other services. So depend on your domain, you need to know about it that your services should get information from message broker or send information to it. We have used RabbitMq as a message broker in this repository, however you can use another message broker instead of RabbitMq like Apache Kafka and Apache Artemis and etc. There is a documentation link of RabbitMq in the below.

# Docker and Kubernetes
<h4>Docker</h4>
Based on the IBM description, Docker is an open source containerization platform. It enables developers to package applications into containers—standardized executable components combining application source code with the operating system (OS) libraries and dependencies required to run that code in any environment. 

<h4>Kubernetes</h4>
Kubernetes is a portable, extensible, open source platform for managing containerized workloads and services, that facilitates both declarative configuration and automation. It has a large, rapidly growing ecosystem.

We have run the SQL server and RabbitMq and our APIs on Kubernetes. So it has provided a convenient way to connect with them.

