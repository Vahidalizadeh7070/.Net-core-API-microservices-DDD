# .Net-core-API-microservices-DDD
This repository include 2 API's that are going to demonstrate a simple way to implement a microservices architecture for an application. Based on the Microsoft definition, Domain Driven Design talks about problems as domains. It describes independent problem areas as Bounded Contexts (each Bounded Context correlates to a microservice), and emphasizes a common language to talk about these problems. In this repo, we make an effort to implement simple API's and implement a message bus using RabbitMq to share informations between API's. It makes a connection between these API's to talk to each other. Before going deeper in microservice architecture, it is better to bo familiar with below items.

# Message broker
Based on the IBM description, Message brokers are an inter-application communication technology to help build a common integration mechanism to support cloud native, microservices-based, serverless and hybrid cloud architectures. It is significant way to have a talk with other services. So depend on your domain, you need to know about it that your services should get information from message broker or send information to it. We have used RabbitMq as a message broker in this repository, however you can use another message broker instead of RabbitMq like Apache Kafka and Apache Artemis and etc. There is a documentation link of RabbitMq in the below.

# Docker and Kubernetes
<h4>Docker</h4>
Based on the IBM description, Docker is an open source containerization platform. It enables developers to package applications into containersâ€”standardized executable components combining application source code with the operating system (OS) libraries and dependencies required to run that code in any environment. 

<h4>Kubernetes</h4>
Kubernetes is a portable, extensible, open source platform for managing containerized workloads and services, that facilitates both declarative configuration and automation. It has a large, rapidly growing ecosystem.

We have run the SQL server and RabbitMq and our APIs on Kubernetes. So it has provided a convenient way to connect with them.

# About project
In this project, we have 2 services. Platform service and Command service. There is a one-to-many relationship between Platform and Command service. Platfrom service is an API which it has got its own database and project and language, however we use .net core api for both of these projects. Command services is another project with its own database and project too. But the command services is related with platform services and platform services has its own databases. To be aware about platform services when a platform added to platform database, we can use a Message broker which in this project, we have used RabbitMq that is provide Asynchronous communication between these two services. In addition, there is a K8S folder that is includes all of kubernetes yaml file which provide management of containerized APIs and applications like Sql server and RabbitMq. Finally you have 2 APIs which talking to each other. In ohter words, when a platforms add, platfrom service send informations about platform that has been added to the message broker and on the other side, command service listen to the message broker and when a new platform added, it will get the platgform information through the message broker and then it can use those information or store them in the database and etc.

To have better understanding about above definition, visit below links.
<div>
  <a href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice">Designing a DDD-oriented microservices</a>
  </div>
  <div>
  <a href="https://kubernetes.io/docs/home/">Kubernetes</a>
  </div>
  <div>
  <a href="https://www.ibm.com/cloud/learn/docker">What is Docker (IBM)</a>
  </div>
  <div>
<a href="https://www.ibm.com/cloud/learn/message-brokers">What is message broker (IBM)</a>
  </div>
  


